using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SimpleSoundboard.Interfaces.Keyboard;
using SimpleSoundboard.Keyboard.NameService;

namespace SimpleSoundboard.Keyboard
{
	public class KeyboardController : IKeyboardController
	{
		private readonly ConcurrentDictionary<string, Dictionary<List<Keys>, Action>> keyboardKeyMap;
		private readonly List<Keys> keyBuffer;
		private readonly int maxCombinationLength;
		private bool paused;
		private (List<Keys>, Action) priorityAction;
		private RawInput.RawInput rawInput;

		public KeyboardController(int maxCombinationLength = 3)
		{
			this.maxCombinationLength = maxCombinationLength;
			keyboardKeyMap = new ConcurrentDictionary<string, Dictionary<List<Keys>, Action>>();
			keyBuffer = new List<Keys>(maxCombinationLength);
		}

		public void Pause()
		{
			paused = true;
		}

		public event IKeyboardController.KeyReleasedHandler OnKeyReleased;

		public void Continue()
		{
			paused = false;
		}

		public IKeyboardController RegisterPriorityAction(IEnumerable<Keys> keys, Action action)
		{
			priorityAction = (keys.ToList(), action);
			return this;
		}

		public void ClearKeyActions()
		{
			keyboardKeyMap.Clear();
		}

		public void RegisterKeyAction(IEnumerable<Keys> keys, Action action, string keyboard = null)
		{
			var enumerable = keys as List<Keys> ?? keys.ToList();
			if (enumerable.Count > maxCombinationLength || enumerable.Count == 0)
				throw new ArgumentException();
			if (string.IsNullOrEmpty(keyboard))
				keyboard = KeyboardConstants.DefaultKeyboard;

			if (keyboardKeyMap.ContainsKey(keyboard))
			{
				if (keyboardKeyMap[keyboard].ContainsKey(enumerable))
					throw new ArgumentException($"There is already an Action registered on {enumerable}");
				keyboardKeyMap[keyboard].TryAdd(enumerable, action);
			}
			else
			{
				keyboardKeyMap.TryAdd(keyboard,
					new Dictionary<List<Keys>, Action>(new KeysEqualityComparer()) {{enumerable, action}});
			}
		}

		public IKeyboardController BindToForm(Form form, bool captureOnlyInForeground = false)
		{
			rawInput = new RawInput.RawInput(form.Handle, captureOnlyInForeground);
			rawInput.KeyPressed += delegate(object sender, RawInputEventArgs rawInputEventArg)
			{
				switch (rawInputEventArg?.KeyPressEvent?.KeyState)
				{
					case KeyState.Pressed:
						KeyPressed(rawInputEventArg);
						break;
					case KeyState.Released:
						KeyReleased(rawInputEventArg);
						break;
				}
			};
			return this;
		}

		private void MatchKeys(string keyboardName)
		{
			var keysToMatch = keyBuffer.ToList();
			if (keyboardKeyMap.ContainsKey(keyboardName))
				if (keyboardKeyMap[keyboardName].ContainsKey(keysToMatch))
				{
					keyboardKeyMap[keyboardName][keysToMatch].Invoke();
					return;
				}

			if (keyboardKeyMap.ContainsKey(KeyboardConstants.DefaultKeyboard))
				if (keyboardKeyMap[KeyboardConstants.DefaultKeyboard].ContainsKey(keysToMatch))
					keyboardKeyMap[KeyboardConstants.DefaultKeyboard][keysToMatch].Invoke();
		}

		private bool MatchPriorityKeys()
		{
			if (priorityAction.Item1.In(keyBuffer.ToList()))
			{
				priorityAction.Item2.Invoke();
				return false;
			}

			return true;
		}

		private void KeyReleased(RawInputEventArgs rawInputEventArgs)
		{
			OnKeyReleased?.Invoke(this, rawInputEventArgs);
			if (!paused)
				if (MatchPriorityKeys())
					MatchKeys(rawInputEventArgs.UniqueName);
			if (keyBuffer.Any(x => x == rawInputEventArgs.KeyCode))
				keyBuffer.Remove(rawInputEventArgs.KeyCode);
		}

		private void KeyPressed(RawInputEventArgs rawInputEventArgs)
		{
			if (keyBuffer.Count < maxCombinationLength && keyBuffer.All(x => x != rawInputEventArgs.KeyCode))
				keyBuffer.Add(rawInputEventArgs.KeyCode);
		}
	}
}
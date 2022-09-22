using SimpleSoundboard.Interfaces.Keyboard;
using SimpleSoundboard.Keyboard.NameService;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SimpleSoundboard.Keyboard
{
	public class KeyboardController : IKeyboardController
	{
		private readonly Dictionary<string, Dictionary<string, Action>> keyboardKeyMap;
        private Dictionary<string, Action> priorityActions;
        private readonly HashSet<Keys> keyBuffer;
		private readonly int maxCombinationLength;
		private RawInput.RawInput rawInput;
        private bool paused;

        public KeyboardController(int maxCombinationLength = 3)
		{
			this.maxCombinationLength = maxCombinationLength;
			keyboardKeyMap = new();
			keyBuffer = new(maxCombinationLength);
			priorityActions = new();
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

		private string KeysToString(IEnumerable<Keys> keys)
		{
			return string.Join(" ", keys.Select(k => k.ToString()).ToArray());
        }

		public IKeyboardController RegisterPriorityAction(IEnumerable<Keys> keys, Action action)
		{
			priorityActions.Add(KeysToString(keys),action);
			return this;
		}

		public void ClearKeyActions()
		{
			keyboardKeyMap.Clear();
		}

		public void RegisterKeyAction(IEnumerable<Keys> keys, Action action, string keyboard = null)
		{
			var enumerable = keys.ToList();
			if (enumerable.Count > maxCombinationLength || enumerable.Count == 0)
				throw new ArgumentException();

			if (string.IsNullOrEmpty(keyboard))
				keyboard = KeyboardConstants.DefaultKeyboard;

			if (keyboardKeyMap.ContainsKey(keyboard))
			{
				if (keyboardKeyMap[keyboard].ContainsKey(KeysToString(keys)))
					throw new ArgumentException($"There is already an Action registered on {enumerable}");
				keyboardKeyMap[keyboard].Add(KeysToString(keys), action);
			}
			else
			{
				keyboardKeyMap.Add(keyboard, new() { { KeysToString(keys), action } });
			}
		}

		public IKeyboardController BindToForm(Form form, bool captureOnlyInForeground = false)
		{
			rawInput = new RawInput.RawInput(form.Handle, captureOnlyInForeground);
			rawInput.KeyPressed += OnKeyEvent;
            return this;
		}

		public void OnKeyEvent(object sender, IKeyEventArgs rawInputEventArg)
		{
            switch (rawInputEventArg?.KeyState)
            {
                case KeyState.Pressed:
                    KeyPressed(rawInputEventArg);
                    break;
                case KeyState.Released:
                    KeyReleased(rawInputEventArg);
                    break;
            }
        }

		private void MatchKeys(string keyboardName)
		{
			var combination = KeysToString(keyBuffer);
			if (keyboardKeyMap.ContainsKey(keyboardName))
			{
                if (keyboardKeyMap[keyboardName].ContainsKey(combination))
                {
                    keyboardKeyMap[keyboardName][combination].Invoke();
                }
            }
		}

		private bool MatchPriorityKeys()
		{
			var combination = KeysToString(keyBuffer);
			if (priorityActions.ContainsKey(combination))
			{
				priorityActions[combination].Invoke();
                return true;
			}
			return false;
		}

		private void KeyReleased(IKeyEventArgs rawInputEventArgs)
		{
			OnKeyReleased?.Invoke(this, rawInputEventArgs);
			if (!paused)
			{
                if (!MatchPriorityKeys())
                {
                    MatchKeys(rawInputEventArgs.UniqueName);
                    MatchKeys(KeyboardConstants.DefaultKeyboard);
                }
            }
			
            if (keyBuffer.Contains(rawInputEventArgs.KeyCode))
				keyBuffer.Remove(rawInputEventArgs.KeyCode);
		}

		private void KeyPressed(IKeyEventArgs rawInputEventArgs)
		{
			if (keyBuffer.Count < maxCombinationLength)
				keyBuffer.Add(rawInputEventArgs.KeyCode);
		}
	}
}
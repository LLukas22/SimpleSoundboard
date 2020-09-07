using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using SimpleSoundboard.Interfaces.Keyboard;
using SimpleSoundboard.Keyboard;
using SimpleSoundboard.NameService.Keyboard;
using Soundboard.RawInput;

namespace Soundboard.Keyboard
{
	public class KeyboardController : IKeyboardController
	{
		private readonly int maxCombinationLength;
		private readonly ConcurrentDictionary<string,Dictionary<List<Keys>, Action>> keyboardKeyMap;
		private RawInput.RawInput rawInput;
		private readonly List<Keys> keyBuffer;
		private (List<Keys>, Action) priorityAction;

		public KeyboardController(int maxCombinationLength = 3)
		{
			this.maxCombinationLength = maxCombinationLength;
			keyboardKeyMap = new ConcurrentDictionary<string, Dictionary<List<Keys>, Action>>();
			keyBuffer=new List<Keys>(maxCombinationLength);
		}


		private void MatchKeys(string keyboardName)
		{
			var keysToMatch = keyBuffer.ToList();
			if (keyboardKeyMap.ContainsKey(keyboardName))
			{
				if (keyboardKeyMap[keyboardName].ContainsKey(keysToMatch))
				{
					keyboardKeyMap[keyboardName][keysToMatch].Invoke();
					return;
				}
			}

			if(keyboardKeyMap.ContainsKey(KeyboardConstants.DefaultKeyboard))
			{
				if (keyboardKeyMap[KeyboardConstants.DefaultKeyboard].ContainsKey(keysToMatch))
				{
					keyboardKeyMap[KeyboardConstants.DefaultKeyboard][keysToMatch].Invoke();
				}
			}
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

		public IKeyboardController RegisterPriorityAction(IEnumerable<Keys> keys, Action action)
		{
			priorityAction = (keys.ToList(), action);
			return this;
		}

		public void RegisterKeyAction(IEnumerable<Keys> keys, Action action, string keyboard = null)
		{
			var enumerable = keys as List<Keys> ?? keys.ToList();
			if(enumerable.Count > maxCombinationLength || enumerable.Count == 0)
				throw new ArgumentException();
			if (string.IsNullOrEmpty(keyboard))
				keyboard = KeyboardConstants.DefaultKeyboard;

			if (keyboardKeyMap.ContainsKey(keyboard))
			{
				if (keyboardKeyMap[keyboard].ContainsKey(enumerable))
					throw new ArgumentException($"There is already an Action registered on {enumerable}");
				else
					keyboardKeyMap[keyboard].TryAdd(enumerable, action);
			}
			else
			{
				keyboardKeyMap.TryAdd(keyboard, new Dictionary<List<Keys>, Action>(new KeysEqualityComparer()) {{ enumerable, action } });
			}
		}

		public IKeyboardController BindToForm(Form form,bool captureOnlyInForeground = false)
		{
			rawInput = new RawInput.RawInput(form.Handle, captureOnlyInForeground);
			rawInput.KeyPressed += delegate(object sender, RawInputEventArg rawInputEventArg) {
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

		private void KeyReleased(RawInputEventArg rawInputEventArg)
		{
			if (MatchPriorityKeys())
			{
				MatchKeys(rawInputEventArg.KeyPressEvent.Name);
			}

			if (keyBuffer.Any(x=>x == rawInputEventArg.KeyCode))
			{
				keyBuffer.Remove(rawInputEventArg.KeyCode);
			}
		}

		

		private void KeyPressed(RawInputEventArg rawInputEventArg)
		{
			if (keyBuffer.Count < maxCombinationLength && keyBuffer.All(x => x != rawInputEventArg.KeyCode))
				keyBuffer.Add(rawInputEventArg.KeyCode);
		}


	}
}
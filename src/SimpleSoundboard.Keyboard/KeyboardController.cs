using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Soundboard.RawInput;

namespace Soundboard.Keyboard
{
	public class KeyboardController
	{
		//private readonly Dictionary<string, Dictionary<(Keys, Keys, Keys), AudioFileEntity>> audioFiles =
		//	new Dictionary<string, Dictionary<(Keys, Keys, Keys), AudioFileEntity>>();

		//private readonly IDictionary<Keys, AudioFileEntity>
		//	lastPathDictionary = new Dictionary<Keys, AudioFileEntity>();

		//private readonly NAudioController nAudioController;

		//private readonly IList<Keys> pressedKeysList = new List<Keys>();
		//public readonly RawInput.RawInput RawInput;
		//private readonly IDictionary<Keys, Keys> StopDictionary = new Dictionary<Keys, Keys>();
		//private readonly IList<Keys> supressedKeys = new List<Keys>();
		//private int actualStopKeyCount;
		//private string lastKeyboard = string.Empty;

		//public KeyboardController(NAudioController nAudioController, RawInput.RawInput rawInput)
		//{
		//	this.nAudioController = nAudioController;
		//	RawInput = rawInput;
		//}

		//private void RawInputOnKeyPressed(object sender, RawInputEventArg e)
		//{
		//	switch (e?.KeyPressEvent?.KeyState)
		//	{
		//		case KeyState.Pressed:
		//			OnKeyDown(e);
		//			break;
		//		case KeyState.Released:
		//			GlobalHookKeyUp(e);
		//			break;
		//	}
		//}

		//public void Subscribe()
		//{
		//	RawInput.KeyPressed += RawInputOnKeyPressed;
		//}

		//public void Unsubscribe()
		//{
		//	RawInput.KeyPressed -= RawInputOnKeyPressed;
		//}

		//private void OnKeyDown(RawInputEventArg args)
		//{
		//	if (!Globals.PlaybackEnabled) return;
		//	pressedKeysList.Add(args.KeyCode);
		//}

		//private void GlobalHookKeyUp(RawInputEventArg args)
		//{
		//	if (!Globals.PlaybackEnabled) return;
		//	CheckStop(args.KeyCode);

		//	if (CheckLast(args))
		//	{
		//		removeKeyFromPressedList(args.KeyCode);
		//		return;
		//	}

		//	if (supressedKeys.Any(x => x == args.KeyCode))
		//	{
		//		removeKeyFromSupressedList(args.KeyCode);
		//		removeKeyFromPressedList(args.KeyCode);
		//		lastPathDictionary.Clear();
		//		return;
		//	}

		//	var activeKeyboardAudioFiles = new Dictionary<(Keys, Keys, Keys), AudioFileEntity>();
		//	if (audioFiles.ContainsKey(args.Hash))
		//		foreach (var entry in audioFiles[args.Hash])
		//			activeKeyboardAudioFiles.Add(entry.Key, entry.Value);
		//	if (audioFiles.ContainsKey(Globals.DefaultKeyboard))
		//		foreach (var entry in audioFiles[Globals.DefaultKeyboard])
		//			activeKeyboardAudioFiles.Add(entry.Key, entry.Value);

		//	switch (pressedKeysList.Count)
		//	{
		//		case 1:
		//			MatchOneKey(args, activeKeyboardAudioFiles);
		//			break;
		//		case 2:
		//			MatchTwoKeys(args, activeKeyboardAudioFiles);
		//			break;
		//		case 3:
		//			MatchThreeKeys(args, activeKeyboardAudioFiles);
		//			break;
		//		default:
		//			pressedKeysList.Clear();
		//			break;
		//	}

		//	removeKeyFromPressedList(args.KeyCode);
		//}

		//public void Refresh(SettingsEntity settingsEntity)
		//{
		//	nAudioController.StopPlayback();
		//	pressedKeysList.Clear();
		//	StopDictionary.Clear();
		//	audioFiles.Clear();

		//	StopDictionary.Add(settingsEntity.StopKeys.StopKey1, settingsEntity.StopKeys.StopKey2);
		//	if (StopDictionary[settingsEntity.StopKeys.StopKey1] == Keys.None)
		//		actualStopKeyCount = 1;
		//	else
		//		actualStopKeyCount = 2;

		//	foreach (var entity in Globals.entityList)
		//	{
		//		if (!audioFiles.ContainsKey(entity.KeyboardName ?? Globals.DefaultKeyboard))
		//			audioFiles.Add(entity.KeyboardName ?? Globals.DefaultKeyboard,
		//				new Dictionary<(Keys, Keys, Keys), AudioFileEntity>());

		//		if (!audioFiles[entity.KeyboardName ?? Globals.DefaultKeyboard].ContainsKey(entity.KeyBinding))
		//			audioFiles[entity.KeyboardName ?? Globals.DefaultKeyboard].Add(entity.KeyBinding, entity);
		//	}
		//}

		//private void CheckStop(Keys keyCode)
		//{
		//	if (pressedKeysList.Count > actualStopKeyCount) return;
		//	if (actualStopKeyCount == 2)
		//	{
		//		if (StopDictionary.Keys.Any(x => x == pressedKeysList[0]))
		//			if (StopDictionary[pressedKeysList[0]] == keyCode)
		//				nAudioController.StopPlayback();
		//	}
		//	else
		//	{
		//		if (StopDictionary.Keys.Any(x => x == keyCode)) nAudioController.StopPlayback();
		//	}
		//}

		//private bool CheckLast(RawInputEventArg args)
		//{
		//	if (!lastKeyboard.Equals(args.Hash) || lastPathDictionary.Count == 0) return false;
		//	if (lastPathDictionary.Keys.First() == args.KeyCode)
		//	{
		//		nAudioController.StartPlayback(lastPathDictionary[args.KeyCode]);
		//		return true;
		//	}

		//	return false;
		//}

		//private void MatchOneKey(RawInputEventArg args,
		//	Dictionary<(Keys, Keys, Keys), AudioFileEntity> audioFileDictionary)
		//{
		//	var key = args.KeyCode;
		//	if (audioFileDictionary.Keys.Any(x => x == (key, Keys.None, Keys.None)))
		//	{
		//		var path = audioFileDictionary[(key, Keys.None, Keys.None)];
		//		nAudioController.StartPlayback(path);
		//		lastPathDictionary.Clear();
		//		lastPathDictionary.Add(key, path);
		//		lastKeyboard = args.Hash;
		//	}
		//	else
		//	{
		//		supressedKeys.Clear();
		//		lastKeyboard = string.Empty;
		//		lastPathDictionary.Clear();
		//		pressedKeysList.Clear();
		//	}
		//}

		//private void MatchTwoKeys(RawInputEventArg args,
		//	Dictionary<(Keys, Keys, Keys), AudioFileEntity> audioFileDictionary)
		//{
		//	var key = args.KeyCode;
		//	if (audioFileDictionary.Keys.Any(x => x == (pressedKeysList[0], key, Keys.None)))
		//	{
		//		var path = audioFileDictionary[(pressedKeysList[0], key, Keys.None)];
		//		nAudioController.StartPlayback(path);
		//		lastPathDictionary.Clear();
		//		lastPathDictionary.Add(key, path);
		//		lastKeyboard = args.Hash;
		//		supressedKeys.Clear();
		//		supressedKeys.Add(pressedKeysList[0]);
		//	}
		//	else
		//	{
		//		supressedKeys.Clear();
		//		lastPathDictionary.Clear();
		//		lastKeyboard = string.Empty;
		//		pressedKeysList.Clear();
		//	}
		//}

		//private void MatchThreeKeys(RawInputEventArg args,
		//	Dictionary<(Keys, Keys, Keys), AudioFileEntity> audioFileDictionary)
		//{
		//	var key = args.KeyCode;
		//	if (audioFileDictionary.Keys.Any(x => x == (pressedKeysList[0], pressedKeysList[1], key)))
		//	{
		//		var path = audioFileDictionary[(pressedKeysList[0], pressedKeysList[1], key)];
		//		nAudioController.StartPlayback(path);
		//		lastPathDictionary.Clear();
		//		lastPathDictionary.Add(key, path);
		//		lastKeyboard = args.Hash;
		//		supressedKeys.Clear();
		//		supressedKeys.Add(pressedKeysList[0]);
		//		supressedKeys.Add(pressedKeysList[1]);
		//	}
		//	else
		//	{
		//		supressedKeys.Clear();
		//		lastKeyboard = string.Empty;
		//		lastPathDictionary.Clear();
		//		pressedKeysList.Clear();
		//	}
		//}


		//private void removeKeyFromPressedList(Keys keys)
		//{
		//	if (pressedKeysList.Any(x => x == keys)) pressedKeysList.Remove(keys);
		//}

		//private void removeKeyFromSupressedList(Keys keys)
		//{
		//	if (supressedKeys.Any(x => x == keys)) supressedKeys.Remove(keys);
		//}
	}
}
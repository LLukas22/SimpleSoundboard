using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using SimpleSoundboard.Interfaces.Models.Models;
using SimpleSoundboard.Interfaces.Models.StorageManager;
using SimpleSoundboard.Models.Base;
using SimpleSoundboard.Models.LegacyModels;
using Soundboard.Entities;

namespace SimpleSoundboard.Models.StorageManager
{
	public class AudioEntryStorageManager : AbstractBaseStorageManager<IAudioEntryModel>, IAudioEntryStorageManager
	{
		public AudioEntryStorageManager(string path) : base(path)
		{
			fileName = "AudioEntries";
		}

		protected override IEnumerable<IAudioEntryModel> LegacyLoad()
		{
			var audioModels = new List<IAudioEntryModel>();
			using StreamReader sr = File.OpenText(fullFilePath);
			using JsonReader reader = new JsonTextReader(sr);
			var legacyAudioModels = ReturnSerializer().Deserialize<IEnumerable<LegacyAudioModel>>(reader);

			foreach (var legacyAudioModel in legacyAudioModels)
			{
				var newAudioModel = new AudioEntryModel()
				{
					FilePath = legacyAudioModel.PathToFile,
					UseSpecificKeyboard = false,
					KeyBinding = new List<Keys>()
					{
						legacyAudioModel.KeyBinding.FirstKey,
						legacyAudioModel.KeyBinding.SecondKey,
						legacyAudioModel.KeyBinding.ThirdKey
					},
					Volume = legacyAudioModel.Volume,
				};
				while (newAudioModel.KeyBinding.Any(x => x == Keys.None))
					newAudioModel.KeyBinding.Remove(Keys.None);
				audioModels.Add(newAudioModel);
			}
			return audioModels;
		}
	}
}

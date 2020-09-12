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
		private const string legacyFileName = "AudioEntityList.json";

		public AudioEntryStorageManager(string path) : base(path)
		{
			fileName = "AudioEntries";
		}

		public override IEnumerable<IAudioEntryModel> Load()
		{
			if (File.Exists(Path.Combine(storagePath, legacyFileName)) && !File.Exists(fullFilePath))
				return LegacyLoad(Path.Combine(storagePath, legacyFileName));
			return base.Load();
		}

		protected override IEnumerable<IAudioEntryModel> LegacyLoad(string legacyFilePath)
		{
			var audioModels = new List<IAudioEntryModel>();
			using var sr = File.OpenText(legacyFilePath);
			using JsonReader reader = new JsonTextReader(sr);
			var legacyAudioModels = ReturnSerializer().Deserialize<IEnumerable<LegacyAudioModel>>(reader);

			foreach (var legacyAudioModel in legacyAudioModels)
			{
				var newAudioModel = new AudioEntryModel
				{
					FilePath = legacyAudioModel.PathToFile,
					UseSpecificKeyboard = false,
					KeyBinding = new List<Keys>
					{
						legacyAudioModel.KeyBinding.FirstKey,
						legacyAudioModel.KeyBinding.SecondKey,
						legacyAudioModel.KeyBinding.ThirdKey
					},
					Volume = legacyAudioModel.Volume
				};
				while (newAudioModel.KeyBinding.Any(x => x == Keys.None))
					newAudioModel.KeyBinding.Remove(Keys.None);
				audioModels.Add(newAudioModel);
			}

			return audioModels;
		}
	}
}
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using MetroFramework;
using Newtonsoft.Json;
using Soundboard.Entities;

namespace Soundboard.Json
{
	public class JasonController
	{
		private readonly JsonSerializerSettings jsonSettings;

		private readonly string PathToAudioEntityList;
		private readonly string PathToSettingsEntity;

		public JasonController(string PathToAudioEntityList, string PathToSettingsEntity)
		{
			this.PathToAudioEntityList = PathToAudioEntityList;
			this.PathToSettingsEntity = PathToSettingsEntity;
			jsonSettings = new JsonSerializerSettings
			{
				NullValueHandling = NullValueHandling.Ignore
			};
		}

		public void Save(IList<AudioFileEntity> audioEntityList, SettingsEntity settingsEntity)
		{
			File.WriteAllText(PathToAudioEntityList,
				JsonConvert.SerializeObject(audioEntityList, Formatting.Indented, jsonSettings));

			File.WriteAllText(PathToSettingsEntity,
				JsonConvert.SerializeObject(settingsEntity, Formatting.Indented, jsonSettings));
		}

		public IList<AudioFileEntity> LoadAudioEntityList()
		{
			if (File.Exists(PathToAudioEntityList))
				using (var reader = new StreamReader(PathToAudioEntityList))
				{
					var json = reader.ReadToEnd();
					return JsonConvert.DeserializeObject<IList<AudioFileEntity>>(json, jsonSettings);
				}

			return new List<AudioFileEntity>();
		}

		public SettingsEntity LoadSettingsEntity()
		{
			if (File.Exists(PathToSettingsEntity))
				using (var reader = new StreamReader(PathToSettingsEntity))
				{
					var json = reader.ReadToEnd();
					return JsonConvert.DeserializeObject<SettingsEntity>(json, jsonSettings);
				}

			var entity = new SettingsEntity();
			entity.Volumes = (0.5f, 0.5f);
			entity.StopKeys = (Keys.Back, Keys.None);
			entity.MetroColorStyle = MetroColorStyle.Orange;
			entity.OutputDevices = (0, 0);
			entity.Inputdevice = 0;
			return entity;
		}
	}
}
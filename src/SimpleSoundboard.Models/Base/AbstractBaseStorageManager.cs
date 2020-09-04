using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using SimpleSoundboard.Interfaces.Models.Base;

namespace SimpleSoundboard.Models.Base
{
	public abstract class AbstractBaseStorageManager<TModel> : IStorageManager<TModel> where TModel : class,IBaseModel
	{
		private readonly string storagePath;
		protected string fileName;
		private string fullFilePath => Path.Combine(storagePath, fileName + ".json");

		protected AbstractBaseStorageManager(string path)
		{
			storagePath = path;
		}


		public IEnumerable<TModel> Load()
		{
			if (File.Exists(fullFilePath))
			{
				using StreamReader sr = File.OpenText(fullFilePath);
				using JsonReader reader = new JsonTextReader(sr);
				return ReturnSerializer().Deserialize<IEnumerable<TModel>>(reader);
			}
			return new List<TModel>(){ReturnDefault()};
		}

		public void Save(IEnumerable<TModel> models)
		{
			using StreamWriter sw = new StreamWriter(fullFilePath);
			using JsonWriter writer = new JsonTextWriter(sw);
			ReturnSerializer().Serialize(writer, models);
		}

		private JsonSerializer ReturnSerializer()
		{
			var serializer = new JsonSerializer();
			serializer.Formatting = Formatting.Indented;
			serializer.NullValueHandling = NullValueHandling.Ignore;
			serializer.TypeNameHandling = TypeNameHandling.Objects;
			serializer.TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple;
			foreach (var converter in ReturnConverters())
			{
				serializer.Converters.Add(converter);
			}
			return serializer;
		}

		protected virtual IEnumerable<JsonConverter> ReturnConverters()
		{
			return new List<JsonConverter>();
		}

		protected virtual TModel ReturnDefault()
		{
			return null;
		}

	}
}

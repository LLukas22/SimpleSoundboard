using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SimpleSoundboard.Interfaces.Logger;
using SimpleSoundboard.Interfaces.Models.Base;
using SimpleSoundboard.NameService.Logging;

namespace SimpleSoundboard.Models.Base
{
	public abstract class AbstractBaseStorageManager<TModel> : IStorageManager<TModel> where TModel : class, IBaseModel
	{
		protected readonly string storagePath;
		protected readonly ILogger logger;
		protected string fileName;

		protected AbstractBaseStorageManager(string path,ILogger logger)
		{
			storagePath = path;
			this.logger = logger;
		}

		protected string fullFilePath => Path.Combine(storagePath, fileName + ".json");


		public virtual IEnumerable<TModel> Load()
		{
			if (File.Exists(fullFilePath))
				try
				{
					using var sr = File.OpenText(fullFilePath);
					using JsonReader reader = new JsonTextReader(sr);
					return ReturnSerializer().Deserialize<IEnumerable<TModel>>(reader);
				}
				catch(Exception exception)
				{
					Exception innerException = null;
					try
					{
						//Try Legacy Deserialize
						return LegacyLoad(fullFilePath);
					}
					catch (Exception coughtInnerException)
					{
						innerException = coughtInnerException;
					}
					finally
					{
						if (innerException != null)
						{
							logger.Log($"[{this.GetType().Name}]Failed LegacyLoad!", innerException,LogLevels.Error);
						}
						else
						{
							logger.Log($"[{this.GetType().Name}]Failed Load!", exception, LogLevels.Error);
						}
					}
				}

			return new List<TModel> {ReturnDefault()};
		}

		public void Save(IEnumerable<TModel> models)
		{
			try
			{
				using var sw = new StreamWriter(fullFilePath);
				using JsonWriter writer = new JsonTextWriter(sw);
				ReturnSerializer().Serialize(writer, models);
			}
			catch (Exception exception)
			{
				logger.Log($"[{this.GetType().Name}]Failed Save!", exception, LogLevels.Error);
			}
			
		}

		protected virtual IEnumerable<TModel> LegacyLoad(string legacyFilePath)
		{
			return new List<TModel> {ReturnDefault()};
		}

		protected JsonSerializer ReturnSerializer()
		{
			var serializer = new JsonSerializer
			{
				Formatting = Formatting.Indented,
				NullValueHandling = NullValueHandling.Ignore,
				TypeNameHandling = TypeNameHandling.Objects,
				TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
			};
			foreach (var converter in ReturnConverters()) serializer.Converters.Add(converter);
			serializer.Converters.Add(new StringEnumConverter());
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
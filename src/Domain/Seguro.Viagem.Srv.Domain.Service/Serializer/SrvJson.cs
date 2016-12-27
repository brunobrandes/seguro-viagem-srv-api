using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguro.Viagem.Srv.Domain.Service.Serializer
{
    public class SrvJson<T>
    {
        #region Private Fields

        private static JsonSerializerSettings _settings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Formatting = Formatting.Indented
        };

        #endregion

        #region Constructor

        static SrvJson()
        {
            _settings.Converters.Add(new StringEnumConverter());
        }

        #endregion

        #region Public Methods

        public static string Serialize(T t)
        {
            return JsonConvert.SerializeObject(t, _settings);
        }

        public static T Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, _settings);
        }

        #endregion
    }
}

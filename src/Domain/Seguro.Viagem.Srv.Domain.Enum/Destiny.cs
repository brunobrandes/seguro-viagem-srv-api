using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Seguro.Viagem.Srv.Domain.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Destiny
    {

        [EnumMember(Value = "brasil")]
        Brazil = 1,

        [EnumMember(Value = "europe")]
        Europe = 2,

        [EnumMember(Value = "south-america")]
        SouthAmerica = 3,

        [EnumMember(Value = "central-america")]
        CentralAmerica = 4,

        [EnumMember(Value = "north-america")]
        NorthAmerica = 5,

        [EnumMember(Value = "asia")]
        Asia = 6,

        [EnumMember(Value = "oceania")]
        Oceania = 7,

        [EnumMember(Value = "middle-east")]
        MiddleEast = 8,

        [EnumMember(Value = "africa")]
        Africa = 9
    }
}

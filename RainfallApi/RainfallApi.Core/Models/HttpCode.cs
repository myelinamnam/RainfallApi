using System.ComponentModel;
using System.Runtime.Serialization;

namespace RainfallApi.Core.Models
{
    public enum HttpCode : int
    {
        [EnumMember]
        [Description("Successful authentication")]
        Success = 200,

        [EnumMember]
        [Description("Bad request")]
        BadRequest = 400,


        [EnumMember]
        [Description("Unauthorized authentication")]
        Unauthorized = 401,


        [EnumMember]
        [Description("Not found")]
        NotFound = 404,


        [EnumMember]
        [Description("Internal server error")]
        InterServerError = 500,
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Milimoe.FunGame.Core.Library.Constant;

namespace Milimoe.FunGame.Core.Library.Common.Network
{
    [Serializable]
    public class JsonObject
    {
        public SocketMessageType MessageType { get; } = SocketMessageType.Unknown;
        public string Token { get; }
        public object[] Parameters { get; }
        public string JsonString { get; }

        [JsonConstructor]
        public JsonObject(SocketMessageType MessageType, string Token, object[] Parameters)
        {
            this.MessageType = MessageType;
            this.Token = Token;
            this.Parameters = Parameters;
            this.JsonString = JsonSerializer.Serialize(this);
        }

        public static string GetString(SocketMessageType MessageType, string Token, object[] Parameters)
        {
            return new JsonObject(MessageType, Token, Parameters).JsonString;
        }

        public static JsonObject? GetObject(string JsonString)
        {
            return JsonSerializer.Deserialize<JsonObject>(JsonString);
        }
    }
}

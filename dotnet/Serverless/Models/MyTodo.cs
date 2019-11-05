using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Serverless
{
    public class MyTodo
    {

        [BsonId]
        [JsonProperty("_Id")]
        public MongoDB.Bson.ObjectId _Id { get; set; }
    
        [JsonProperty]
        public string Id { get; set; }
        

        [BsonElement("name")]
        public string Name { get; set; }

    }
}
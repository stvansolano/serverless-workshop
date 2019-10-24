using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Serverless
{
    public class MyTodo
    {
        [BsonId]
        public BsonObjectId Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

    }
}
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebAPI {

    public class User{
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id {get; set;}
        public string Email {get; set;}
        public int DiskSpace {get; set;}
        public int UsedSpace {get; set;}
        public string Avatar {get; set;}
        public string Files {get; set;}

    }
}
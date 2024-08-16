using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Common.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("UserName")]
        public string UserName { get; set; }
        [BsonElement("Email")]
        public string Email { get; set; }
        [BsonElement("Password")]
        public string Password { get; set; }

    }
}

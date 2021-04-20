using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace hogwartsApi.Models
{
    public class Solicitud{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id {get; set;}
        public string Nombre {get; set;}
        public string Apellido {get; set;}
        public string Identificacion {get; set;}
        public string Edad {get; set;}
        public string Casa {get; set;}
    }
}
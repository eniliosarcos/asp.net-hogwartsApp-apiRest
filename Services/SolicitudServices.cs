using hogwartsApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace hogwartsApi.Services
{
    public class SolicitudService
    {
        private readonly IMongoCollection<Solicitud> _solicitudes;

        public SolicitudService()
        {
            var client = new MongoClient("mongodb+srv://webApp_csharp:enilio1501@cluster0.4x7gz.mongodb.net/hogwartsSolicitudes?retryWrites=true&w=majority");
            var database = client.GetDatabase("hogwartsSolicitudes");

            _solicitudes = database.GetCollection<Solicitud>("Solicitudes");
        }

        public List<Solicitud> GetSolicitudes() =>
            _solicitudes.Find(solicitudes => true).ToList();

        public Solicitud GetSolicitud(string id) =>
            _solicitudes.Find<Solicitud>(solicitudes => solicitudes.Id == id).FirstOrDefault();

        public Solicitud Create(Solicitud solicitudes)
        {
            _solicitudes.InsertOne(solicitudes);
            return solicitudes;
        }
        public void Update(string id, Solicitud solicitudesIn) =>
            _solicitudes.ReplaceOne(solicitudes => solicitudes.Id == id, solicitudesIn);

        public void Remove(string id) => 
            _solicitudes.DeleteOne(solicitudes => solicitudes.Id == id);
    }
}
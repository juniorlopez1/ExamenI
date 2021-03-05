using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Entidad
{
    public class EntidadArticulo
    {
        // Primero instalar los nuggets para usar mongo mongoDB.Driver

        #region Propiedades
        // !
        // [BsonId] Usa la llave (key) de mongo
        [BsonId]
        // Para que se genere automaticamente
        [BsonRepresentation(BsonType.ObjectId)]
        //[BsonElement("Id")] No hace falta en mongoDB
        public string Id { get; set; }



        // nameof para que busque el field en C# que coincida con mongoDB
        [BsonElement(nameof(Codigo))]
        public int Codigo { get; set; }

        [BsonElement(nameof(Descripcion))]
        public string Descripcion { get; set; }

        [BsonElement(nameof(Cantidad_Disponible))]
        public int Cantidad_Disponible { get; set; }

        [BsonElement(nameof(Precio_Unitario))]
        public double Precio_Unitario { get; set; }

        [BsonElement(nameof(Fecha_Caducidad))]
        public DateTime? Fecha_Caducidad { get; set; } //se agrega ? para que pueda ser nullo

        #endregion

        #region Constructor

        public EntidadArticulo()
        {
            Codigo = 0;
            Descripcion = string.Empty;
            Cantidad_Disponible = 0;
            Precio_Unitario = 0.0;
            Fecha_Caducidad = DateTime.MinValue;
            //Id no porque se inicializa con el Bson
        }
        #endregion Constructor
    }
}

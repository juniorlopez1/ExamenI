using Entidad;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccesoDatos
{
    // Aca van conexiones de mongoDB
    public class Acceso
    {
        #region String de conexion de mongoDB

        //! Profe aqui se declara el string de conexion
        // Se declara y define la instancia hacia MongoDB, ademas de indicar si requiere autenticación
        // Tambien probé con mongoDBAtlas
        private readonly string strConexionMongo = @"mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&ssl=false";


        //Objetos para la conexión a la instancia de mongo y a la base de datos
        private MongoClient instancia;
        private IMongoDatabase basedatos;

        //Aqui se especifica el nombre de la coleccion a manipular
        //! borrar private const string NombreBD = "PersonasDB";
        private const string NombreBD = "ArticulosDB";

        #endregion

        #region Constructor Acceso

        public Acceso()
        {
            try
            {
                GetConexion(NombreBD);
            }
            catch (MongoException exM)
            {
                throw exM;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                instancia = instancia != null ? null : instancia;
                basedatos = basedatos != null ? null : basedatos;

                //if (instancia != null)
                //    instancia = null;
                //if (basedatos != null)
                //    basedatos = null;
            }
        }
        #endregion

        #region GetConexion
        private bool GetConexion(string nombreBD)
        {
            bool ConexionCorrecta = false;

            try
            {
                if (nombreBD.Length > 0)
                {
                    //Crea instancia de mongodb
                    instancia = new MongoClient(strConexionMongo);

                    //Prueba de conexión a BD
                    basedatos = instancia.GetDatabase(nombreBD);

                    //verifica conexion positiva
                    ConexionCorrecta = basedatos.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait(1000);
                }
            }
            catch (MongoException exM)
            {
                //excepciones de mongo
                throw exM;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ConexionCorrecta;
        }
        #endregion


        //--------------------------------------- Articulos 

        #region AgregarArticulo
        public bool AgregarArticulo(EntidadArticulo articulo)
        {
            try
            {
                GetConexion(NombreBD);
                var coleccion = basedatos.GetCollection<EntidadArticulo>("ArticuloCollection");

                coleccion.InsertOne(articulo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                instancia = instancia != null ? null : instancia;
                basedatos = basedatos != null ? null : basedatos;

                //if (instancia != null)
                //    instancia = null;
                //if (basedatos != null)
                //    basedatos = null;
            }

            return true;
        }
        #endregion

        #region ModificarArticulo
        public bool ModificarArticulo(EntidadArticulo articulo)
        {
            try
            {
                GetConexion(NombreBD);
                var coleccion = basedatos.GetCollection<EntidadArticulo>("ArticuloCollection");

                coleccion.ReplaceOne(d => d.Codigo == articulo.Codigo, articulo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                instancia = instancia != null ? null : instancia;
                basedatos = basedatos != null ? null : basedatos;

                //if (instancia != null)
                //    instancia = null;
                //if (basedatos != null)
                //    basedatos = null;
            }

            return true;
        }
        #endregion

        #region EliminarArticulo
        public bool EliminarArticulo(EntidadArticulo articulo)
        {
            try
            {
                GetConexion(NombreBD);
                var coleccion = basedatos.GetCollection<EntidadArticulo>("ArticuloCollection");

                coleccion.DeleteOne(d => d.Codigo == articulo.Codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                instancia = instancia != null ? null : instancia;
                basedatos = basedatos != null ? null : basedatos;

                //if (instancia != null)
                //    instancia = null;
                //if (basedatos != null)
                //    basedatos = null;
            }

            return true;
        }
        #endregion

        #region ListarArticulo
        public List<EntidadArticulo> ListarArticulo()
        {
            // No hace falta inicializar parametros
            List<EntidadArticulo> listaResultado = new List<EntidadArticulo>();

            try
            {
                GetConexion(NombreBD);
                var coleccion = basedatos.GetCollection<EntidadArticulo>("ArticuloCollection");

                //if (persona == null) - no hace falta 
                listaResultado = coleccion.Find(d => true).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                instancia = instancia != null ? null : instancia;
                basedatos = basedatos != null ? null : basedatos;

                //if (instancia != null)
                //    instancia = null;
                //if (basedatos != null)
                //    basedatos = null;
            }

            return listaResultado;
        }
        #endregion
    }
}

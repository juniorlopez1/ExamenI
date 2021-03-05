using AccesoDatos;
using Entidad;
using System.Collections.Generic;

namespace Negocio
{
    // Esta es la clase de logica - negocio
    // Es la implementacion del servicio

    public class LogicaNegocio
    {
        #region Constructor Acceso-Negocio
        private Acceso acceso;
        public LogicaNegocio()
        {
            acceso = new Acceso();
        }
        #endregion


        //----------------------------- Articulo

        #region AgregarArticulo
        public bool AgregarArticulo(EntidadArticulo articulo)
        {
            return acceso.AgregarArticulo(articulo);
        }
        #endregion

        #region ModificarArticulo
        public bool ModificarArticulo(EntidadArticulo articulo)
        {
            return acceso.ModificarArticulo(articulo);
        }
        #endregion

        #region EliminarArticulo
        public bool EliminarArticulo(EntidadArticulo articulo)
        {
            return acceso.EliminarArticulo(articulo);
        }
        #endregion

        #region ListarArticulo
        public List<EntidadArticulo> ListarArticulos()
        {
            return acceso.ListarArticulo();
        }
        #endregion

    }
}

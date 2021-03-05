using Entidad;
using Negocio;
using System.Web.Http;


namespace MongoMVC.Controllers
{
    //Como se esta usando API debe de tener el prefix de api/entidad
    [RoutePrefix("api/Articulo")] //!

    public class ArticuloController : ApiController
    {
        //Instalar el nuget y tambien que implementa ApiController (del system)
        #region Constructor Controller-Negocio

        private LogicaNegocio logica;
        public ArticuloController()
        {
            logica = new LogicaNegocio();
        }
        #endregion

        //------------------------------------- Articulo

        #region AgregarArticulo
        [HttpPost]
        [Route(nameof(AgregarArticulo))]

        public bool AgregarArticulo(EntidadArticulo articulo)
        {
            return logica.AgregarArticulo(articulo);
        }
        #endregion

        #region ModificarArticulo
        [HttpPost] //se deberia usar put o patch
        [Route(nameof(ModificarArticulo))]
        public bool ModificarArticulo(EntidadArticulo articulo)
        {
            return logica.ModificarArticulo(articulo);
        }
        #endregion

        #region EliminarArticulo
        [HttpPost] //se deberia usar put o patch
        [Route(nameof(EliminarArticulo))]
        public bool EliminarArticulo(EntidadArticulo articulo)
        {
            return logica.EliminarArticulo(articulo);
        }
        #endregion

        #region ListarArticulo
        [HttpGet]
        [Route(nameof(ListarArticulos))]

        public IHttpActionResult ListarArticulos()
        {
            // profe aca puse que devuelva un JSON
            return Json(logica.ListarArticulos());
        }

        #endregion
    }
}

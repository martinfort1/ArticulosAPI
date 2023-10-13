using Microsoft.AspNetCore.Mvc;
using ArticulosAPI.Modelos;
using ArticulosAPI.Modelos.DTOs;

namespace ArticulosAPI.Repositorios

{
    public interface IArticulosRepositorio
    {
        Task<IEnumerable<ArticulosDto>> GetArticulos();
        Task<ActionResult<ArticulosDto>> GetArticulo(int id);
        Task<ActionResult<ArticulosDto>> PutArticulo(int id, Articulos articulo);
        Task<ArticulosDto> PostArticulo(Articulos articulo);
        Task DeleteArticulo(int id);
        public bool ArticuloExists(int id);
    }
}

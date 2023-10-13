using ArticulosAPI.Modelos;
using ArticulosAPI.Data;
using ArticulosAPI.Modelos.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArticulosAPI.Repositorios
{
    public class ArticulosRepositorio : IArticulosRepositorio
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ArticulosRepositorio(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task DeleteArticulo(int id)
        {
            try
            {
                var articulo = await _context.Articulos.FindAsync(id);
                if (articulo != null)
                {
                    _context.Articulos.Remove(articulo);
                    await _context.SaveChangesAsync();
                }
            }
            catch(Exception){
                throw;
            }
        }

        public async Task<ActionResult<ArticulosDto>> GetArticulo(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);
            return _mapper.Map<Articulos, ArticulosDto>(articulo);
        }

        public async Task<IEnumerable<ArticulosDto>> GetArticulos()
        {
            List<Articulos> articulos = await _context.Articulos.ToListAsync();
            return _mapper.Map<List<Articulos>, List<ArticulosDto>>(articulos);
        }

        public async Task<ArticulosDto> PostArticulo(Articulos articulo)
        {
            await _context.Articulos.AddAsync(articulo);
            await _context.SaveChangesAsync();
            return _mapper.Map<Articulos, ArticulosDto>(articulo);
        }

        public async Task<ActionResult<ArticulosDto>> PutArticulo(int id, Articulos articulo)
        {
            var articuloAModificar = await _context.Articulos.FindAsync(id);
            if(articuloAModificar == null)
            {
                throw new Exception("Artículo no encontrado");
            }
            _mapper.Map(articulo, articuloAModificar);
            await _context.SaveChangesAsync();
            return _mapper.Map<Articulos, ArticulosDto>(articulo);

        }
        public bool ArticuloExists(int id)
        {
            return _context.Articulos.Any(articulo => articulo.Id == id);
        }
    }
}

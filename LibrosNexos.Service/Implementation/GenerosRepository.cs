using LibrosNexos.Domain.Entities;
using LibrosNexos.Persistence.Context.IContext;
using LibrosNexos.Service.Contract;
using Microsoft.EntityFrameworkCore;

namespace LibrosNexos.Service.Implementation
{
    public class GenerosRepository : IGenerosRepository
    {
        private ILibrosNexosContext _context;

        public GenerosRepository(ILibrosNexosContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateGenero(string genero)
        {
            var generoFind = await _context.TBL_GENEROS.FirstOrDefaultAsync(x => x.G_NOMBRE == genero);
            if (generoFind is not null)
                return false;

            await _context.TBL_GENEROS.AddAsync(new TBL_GENEROS { G_NOMBRE = genero, G_ID = 0});

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteGenero(int? id, string? nombre)
        {
            TBL_GENEROS? genero;
            if (id > 0)
                genero = await _context.TBL_GENEROS.FirstOrDefaultAsync(x => x.G_ID == id);
            else
                genero = await _context.TBL_GENEROS.FirstOrDefaultAsync(x => x.G_NOMBRE == nombre);
            
            if (genero is null)
                return false;

            _context.TBL_GENEROS.Remove(genero);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<TBL_GENEROS>> ObtenerGeneros()
        {
            return await _context.TBL_GENEROS.ToListAsync();
        }
    }
}

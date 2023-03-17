using LibrosNexos.Domain.Entities;
using LibrosNexos.Persistence.Context.IContext;
using LibrosNexos.Service.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrosNexos.Service.Implementation
{
    public class GenerosRepository : IGenerosRepository
    {
        private ILibrosNexosContext _context;

        public GenerosRepository(ILibrosNexosContext context)
        {
            _context = context;
        }

        public async Task<List<TBL_GENEROS>> ObtenerGeneros()
        {
            return await _context.TBL_GENEROS.ToListAsync();
        }
    }
}

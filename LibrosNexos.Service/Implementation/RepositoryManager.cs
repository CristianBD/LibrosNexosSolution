using LibrosNexos.Persistence.Context.IContext;
using LibrosNexos.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrosNexos.Service.Implementation
{
    public class RepositoryManager : IRepositoryManager
    {
        private ILibrosNexosContext _context;

        public RepositoryManager(ILibrosNexosContext context)
        {
            _context = context;
        }

        public IGenerosRepository GenerosRepository => new GenerosRepository(_context);
    }
}

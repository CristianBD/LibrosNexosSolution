using LibrosNexos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrosNexos.Persistence.Context.IContext
{
    public interface ILibrosNexosContext
    {
        DbSet<TBL_AUTORES> TBL_AUTORES { get; set; }
        DbSet<TBL_EDITORIALES> TBL_EDITORIALES { get; set; }
        DbSet<TBL_GENEROS> TBL_GENEROS { get; set; }
        DbSet<TBL_LIBROS> TBL_LIBROS { get; set; }

        Task<int> SaveChangesAsync();
    }
}

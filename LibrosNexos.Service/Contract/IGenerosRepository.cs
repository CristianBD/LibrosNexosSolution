using LibrosNexos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrosNexos.Service.Contract
{
    public interface IGenerosRepository
    {
        Task<List<TBL_GENEROS>> ObtenerGeneros();
    }
}

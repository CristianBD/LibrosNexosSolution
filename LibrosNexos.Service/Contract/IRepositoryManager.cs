using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrosNexos.Service.Contract
{
    public interface IRepositoryManager
    {
        public IGenerosRepository GenerosRepository { get; }
    }
}

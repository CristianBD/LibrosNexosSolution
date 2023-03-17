using System;
using System.Collections.Generic;

namespace LibrosNexos.Domain.Entities;

public partial class TBL_AUTORES
{
    public int AU_ID { get; set; }

    public string AU_NOMBRE_COMPLETO { get; set; } = null!;

    public DateTime? AU_FECHA_NACIMIENTO { get; set; }

    public string? AU_CIUDAD_PROCEDENCIA { get; set; }

    public string AU_EMAIL { get; set; } = null!;

    public virtual ICollection<TBL_LIBROS> TBL_LIBROS { get; } = new List<TBL_LIBROS>();
}

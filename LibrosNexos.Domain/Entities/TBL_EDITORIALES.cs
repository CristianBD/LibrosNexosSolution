using System;
using System.Collections.Generic;

namespace LibrosNexos.Domain.Entities;

public partial class TBL_EDITORIALES
{
    public int ED_ID { get; set; }

    public string ED_NOMBRE { get; set; } = null!;

    public string? ED_DIRECCION { get; set; }

    public string? ED_TELEFONO { get; set; }

    public string ED_EMAIL { get; set; } = null!;

    public int ED_MAX_LIBROS { get; set; }

    public virtual ICollection<TBL_LIBROS> TBL_LIBROS { get; } = new List<TBL_LIBROS>();
}

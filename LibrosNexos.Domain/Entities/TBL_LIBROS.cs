using System;
using System.Collections.Generic;

namespace LibrosNexos.Domain.Entities;

public partial class TBL_LIBROS
{
    public int LI_ID { get; set; }

    public string LI_TITULO { get; set; } = null!;

    public int LI_ANIO { get; set; }

    public int LI_GENERO_ID { get; set; }

    public int? LI_NUM_PAGINAS { get; set; }

    public int LI_EDITORIAL_ID { get; set; }

    public int LI_AUTOR_ID { get; set; }

    public virtual TBL_AUTORES LI_AUTOR { get; set; } = null!;

    public virtual TBL_EDITORIALES LI_EDITORIAL { get; set; } = null!;
}

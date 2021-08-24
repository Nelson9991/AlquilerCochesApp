using System;
using System.Collections.Generic;

#nullable disable

namespace AlquilerCochesApp.Models
{
    public partial class RegistroAlquiler
    {
        public int Id { get; set; }
        public string NombreCliente { get; set; }
        public DateTime? FechaAlquiler { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public decimal? CostoAlquiler { get; set; }
        public int? IdTipoAuto { get; set; }

        public virtual TipoAuto IdTipoAutoNavigation { get; set; }
    }
}

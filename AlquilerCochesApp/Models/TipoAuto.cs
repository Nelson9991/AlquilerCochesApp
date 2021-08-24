using System.Collections.Generic;

#nullable disable

namespace AlquilerCochesApp.Models
{
    public partial class TipoAuto
    {
        public TipoAuto()
        {
            RegistrosAlquiler = new HashSet<RegistroAlquiler>();
        }

        public int Id { get; set; }
        public string NombreTipo { get; set; }

        public virtual ICollection<RegistroAlquiler> RegistrosAlquiler { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Cache
{
    public class RegistroActividad
    {
        public int RegistroID { get; set; } // ID del registro de actividad
        public int UsuarioID { get; set; } // ID del usuario que realiza la actividad
        public string NombreUsuario { get; set; } // Nombre del usuario que realiza la actividad
        public string Actividad { get; set; } // Descripción de la actividad
        public DateTime FechaHora { get; set; } // Fecha y hora de la actividad
        public string DetallesActividad { get; set; } // Detalles adicionales de la actividad
        public int? CarpetaID { get; set; } // ID de la carpeta, si aplica (opcional)
        public int? DocumentoID { get; set; } // ID del documento, si aplica (opcional)
        public int? ActividadID { get; set; } // ID de la actividad, si aplica (opcional)
    }

}

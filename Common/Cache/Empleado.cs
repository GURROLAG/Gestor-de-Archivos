using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Cache
{
    public class Empleado
    {
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NumeroNomina { get; set; }
        public string Puesto { get; set; }
        public string Area { get; set; }
        public int EmpleadoID { get; set; }


        public List<string> Examenes { get; set; }
        public List<string> Capacitaciones { get; set; }
        public List<string> Certificaciones { get; set; }
        public List<string> DocumentosPersonales { get; set; }


        public Empleado()
        {
            Examenes = new List<string>();
            Capacitaciones = new List<string>();
            Certificaciones = new List<string>();
            DocumentosPersonales = new List<string>();
        }

    }

}

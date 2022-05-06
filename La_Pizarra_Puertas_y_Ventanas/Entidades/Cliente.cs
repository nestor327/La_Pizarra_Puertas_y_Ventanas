using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Pizarra_Puertas_y_Ventanas.Entidades
{
    class Cliente
    {
        public int Id_Cliente { get; set; }
        public string PNombre { get; set; }
        public string SNombre { get; set; }
        public string PApellido { get; set; }
        public string SApellido { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
    }
}

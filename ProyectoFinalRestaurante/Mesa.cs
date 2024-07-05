using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalRestaurante
{
    public class Mesa
    {
        public static int TotalMesas = 1;
        public decimal Pagar { get; set; } 
        public int NumeroMesa { get; set; } = 0;
        public string Estado { get; set; } // Libre, Reservada, Ocupada
        public string MozoEncargado { get; set; }
        public DateTime? HoraReserva { get; set; }
        public DateTime? HoraSalida { get; set; }
        public List<string> Consumos { get; set; } = new List<string>();

        public Stopwatch Stopwatch { get; set; }

       
    }

}

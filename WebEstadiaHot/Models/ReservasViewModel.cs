using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebEstadiaHot.Models
{
    public class ReservasViewModel: Acesso
    {
        public int Id_Reserva { get; set; }
        public int Id_Cliente { get; set; }
        public int Id_Quarto { get; set; }
        public string Quarto_Tipo_Descricao { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data_Reserva { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data_Entrada { get; set; }
    }
}
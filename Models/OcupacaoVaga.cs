using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacioneJa.Models
{
    public class OcupacaoVaga
    {
        public int Id { get; set; }
        public DateTime Periodo { get; set; }
        public DateTime DtInicial { get; set; }
        public DateTime DtFinal { get; set; }
    }
}
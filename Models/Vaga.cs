using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstacioneJa.Models;

namespace EstacioneJa.Models
{
    public class Vaga
    {
        public int Id { get; set; }
        public Boolean Disponibilidade { get; set; }
        public int Andar { get; set; }
        public string Secao { get; set; }
        public int Numero { get; set; }
        public string Preferencia { get; set; }
        public int Coordenada { get; set; }
        public Sensor IdSensor { get; set; }
    }
}
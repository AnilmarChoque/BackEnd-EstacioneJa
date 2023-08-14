using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace EstacioneJa.Models
{
    public class Sensor
    {
        public int Id { get; set; }
        public int VagaSensor { get; set; }
        [JsonIgnore]
        public Vaga Vaga { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
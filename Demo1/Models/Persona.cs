using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Demo1.Models
{
    public class Persona
    {   
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }        
        public int Edad { get; set; }
        public string Nacionalidad { get; set; }
        public string Profesion { get; set; }
    }
}
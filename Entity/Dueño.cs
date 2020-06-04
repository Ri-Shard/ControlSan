using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{

    public class Dueño
    {
        [Key]
        public string ID {get;set;}
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Password { get; set; }
        public string Celular { get; set; }

    }
}
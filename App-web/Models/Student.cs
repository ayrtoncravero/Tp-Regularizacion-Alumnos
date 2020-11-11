using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;
using System.Text;

namespace App_web
{
    public class Student
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo es requerido")]
        public string Name { get; set; }


        [Display(Name = "Edad")]
        [Required(ErrorMessage = "El campo es requerido")]
        [Range(17, 99, ErrorMessage = "La edad debe ser como minimo de {1}")]
        public int Age { get; set; }

        [Display(Name = "Año")]
        [Required(ErrorMessage = "El campo es requerido")]
        public int Year { get; set; }

        public Direction Direction { get; set; }

        public int? CareerId { get; set; }

        [Display(Name = "Carrera")]
        public Career Career { get; set; }
        public List<StudentMatter> StudentMatter { get; set; }

        [Display(Name = "Foto")]
        public string NamePhoto { get; set; }

    }
}

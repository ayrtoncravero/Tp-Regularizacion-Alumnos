using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App_web
{
    public class StudentMatter
    {
        [Display(Name = "Nombre de estudiante")]
        public int StudentId { get; set; }

        [Display(Name = "Materia")]
        public int MatterId { get; set; }

        [Display(Name = "Nombre de estudiante")]
        public Student Student { get; set; }


        [Display(Name = "Materia")]
        public Matter Matter { get; set; }


        [Display(Name = "Fecha de inscripcion")]
        public DateTime EnrollmentDate { get; set; }
    }
}

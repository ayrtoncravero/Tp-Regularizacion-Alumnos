using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App_web
{
    public class Career
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required]
        public string Description { get; set; }

        public List<Student> Students { get; set; }
    }
}

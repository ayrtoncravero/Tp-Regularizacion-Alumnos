using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App_web
{
    public class Matter
    {
        public int Id { get; set; }

        [Display(Name = "Materia")]
        public string Name { get; set; }
        public List<StudentMatter> StudentMatter { get; set; }
    }
}

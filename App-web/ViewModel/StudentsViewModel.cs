using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_web.ViewModel
{
    public class StudentsViewModel
    {
        public List<Student> Students { get; set; }
        public SelectList ListCareers { get; set; }
        public string textSearch { get; set; }
        public int? CareerId { get; set; }
        public Paginator Paginator { get; set; } = new Paginator();
    }

    public class Paginator
    {
        public int PageActual { get; set; }
        public int TotalRegisters { get; set; }
        public int RegistersForPages { get; set; }
        //Calculo para el total de paginas
        public int TotalPages => (int)Math.Ceiling((decimal)TotalRegisters / RegistersForPages);
    }
}

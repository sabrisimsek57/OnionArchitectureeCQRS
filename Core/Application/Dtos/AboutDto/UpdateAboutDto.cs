using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.AboutDto
{
    public class UpdateAboutDto
    {
        public int AboutID { get; set; }
        public string AboutTitle { get; set; }
        public string AboutDescription { get; set; }
        public string Aboutfeature1 { get; set; }
        public string Aboutfeature2 { get; set; }
        public string Aboutfeature3 { get; set; }
        public string Aboutfeature4 { get; set; }
        public string? AboutPhoto1 { get; set; }
        public string? AboutPhoto2 { get; set; }
    }
}

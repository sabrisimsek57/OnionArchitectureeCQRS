using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Appointment  
    {
        public int AppointmentID { get; set; }
       
        public string AppointmentNameSurname { get; set; }
        public string AppointmentMail { get; set; }
       
        public string CarType { get; set; }
        public string Message { get; set; }
        public DateTime? Date { get; set; }

        // Bu alan, Course tablosu ile ilişkilendirme için kullanılacak
        public int CourseID { get; set; }
        public Course Course { get; set; }
    }
}

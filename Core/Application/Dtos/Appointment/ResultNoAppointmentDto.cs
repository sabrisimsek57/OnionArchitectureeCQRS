﻿using Application.Dtos.CourseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Appointment
{
    public class ResultNoAppointmentDto
    {
        public int AppointmentID { get; set; }

        public string AppointmentNameSurname { get; set; }
        public string AppointmentMail { get; set; }
       
        public string CarType { get; set; }
        public string Message { get; set; }
        public DateTime? Date { get; set; }

        
    }
}

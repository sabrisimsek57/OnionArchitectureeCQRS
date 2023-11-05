using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ContactDto
{
    public class CreateContactDto
    {
      
        public string ContactNameSurname { get; set; }
        public string? ContactMail { get; set; }
        public string ContactSubject { get; set; }
        public string ContactMessage { get; set; }
    }
}

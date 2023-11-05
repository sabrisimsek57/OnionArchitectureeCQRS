using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.TeamDto
{
    public class UpdateTeamDto
    {
        public int TeamID { get; set; }
        public string TeamNameSurname { get; set; }
        public string TeamDescription { get; set; }

        public string? TeamPhoto { get; set; }
    }
}

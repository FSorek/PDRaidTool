using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDRaidTool.Models
{
    public class PlayerEntry
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int ProfessionId { get; set; }
        public int SpecialisationId { get; set; }
        public int RoleId { get; set; }
        public int Preference { get; set; }
    }
}

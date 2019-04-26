using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDRaidTool.Models;
using PDRaidTool.Utilities.Interfaces;

namespace PDRaidTool.Utilities
{
    public class DataAccess : IDataAccess
    {
        public Profession[] GetProfessions()
        {
            Profession[] temporaryData = new Profession[4]
            {
                new Profession(){Id = 0, Name = "Pro1"},
                new Profession(){Id = 1, Name = "Pro2"},
                new Profession(){Id = 2, Name = "Pro3"},
                new Profession(){Id = 3, Name = "Pro4"}
            };
            return temporaryData;
        }

        public Role[] GetRoles()
        {
            Role[] temporaryData = new Role[4]
            {
                new Role(){Id = 0, RoleName = "Role1"},
                new Role(){Id = 1, RoleName = "Role2"},
                new Role(){Id = 2, RoleName = "Role3"},
                new Role(){Id = 3, RoleName = "Role4"}
            };
            return temporaryData;
        }

        public Specialisation[] GetSpecialisations()
        {
            Specialisation[] temporaryData = new Specialisation[4]
            {
                new Specialisation(){Id = 0, Name = "Spec1"},
                new Specialisation(){Id = 1, Name = "Spec2"},
                new Specialisation(){Id = 2, Name = "Spec3"},
                new Specialisation(){Id = 3, Name = "Spec4"}
            };
            return temporaryData;
        }
    }
}

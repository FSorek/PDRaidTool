using PDRaidTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDRaidTool.Utilities.Interfaces
{
    public interface IDataAccess
    {
        Task<Role[]> GetRoles();
        Task<Profession[]> GetProfessions();
        Task<Specialisation[]> GetSpecialisations();
        Task<Player[]> GetPlayers();
    }
}

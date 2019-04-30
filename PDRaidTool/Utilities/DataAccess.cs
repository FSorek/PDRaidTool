using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PDRaidTool.Models;
using PDRaidTool.Utilities.Interfaces;

namespace PDRaidTool.Utilities
{
    public class DataAccess : IDataAccess
    {
        static HttpClient client = new HttpClient();

        public async Task<Player[]> GetPlayers()
        {
            Player[] players;
            string data = await client.GetStringAsync("http://pdraidtoolweb.azurewebsites.net/api/Players");

            players = JsonConvert.DeserializeObject<Player[]>(data);
            return players;
        }

        public async Task<Role[]> GetRoles()
        {
            Role[] roles = null;
            string data = await client.GetStringAsync("http://pdraidtoolweb.azurewebsites.net/api/Roles");

            roles = JsonConvert.DeserializeObject<Role[]>(data);
            return roles;
        }


        public async Task<Profession[]> GetProfessions()
        {
            Profession[] professions = null;
            string data = await client.GetStringAsync("http://pdraidtoolweb.azurewebsites.net/api/Professions");

            professions = JsonConvert.DeserializeObject<Profession[]>(data);
            return professions;
        }

        public async Task<Specialisation[]> GetSpecialisations()
        {
            Specialisation[] specialisations = null;
            string data = await client.GetStringAsync("http://pdraidtoolweb.azurewebsites.net/api/Specializations");

            specialisations = JsonConvert.DeserializeObject<Specialisation[]>(data);
            return specialisations;
        }
    }
}

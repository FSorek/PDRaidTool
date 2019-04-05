using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDRaidTool.Models;

namespace PDRaidTool.Utilities
{
    public class PreferenceCalculation
    {
        public void Calculate(RaidSlot[] Slots, Player[] Players, PlayerEntry[] PlayersEntries)
        {
            int[,] PreferenceMatrix = new int[Players.Length,Slots.Length];
            for (int i = 0; i < Players.Length; i++)
            {
                PlayerEntry[] PlayerEntries = (from entries in PlayersEntries
                    where entries.PlayerId == Players[i].Id
                    select entries).ToArray();
                for (int j = 0; j < Slots.Length; j++)
                {
                    PreferenceMatrix[i, j] = CreatePreference(Slots[j], PlayerEntries);
                }
            }
        }

        public int CreatePreference(RaidSlot slot, PlayerEntry[] playerEntries) // This also needs to keep track of the entry Id, to do next time
        {
            int HighestPreferenceEntryId = -1;
            
            foreach (var entry in playerEntries)
            {
                if(FitsToSlot(entry, slot))
                    if (HighestPreferenceEntryId < entry.Preference)
                        HighestPreferenceEntryId = entry.Preference;
            }

            return playerEntries[HighestPreferenceEntryId].Preference;
        }

        public bool FitsToSlot(PlayerEntry entry, RaidSlot slot)
        {
            if (entry.SpecialisationId == slot.SpecialisationId || slot.SpecialisationId == 0)
                if (entry.ProfessionId == slot.ProfessionId || slot.ProfessionId == 0)
                    if (entry.RoleId == slot.RoleId || slot.RoleId == 0)
                    {
                        return true;
                    }

            return false;
        }
    }
}

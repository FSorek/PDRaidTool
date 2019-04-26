using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDRaidTool.Models;
using PDRaidTool.Utilities.Interfaces;

namespace PDRaidTool.Utilities
{
    public class PreferenceCalculation : IPreferenceFinder
    {
        public PlayerEntry[,] CreateEntryMatrix(RaidSlot[] Slots, Player[] Players, PlayerEntry[] PlayersEntries)
        {
            PlayerEntry[,] PreferenceMatrix = new PlayerEntry[Players.Length,Slots.Length];
            for (int i = 0; i < Players.Length; i++)
            {
                PlayerEntry[] PlayerEntries = (from entries in PlayersEntries
                    where entries.PlayerId == Players[i].Id
                    select entries).ToArray();
                for (int j = 0; j < Slots.Length; j++)
                {
                    var HighestPreferenceId = FindHighestPreferenceId(Slots[j], PlayerEntries);
                    PreferenceMatrix[i, j] = HighestPreferenceId >= 0
                        ? PlayersEntries[HighestPreferenceId]
                        : new PlayerEntry(){  };

                    if (PreferenceMatrix[i, j].Preference <= 0)
                        PreferenceMatrix[i, j].Preference = 110;
                }
            }
            return PreferenceMatrix;
        }

        public int FindHighestPreferenceId(RaidSlot slot, PlayerEntry[] playerEntries)
        {
            int HighestPreferenceEntryId = 0;
            bool found = false;
            
            for(int i = 0; i < playerEntries.Length; i++)
            {
                if(FitsToSlot(playerEntries[i], slot))
                    if (playerEntries[HighestPreferenceEntryId].Preference <= playerEntries[i].Preference)
                    {
                        HighestPreferenceEntryId = playerEntries[i].Id;
                        found = true;
                    }
            }

            if (found)
                return HighestPreferenceEntryId;
            else
                return -1;
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

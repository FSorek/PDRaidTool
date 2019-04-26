using PDRaidTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDRaidTool.Utilities.Interfaces
{
    public  interface IPreferenceFinder
    {
        PlayerEntry[,] CreateEntryMatrix(RaidSlot[] Slots, Player[] Players, PlayerEntry[] PlayersEntries);
        int FindHighestPreferenceId(RaidSlot slot, PlayerEntry[] playerEntries);
        bool FitsToSlot(PlayerEntry entry, RaidSlot slot);
    }
}

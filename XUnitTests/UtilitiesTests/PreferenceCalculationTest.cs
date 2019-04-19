using PDRaidTool.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using PDRaidTool.Models;
using Xunit;
using System.Diagnostics;

namespace XUnitTests.UtilitiesTests
{
    public class PreferenceCalculationTest
    {
        RaidSlot[] slots = new RaidSlot[]
        {
            new RaidSlot(){Id = 0, ProfessionId = 1, RoleId = 1, SpecialisationId = 1},
            new RaidSlot(){Id = 1, ProfessionId = 3, RoleId = 2, SpecialisationId = 5}
        };
        Player[] players = new Player[]
        {
            new Player(){Id = 0, Nickname = "okito"}, new Player(){Id = 1, Nickname = "vi"}
        };

        RaidSlot[] slots2 = new RaidSlot[]
        {
            new RaidSlot(){Id = 0, ProfessionId = 1, RoleId = 3, SpecialisationId = 3},
            new RaidSlot(){Id = 1, ProfessionId = 0, RoleId = 1, SpecialisationId = 0}
        };
        PlayerEntry[] entries2 = new PlayerEntry[]
        {
            new PlayerEntry(){Id = 0, PlayerId = 2, Preference = 7, ProfessionId = 2, RoleId = 2, SpecialisationId = 3},
            new PlayerEntry(){Id = 1, PlayerId = 0, Preference = 5, ProfessionId = 2, RoleId = 1, SpecialisationId = 6},
            new PlayerEntry(){Id = 2, PlayerId = 0, Preference = 9, ProfessionId = 2, RoleId = 2, SpecialisationId = 5},
            new PlayerEntry(){Id = 3, PlayerId = 0, Preference = 9, ProfessionId = 1, RoleId = 3, SpecialisationId = 3},
            new PlayerEntry(){Id = 4, PlayerId = 0, Preference = 5, ProfessionId = 3, RoleId = 1, SpecialisationId = 7},

            new PlayerEntry(){Id = 5, PlayerId = 1, Preference = 9, ProfessionId = 1, RoleId = 3, SpecialisationId = 3},
            new PlayerEntry(){Id = 6, PlayerId = 1, Preference = 8, ProfessionId = 3, RoleId = 1, SpecialisationId = 7},

            new PlayerEntry(){Id = 6, PlayerId = 2, Preference = 10, ProfessionId = 1, RoleId = 1, SpecialisationId = 1},
        };


        private PreferenceCalculation preferenceCalculationClass = new PreferenceCalculation();

        [Theory]
        [InlineData(1, 2, 3, 1, 2, 3)]
        [InlineData(1, 2, 3, 0, 2, 3)]
        [InlineData(1, 2, 3, 1, 2, 0)]
        [InlineData(1, 2, 3, 1, 0, 3)]
        [InlineData(1, 2, 3, 0, 2, 0)]
        [InlineData(3, 2, 3, 0, 0, 0)]
        public void EntryFitsToSlot(int EntryProfessionId, int EntrySpecialisationId, int EntryRoleId,
                                    int SlotProfessionId, int SlotSpecialisationId, int SlotRoleId)
        {
            PlayerEntry playerEntry = new PlayerEntry()
            {
                ProfessionId = EntryProfessionId,
                SpecialisationId = EntrySpecialisationId,
                RoleId = EntryRoleId
            };
            RaidSlot slot = new RaidSlot()
            {
                ProfessionId = SlotProfessionId,
                SpecialisationId = SlotSpecialisationId,
                RoleId = SlotRoleId
            };

            Assert.True(preferenceCalculationClass.FitsToSlot(playerEntry, slot));
        }

        [Theory]
        [InlineData(1, 2, 3, 2, 2, 3)]
        [InlineData(1, 2, 3, 1, 3, 3)]
        [InlineData(1, 2, 3, 1, 2, 1)]
        [InlineData(2, 2, 3, 1, 2, 3)]
        [InlineData(1, 3, 3, 1, 2, 3)]
        [InlineData(1, 2, 1, 1, 2, 3)]
        [InlineData(1, 2, 3, 0, 1, 0)]
        public void EntryDoesntFitToSlot(int EntryProfessionId, int EntrySpecialisationId, int EntryRoleId,
                                        int SlotProfessionId, int SlotSpecialisationId, int SlotRoleId)
        {
            PlayerEntry playerEntry = new PlayerEntry()
            {
                ProfessionId = EntryProfessionId,
                SpecialisationId = EntrySpecialisationId,
                RoleId = EntryRoleId
            };
            RaidSlot slot = new RaidSlot()
            {
                ProfessionId = SlotProfessionId,
                SpecialisationId = SlotSpecialisationId,
                RoleId = SlotRoleId
            };

            Assert.False(preferenceCalculationClass.FitsToSlot(playerEntry, slot));
        }

        [Fact]
        public void FirstIdIsOne()
        {
            var matrix = preferenceCalculationClass.CreateEntryMatrix(slots2, players, entries2);
            var test = HungarianAlgorithm.FindAssignments(matrix);
            Assert.Equal(1,test[0]);
        }

        [Fact]
        public void SecondIdIsFive()
        {
            var matrix = preferenceCalculationClass.CreateEntryMatrix(slots2, players, entries2);
            var test = HungarianAlgorithm.FindAssignments(matrix);
            Assert.Equal(5, test[1]);
        }

        [Fact]
        public void FindHighestPreferenceIdFoundId()
        {
            PlayerEntry[] entries = new PlayerEntry[]
            {
                new PlayerEntry(){Id = 0, PlayerId = 1, Preference = 3, ProfessionId = 1, RoleId = 1, SpecialisationId = 1},
                new PlayerEntry(){Id = 1, PlayerId = 1, Preference = 4, ProfessionId = 1, RoleId = 1, SpecialisationId = 1},
                new PlayerEntry(){Id = 2, PlayerId = 1, Preference = 5, ProfessionId = 1, RoleId = 1, SpecialisationId = 1},
                new PlayerEntry(){Id = 3, PlayerId = 1, Preference = 6, ProfessionId = 1, RoleId = 1, SpecialisationId = 1},
                new PlayerEntry(){Id = 4, PlayerId = 1, Preference = 7, ProfessionId = 1, RoleId = 1, SpecialisationId = 1},
                new PlayerEntry(){Id = 5, PlayerId = 1, Preference = 8, ProfessionId = 1, RoleId = 1, SpecialisationId = 1},
                new PlayerEntry(){Id = 6, PlayerId = 1, Preference = 10, ProfessionId = 3, RoleId = 3, SpecialisationId = 3},
            };
            var test = preferenceCalculationClass.FindHighestPreferenceId(slots[0], entries);
            Assert.Equal(5, test);
        }

        [Fact]
        public void FindHighestPreferenceIdDidntFindId()
        {
            PlayerEntry[] entries = new PlayerEntry[]
            {
                new PlayerEntry(){Id = 0, PlayerId = 1, Preference = 3, ProfessionId = 3, RoleId = 1, SpecialisationId = 1},
                new PlayerEntry(){Id = 1, PlayerId = 1, Preference = 4, ProfessionId = 3, RoleId = 1, SpecialisationId = 1},
                new PlayerEntry(){Id = 2, PlayerId = 1, Preference = 5, ProfessionId = 3, RoleId = 1, SpecialisationId = 1},
                new PlayerEntry(){Id = 3, PlayerId = 1, Preference = 6, ProfessionId = 3, RoleId = 1, SpecialisationId = 1},
                new PlayerEntry(){Id = 4, PlayerId = 1, Preference = 7, ProfessionId = 3, RoleId = 1, SpecialisationId = 1},
                new PlayerEntry(){Id = 5, PlayerId = 1, Preference = 8, ProfessionId = 3, RoleId = 1, SpecialisationId = 1},
                new PlayerEntry(){Id = 6, PlayerId = 1, Preference = 10, ProfessionId = 3, RoleId = 3, SpecialisationId = 3},
            };
            var test = preferenceCalculationClass.FindHighestPreferenceId(slots[0], entries);
            Assert.Equal(-1, test);
        }
    }
}

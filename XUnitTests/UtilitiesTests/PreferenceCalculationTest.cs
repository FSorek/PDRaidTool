using PDRaidTool.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using PDRaidTool.Models;
using Xunit;

namespace XUnitTests.UtilitiesTests
{
    public class PreferenceCalculationTest
    {
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
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PDRaidTool.Models;
using PDRaidTool.Utilities;
using PDRaidTool.Utilities.Interfaces;
using PDRaidTool.ViewModels.Interfaces;

namespace PDRaidTool.ViewModels
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        //public RelayCommand<RaidSlot> SetRoleCommand =
        //    new RelayCommand<RaidSlot>((slot) => CommandSetRole(slot.Id, slot.RoleId));
        public ObservableCollection<Role> RolesCollection { get; set; }
        public ObservableCollection<Profession> ProfessionsCollection { get; set; }
        public ObservableCollection<Specialisation> SpecialisationsCollection { get; set; }
        public ObservableCollection<Player> PlayersCollection { get; set; }



        private Role selectedRole;
        public Role SelectedRole
        {
            get
            {
                return selectedRole;
            }
            set
            {
                selectedRole = value;
                RaisePropertyChanged("SelectedRole");
            }
        }

        private Profession selectedProfession;
        public Profession SelectedProfession
        {
            get { return selectedProfession; }
            set
            {
                RaisePropertyChanged(() => SelectedProfession);
                selectedProfession = value;
            }
        }

        private Specialisation selectedSpecialisation;
        public Specialisation SelectedSpecialisation
        {
            get { return selectedSpecialisation; }
            set
            {
                RaisePropertyChanged(() => SelectedSpecialisation);
                selectedSpecialisation = value;
            }
        }

        private Player selectedPlayer;
        public Player SelectedPlayer
        {
            get
            {
                return selectedPlayer;
            }
            set
            {
                selectedPlayer = value;
                RaisePropertyChanged("SelectedPlayer");
            }
        }
        public int SlotCount { get; set; }

        private PlayerEntry[] PlayerEntries;
        private RaidSlot[] RaidSlots;
        private Player[] Players;

        private IPreferenceFinder preferenceFinder;
        public MainViewModel(IPreferenceFinder preferenceFinder, IDataAccess dataAccess)
        {
            this.preferenceFinder = preferenceFinder;
            this.OnRoleChangedCommand = new RelayCommand<int>((obj) => this.ExecuteOnRoleChangedCommand(obj));
            this.OnProfessionChangedCommand = new RelayCommand<int>((obj) => this.ExecuteOnProfessionChangedCommand(obj));
            this.OnSpecialisationChangedCommand = new RelayCommand<int>((obj) => this.ExecuteOnSpecialisationChangedCommand(obj));
            this.OnPlayerChangedCommand = new RelayCommand<string>((obj) => this.ExecuteOnPlayerChangedCommand(obj));


            RolesCollection = new ObservableCollection<Role>(dataAccess.GetRoles());
            ProfessionsCollection = new ObservableCollection<Profession>(dataAccess.GetProfessions());
            SpecialisationsCollection = new ObservableCollection<Specialisation>(dataAccess.GetSpecialisations());
            PlayersCollection = new ObservableCollection<Player>(dataAccess.GetPlayers());


            RaidSlots = new RaidSlot[10]; // SlotCount
            Players = new Player[10]; // SlotCount
        }

        public void FindCompositionCommand()
        {
            var matrix = preferenceFinder.CreateEntryMatrix(RaidSlots, Players, GetPlayerEntries());
            var result = matrix.FindAssignments();
        }

        private PlayerEntry[] GetPlayerEntries()
        {
            /// PlayerEntries = from database where database.playerId equals PlayersCollection[i] 
            /// 
            ///  
            throw new NotImplementedException();
        }

        public RelayCommand<int> OnRoleChangedCommand { get; set; }
        public RelayCommand<int> OnProfessionChangedCommand { get; set; }
        public RelayCommand<int> OnSpecialisationChangedCommand { get; set; }
        public RelayCommand<string> OnPlayerChangedCommand { get; set; }
        
        public void ExecuteOnRoleChangedCommand(int slot)
        {
            if(RaidSlots[slot] == null)
                RaidSlots[slot] = new RaidSlot();
            RaidSlots[slot].RoleId = selectedRole.Id;
        }
        public void ExecuteOnProfessionChangedCommand(int slot)
        {
            if (RaidSlots[slot] == null)
                RaidSlots[slot] = new RaidSlot();
            RaidSlots[slot].ProfessionId = selectedProfession.Id;
        }
        public void ExecuteOnSpecialisationChangedCommand(int slot)
        {
            if (RaidSlots[slot] == null)
                RaidSlots[slot] = new RaidSlot();
            RaidSlots[slot].SpecialisationId = selectedSpecialisation.Id;
        }
        public void ExecuteOnPlayerChangedCommand(string idString)
        {
            int slot = Int32.Parse(idString);
            if (Players[slot] == null)
                Players[slot] = new Player();
            Players[slot].Id = selectedPlayer.Id;
        }
    }
}
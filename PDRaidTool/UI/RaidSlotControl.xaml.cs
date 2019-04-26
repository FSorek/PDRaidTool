using PDRaidTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PDRaidTool.ViewModels.Interfaces;

namespace PDRaidTool.UI
{
    /// <summary>
    /// Interaction logic for RaidSlotControl.xaml
    /// </summary>
    public partial class RaidSlotControl : UserControl
    {
        public RaidSlotControl()
        {
            InitializeComponent();
        }

        private int slotId { get; set; }

        public int SlotId
        {
            get { return (int)slotId; }
            set { this.SetValue(SlotIdProperty, value); }
        }
        public static readonly DependencyProperty SlotIdProperty = DependencyProperty.Register(
            "SlotId", typeof(int), typeof(RaidSlotControl), new PropertyMetadata(-1));
    }
}

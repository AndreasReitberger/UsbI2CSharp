using System.Windows.Controls;
using UsbI2cControlPanel.ViewModels;

namespace UsbI2cControlPanel.Views
{
    /// <summary>
    /// Interaktionslogik für ControlPanelView.xaml
    /// </summary>
    public partial class ControlPanelView : UserControl
    {
        private readonly ControlPanelViewModel _viewModel = new ControlPanelViewModel();
        public ControlPanelView()
        {
            InitializeComponent();
            DataContext = _viewModel;
        }
    }
}

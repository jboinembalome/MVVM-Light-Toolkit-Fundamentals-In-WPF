using PlugIn1.ViewModel;

namespace PlugIn1
{
    public partial class PlugInControl1
    {
        public PlugInControl1()
        {
            InitializeComponent();
            PartialPanel.DataContext = new PartialViewModel();
        }
    }
}

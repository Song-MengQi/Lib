using System.Windows.Controls;
using System.Windows.Input;

namespace Lib.UI
{
    public partial class CloseButton : UserControl
    {
        public CloseButton()
        {
            InitializeComponent();
        }
        private void CloseButton_MouseEnter(object sender, MouseEventArgs e)
        {
            Background = System.Windows.Media.Brushes.Red;
        }
        private void CloseButton_MouseLeave(object sender, MouseEventArgs e)
        {
            Background = System.Windows.Media.Brushes.Transparent;
        }
    }
}

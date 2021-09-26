using System.Windows.Controls;
using System.Windows.Input;

namespace Lib.UI
{
    public partial class MaximizeButton : UserControl
    {
        public MaximizeButton()
        {
            InitializeComponent();
        }
        private void MaximizeButton_MouseEnter(object sender, MouseEventArgs e)
        {
            Background = System.Windows.Media.Brushes.Green;
        }
        private void MaximizeButton_MouseLeave(object sender, MouseEventArgs e)
        {
            Background = System.Windows.Media.Brushes.Transparent;
        }
    }
}
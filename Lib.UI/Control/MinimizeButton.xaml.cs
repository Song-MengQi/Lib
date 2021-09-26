using System.Windows.Controls;
using System.Windows.Input;

namespace Lib.UI
{
    public partial class MinimizeButton : UserControl
    {
        public MinimizeButton()
        {
            InitializeComponent();
        }
        private void MinimizeButton_MouseEnter(object sender, MouseEventArgs e)
        {
            Background = System.Windows.Media.Brushes.DarkOrange;
        }
        private void MinimizeButton_MouseLeave(object sender, MouseEventArgs e)
        {
            Background = System.Windows.Media.Brushes.Transparent;
        }
    }
}
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Lib.UI
{
    public partial class To : UserControl
    {
        //public Brush Fill
        //{
        //    get => Polygon.Fill;
        //    set => Polygon.Fill = value;
        //}
        private Brush fill;
        public Brush Fill
        {
            get { return fill; }
            set {
                fill = value;
                Line1.Stroke = fill;
                Line2.Stroke = fill;
            }
        }
        public double Angle
        {
            get { return RotateTransform.Angle; }
            set { RotateTransform.Angle = value; }
        }
        public Direction Direction
        {
            get { return DirectionExtends.ToDirection(Angle); }
            set { Angle = value.ToAngle(); }
        }
        public To()
        {
            InitializeComponent();
        }
        private void To_MouseEnter(object sender, MouseEventArgs e) { Grid.Visibility = Visibility.Visible; }
        private void To_MouseLeave(object sender, MouseEventArgs e) { Grid.Visibility = Visibility.Hidden; }
    }
}

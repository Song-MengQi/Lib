using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lib.UI
{
    [System.ComponentModel.DesignTimeVisible(false)]//在工具箱中隐藏
    public partial class GridPicker : UserControl
    {
        public int Index
        {
            get
            {
                return Array.FindIndex(radioButtons, radioButton=>(bool)radioButton.IsChecked);
            }
            set
            {
                if (false == MathExtends.InRangeCloseOpen(value, 0, radioButtons.Length)) return;
                radioButtons[value].IsChecked = true;
            }
        }
        public string TitleText
        {
            get { return TitleTextBlock.Text; }
            set { TitleTextBlock.Text = value; }
        }
        public Action CallbackAction { get; set; }
        private RadioButton[] radioButtons;
        public GridPicker(int row, int col)
        {
            InitializeComponent();
            int length = row * col;
            if (length == 0) return;

            for (int i = 0; i<row; ++i)
            {
                Grid.RowDefinitions.Add(new RowDefinition());
            }
            for (int j = 0; j<col; ++j)
            {
                Grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            int bit = (int)Math.Log10(length) + 1;
            string indexStringFormat = "D" + bit;
            radioButtons = new RadioButton[length];
            string groupName = new Random().Next().ToString();
            for (int i = 0; i < row; ++i)
            {
                for (int j = 0; j<col; ++j)
                {
                    int index = i*col+j;
                    RadioButton radioButton = new RadioButton {
                        GroupName = groupName,
                        Content = index.ToString(indexStringFormat),
                    };
                    Grid.SetRow(radioButton, i);
                    Grid.SetColumn(radioButton, j);
                    Grid.Children.Add(radioButton);
                    radioButtons[index] = radioButton;
                }
            }
        }
        private void Grid_Click(object sender, RoutedEventArgs e)
        {
            ActionExtends.Invoke(CallbackAction);
        }
        private void TitleGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ActionExtends.Invoke(CallbackAction);
        }
    }
}
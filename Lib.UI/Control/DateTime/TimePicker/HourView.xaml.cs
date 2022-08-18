using System;
using System.Windows;
using System.Windows.Controls;

namespace Lib.UI
{
    [System.ComponentModel.DesignTimeVisible(false)]//在工具箱中隐藏
    public partial class HourView : UserControl
    {
        #region DataGridRecord
        private class DataGridRecord
        {
            public int C0 { get; set; }
            public int C1 { get; set; }
            public int C2 { get; set; }
            public int C3 { get; set; }
            public int C4 { get; set; }
            public int C5 { get; set; }
            public int C6 { get; set; }
        }
        private DataGridRecord GetDataGridRecord(int c)
        {
            return new DataGridRecord {
                C0 = c++,
                C1 = c++,
                C2 = c++,
                C3 = c++,
                C4 = c++,
                C5 = c++,
                C6 = c++,
            };
        }
        #endregion
        public Action<string> Action;
        public string HourWord
        {
            get { return CancelButton.Content as string; }
            set { CancelButton.Content = value; }
        }
        public string Hour { get; set; }//TODO::
        public HourView()
        {
            InitializeComponent();
            DataGrid.ItemsSource = new DataGridRecord[] {
                GetDataGridRecord(0),
                GetDataGridRecord(6),
                GetDataGridRecord(12),
                GetDataGridRecord(18),
            };
        }
        private string oldStr = string.Empty;
        public HourView(string str)
            : this()
        {          
            this.oldStr = str;
        }

        private void DataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataGridCellInfo cell = DataGrid.CurrentCell;
            if (cell.Column == null) return;
            DataGridRecord min = cell.Item as DataGridRecord;

            string str = string.Empty;
            switch (cell.Column.DisplayIndex)
            {
                case 0:
                    str = min.C0.ToString();
                    break;
                case 1:
                    str = min.C1.ToString();
                    break;
                case 2:
                    str = min.C2.ToString();
                    break;
                case 3:
                    str = min.C3.ToString();
                    break;
                case 4:
                    str = min.C4.ToString();
                    break;
                case 5:
                    str = min.C5.ToString();
                    break;
                case 6:
                    str = min.C6.ToString();
                    break;
                default:
                    break;
            }
            str = str.PadLeft(2, '0');
            ActionExtends.Invoke(Action, str);
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ActionExtends.Invoke(Action, oldStr);
        }
    }
}
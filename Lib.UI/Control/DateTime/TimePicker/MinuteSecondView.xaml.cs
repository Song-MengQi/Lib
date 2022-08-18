using System;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace Lib.UI
{
    [System.ComponentModel.DesignTimeVisible(false)]//在工具箱中隐藏
    public partial class MinuteSecondView : UserControl
    {
        //DataGrid.SelectedItem
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
            public int C7 { get; set; }
            public int C8 { get; set; }
            public int C9 { get; set; }
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
                C7 = c++,
                C8 = c++,
                C9 = c++,
            };
        }
        #endregion
        public int Data
        {
            get
            {
                DataGridCellInfo cell = DataGrid.CurrentCell;
                if (cell.Column == null) return default(int);
                DataGridRecord record = cell.Item as DataGridRecord;
                switch (cell.Column.DisplayIndex)
                {
                    case 0:
                        return record.C0;
                    case 1:
                        return record.C1;
                    case 2:
                        return record.C2;
                    case 3:
                        return record.C3;
                    case 4:
                        return record.C4;
                    case 5:
                        return record.C5;
                    case 6:
                        return record.C6;
                    case 7:
                        return record.C7;
                    case 8:
                        return record.C8;
                    case 9:
                        return record.C9;
                    default:
                        return default(int);
                }
            }
            set
            {

                foreach (DataGridRecord record in (DataGrid.ItemsSource as DataGridRecord[]))
                {
                    if (record.C0 == value)
                    {
                        DataGrid.SelectedIndex = 3;
                    }
                }
                //(DataGrid.ItemsSource as DataGridRecord[]).Single(record=>record.);
            }
        }
        public Action CallbackAction;
        public string MinuteSecondWord
        {
            get { return CancelButton.Content as string; }
            set { CancelButton.Content = value; }
        }
        public MinuteSecondView()
        {
            InitializeComponent();
            DataGrid.ItemsSource = new DataGridRecord[] {
                GetDataGridRecord(0),
                GetDataGridRecord(10),
                GetDataGridRecord(20),
                GetDataGridRecord(30),
                GetDataGridRecord(40),
                GetDataGridRecord(50),
            };
            DataGrid.SelectedIndex = 3;
        }
        private void DataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            ActionExtends.Invoke(CallbackAction);
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ActionExtends.Invoke(CallbackAction);
        }
    }
}

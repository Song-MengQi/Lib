//using System;
//using System.Windows;
//using System.Windows.Controls;

//namespace Lib.UI
//{
//    [System.ComponentModel.DesignTimeVisible(false)]//在工具箱中隐藏
//    public partial class DataGridCellPicker : UserControl
//    {
//        #region DataGridRecord
//        #region DataGrid6
//        private class DataGrid6
//        {
//            public int C0 { get; set; }
//            public int C1 { get; set; }
//            public int C2 { get; set; }
//            public int C3 { get; set; }
//            public int C4 { get; set; }
//            public int C5 { get; set; }
//        }
//        private DataGrid6 GetDataGrid6(ref int i)
//        {
//            return new DataGrid6 {
//                C0 = i++,
//                C1 = i++,
//                C2 = i++,
//                C3 = i++,
//                C4 = i++,
//                C5 = i++,
//            };
//        }
//        private DataGrid6[] GetDataGrid6s()
//        {
//            int i = 0;
//            return new DataGrid6[] {
//                GetDataGrid6(ref i),
//                GetDataGrid6(ref i),
//                GetDataGrid6(ref i),
//                GetDataGrid6(ref i),
//            };
//        }
//        #endregion
//        #region DataGrid10
//        private class DataGrid10
//        {
//            public int C0 { get; set; }
//            public int C1 { get; set; }
//            public int C2 { get; set; }
//            public int C3 { get; set; }
//            public int C4 { get; set; }
//            public int C5 { get; set; }
//            public int C6 { get; set; }
//            public int C7 { get; set; }
//            public int C8 { get; set; }
//            public int C9 { get; set; }
//        }
//        private DataGrid10 GetDataGrid10(ref int i)
//        {
//            return new DataGrid10 {
//                C0 = i++,
//                C1 = i++,
//                C2 = i++,
//                C3 = i++,
//                C4 = i++,
//                C5 = i++,
//                C6 = i++,
//                C7 = i++,
//                C8 = i++,
//                C9 = i++,
//            };
//        }
//        private DataGrid10[] GetDataGrid10s()
//        {
//            int i = 0;
//            return new DataGrid10[] {
//                GetDataGrid10(ref i),
//                GetDataGrid10(ref i),
//                GetDataGrid10(ref i),
//                GetDataGrid10(ref i),
//                GetDataGrid10(ref i),
//                GetDataGrid10(ref i),
//            };
//        }
//        #endregion
//        #endregion
//        public int Hour
//        {
//            get
//            {
//                DataGridCellInfo cell = DataGrid.CurrentCell;
//                if (cell.Column == null) return default(int);
//                DataGrid6 record = cell.Item as DataGrid6;
//                switch (cell.Column.DisplayIndex)
//                {
//                    case 0:
//                        return record.C0;
//                    case 1:
//                        return record.C1;
//                    case 2:
//                        return record.C2;
//                    case 3:
//                        return record.C3;
//                    case 4:
//                        return record.C4;
//                    case 5:
//                        return record.C5;
//                    default:
//                        return default(int);
//                }
//            }
//            set
//            {
//                DataGrid.GetCell(value / 6, value % 6).IsSelected = true;
//            }
//        }
//        public string HourWord
//        {
//            get { return CancelButton.Content as string; }
//            set { CancelButton.Content = value; }
//        }
//        public Action CallbackAction { get; set; }
//        public DataGridCellPicker(int row, int col)
//        {
//            InitializeComponent();
//            DataGrid.ItemsSource = GetDataGrid6s();
//        }
//        //private void DataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
//        //{
//        //    ActionExtends.Invoke(CallbackAction);
//        //}
//        private void CancelButton_Click(object sender, RoutedEventArgs e)
//        {
//            ActionExtends.Invoke(CallbackAction);
//        }
//        private void DataGridCell_Selected(object sender, RoutedEventArgs e)
//        {
//            ActionExtends.Invoke(CallbackAction);
//        }
//    }
//}
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Lib.UI
{
    public static class DataGridExtend
    {
        public static DataGridRow GetRow(this DataGrid dataGrid, int index)
        {
            return ObjectExtends.DefaultThen(
                (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(index),
                ()=>{
                    dataGrid.UpdateLayout();
                    dataGrid.ScrollIntoView(dataGrid.Items[index]);
                    return (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(index);    
                });
        }
        public static DataGridCell GetCell(this DataGrid dataGrid, int rowIndex, int columnIndex)
        {
            return dataGrid.GetCell(dataGrid.GetRow(rowIndex), columnIndex);
        }
        public static DataGridCell GetCell(this DataGrid dataGrid, DataGridRow dataGridRow, int column)
        {
            if (ObjectExtends.EqualsDefault(dataGridRow)) return default(DataGridCell);

            DataGridCellsPresenter dataGridCellsPresenter = ObjectExtends.DefaultThen(
                dataGridRow.GetVisualChild<DataGridCellsPresenter>(),
                ()=>{
                    dataGrid.ScrollIntoView(dataGridRow, dataGrid.Columns[column]);
                    return dataGridRow.GetVisualChild<DataGridCellsPresenter>();
                });
            if (ObjectExtends.EqualsDefault(dataGridCellsPresenter)) return default(DataGridCell);

            return (DataGridCell)dataGridCellsPresenter.ItemContainerGenerator.ContainerFromIndex(column);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Amnesia.Views;
using Amnesia.Core;
using System.Globalization;

namespace Amnesia
{

    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DBLayer connectLayer = new DBLayer();

            dgTask.DataContext = connectLayer.getAllRows();           
        }

        private void btnNewTask_Click(object sender, RoutedEventArgs e)
        {
            TaskWindow task = new TaskWindow();

            task.Show();

            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridRow row;
            int completedColumnIndex = 2;
            int testColumnIndex = 3;
            int aprovedColumnIndex = 4;

            for (int i = 0; i < dgTask.Items.Count; i++)
            {
                row  = dgTask.ItemContainerGenerator.ContainerFromItem(dgTask.Items[i]) as DataGridRow;

                TaskColumnColorSet(row, completedColumnIndex);
                TaskColumnColorSet(row, testColumnIndex);
                TaskColumnColorSet(row, aprovedColumnIndex);
            }
        }

        private void TaskColumnColorSet(DataGridRow row, int columnIndex)
        {
            DataGridCell cell = dgTask.Columns[columnIndex].GetCellContent(row).Parent as DataGridCell;
            TextBlock content = cell.Content as TextBlock;

            if (content.Text.Equals("verde"))
            {
                content.Text = string.Empty;
                cell.Background = Brushes.LightGreen;
            }
            else if (content.Text.Equals("rojo"))
            {
                content.Text = string.Empty;
                cell.Background = Brushes.Red;
            }
        }
    }
}

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

    public class ValueColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var str = value as string;
            if (str == null) return null;

            int intValue;
            if (!int.TryParse(str, out intValue)) return null;

            if (intValue <= 1) return Brushes.Red;
            else if (intValue <= 2) return Brushes.Yellow;
            else return Brushes.Green;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
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
            //TaskWindow task = new TaskWindow();

            //task.Show();

            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridRow row = dgTask.ItemContainerGenerator.ContainerFromItem(dgTask.Items[0]) as DataGridRow;
            DataGridCell cell = dgTask.Columns[2].GetCellContent(row).Parent as DataGridCell;

            TextBlock content = cell.Content as TextBlock;

            if (content.Text.Equals("verde"))
                cell.Background = Brushes.LightGreen;
        }
    }
}

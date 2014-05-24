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
using System.Windows.Shapes;
using Amnesia.Clases;

namespace Amnesia.Views
{
    /// <summary>
    /// Lógica de interacción para TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {
        public TaskWindow()
        {
            InitializeComponent();
        }

        private void btnCompleted_Click(object sender, RoutedEventArgs e)
        {
            if (Buttons.Completed)
            {
                Buttons.Completed = true;
            }
            
        }

        private void btnAproved_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

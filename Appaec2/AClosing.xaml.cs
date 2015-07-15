using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Appaec2
{
    /// <summary>
    /// AClosing.xaml 的交互逻辑
    /// </summary>
    public partial class AClosing : Page
    {
        public AClosing()
        {
            InitializeComponent();

            Duration duration = new Duration(TimeSpan.FromSeconds(5));
            DoubleAnimation doubleanimation = new DoubleAnimation(200.0, duration);
            pb.BeginAnimation(ProgressBar.ValueProperty, doubleanimation);


        }

        private void exit_button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void pb_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //if (pb.Value == 100.0)
            if (!AStatic.IsRunning)
            {
                pb.Value = 100.0;
                exit_button.IsEnabled = true;
            }
        }




        
    }
}

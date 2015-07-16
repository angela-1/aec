//  Closing page.
//	Copyright(C) 2015 hez0rs <hez0rs@163.com>
//
//	This program is free software : you can redistribute it and / or modify
//	it under the terms of the GNU General Public License as published by
//	the Free Software Foundation, either version 3 of the License, or
//	(at your option) any later version.
//
//	This program is distributed in the hope that it will be useful,
//	but WITHOUT ANY WARRANTY; without even the implied warranty of
//	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//	GNU General Public License for more details.
//
//	You should have received a copy of the GNU General Public License
//	along with this program.If not, see < http://www.gnu.org/licenses/>.



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

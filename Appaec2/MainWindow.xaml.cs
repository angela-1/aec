//  Main frame of program.
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
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Appaec2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Application.Current.Properties["mainwindow"] = this;

            main_frame.Navigate(new Uri("AHome.xaml", UriKind.Relative));

        }



        public void SetTitle(string title)
        {
            title_label.Content = title;

        }


        private void close_button_Click(object sender, RoutedEventArgs e)
        {

            //Application.Current.Shutdown();

            main_frame.Navigate(new Uri("AClosing.xaml", UriKind.Relative));

            close_button.IsEnabled = false;
            min_button.IsEnabled = false;

            AUtils t = new AUtils();
            //t.WaitingEncrypt();

            Thread ec = new Thread(t.WaitingEncrypt);
            ec.Start();

            //Application.Current.Shutdown();

        }

        private void min_button_Click(object sender, RoutedEventArgs e)
        {
           WindowState = WindowState.Minimized;
        }





        private void titleborder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // 获取鼠标相对标题栏位置
            Point position = e.GetPosition(titleborder);

            // 如果鼠标位置在标题栏内，允许拖动
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (position.X >= 0 && position.X < titleborder.ActualWidth && position.Y >= 0 && position.Y < titleborder.ActualHeight)
                {
                    DragMove();
                }
            }
        }


    }
}

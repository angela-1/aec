//  Settings page.
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
//	along with this program.If not, see < http://www.gnu.org/licenses/>.\


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
    /// AConfig.xaml 的交互逻辑
    /// </summary>
    public partial class AConfig : Page
    {
        public AConfig()
        {
            InitializeComponent();

            ShowInit();

            InitUi();
        }


        private void InitUi()
        {
            MainWindow m = Application.Current.Properties["mainwindow"] as MainWindow;
            m.SetTitle(FindResource("StrUid_config") as string);
        }


        private void ShowInit()
        {
            init_radioButton.IsChecked = true;
            frame.Navigate(new Uri("BInit.xaml", UriKind.Relative));
        }


        private void init_radioButton_Checked(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("BInit.xaml", UriKind.Relative));

        }

        private void password_radioButton_Checked(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("BPass.xaml", UriKind.Relative));

        }

        private void export_radioButton_Checked(object sender, RoutedEventArgs e)
        {

            frame.Navigate(new Uri("BExport.xaml", UriKind.Relative));

        }

        private void lang_radioButton_Checked(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("BLang.xaml", UriKind.Relative));

        }

        private void about_radioButton_Checked(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("BAbout.xaml", UriKind.Relative));

        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new Uri("AHome.xaml", UriKind.Relative));
        }
    }
}

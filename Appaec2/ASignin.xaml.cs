//  Signin page.
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
    /// ASignin.xaml 的交互逻辑
    /// </summary>
    public partial class ASignin : Page
    {
        public ASignin()
        {
            InitializeComponent();
            key_textBox.Focus();

            InitUi();
        }


        private void InitUi()
        {
            MainWindow m = Application.Current.Properties["mainwindow"] as MainWindow;
            m.SetTitle(FindResource("StrUid_signin") as string);
        }

        private void signin_button_Click(object sender, RoutedEventArgs e)
        {
            AUtils t = new AUtils();
            AEncrypter encrypter = new AEncrypter();
            encrypter.ReadKeyFile();
            
            AStatic.StringKey = key_textBox.Text;
            if (encrypter.ValidKey(AStatic.StringKey))
            {

                if (encrypter.DecryptFile(AStatic.DbPath))
                {
                    AStatic.IsRunning = true;
                    t.ReadCatalog();

                    NavigationService.Navigate(new Uri("AHome.xaml", UriKind.Relative));

                }
                 
              
            }
            else
            {
                signinlabel.Content = FindResource("StrUid_wrongkey").ToString();
            }

            

        }







        private void key_textBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                signin_button_Click(null, null);
               

                //textBlock.Text = "search selected.";
            }
        }

        private void key_textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            signinlabel.Content = "";
        }
    }
}

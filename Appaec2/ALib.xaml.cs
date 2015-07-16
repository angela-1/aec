//  Show all the accounts page.
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
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// ALibrary.xaml 的交互逻辑
    /// </summary>
    public partial class ALib : Page
    {
        public ALib()
        {
            InitializeComponent();
            listBox.AddHandler(UIElement.MouseDownEvent, new MouseButtonEventHandler(listBoxItem_Click), true);

        }


        
        private void listBoxItem_Click(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show(listBox.SelectedItem, "see");

            if (listBox.Items.Count > 0 && listBox.SelectedIndex > -1)
            {
                ALibModel lm = listBox.SelectedItem as ALibModel;
                string searchStr = lm.Tag;
                AResult result = new AResult(searchStr);
                
                Window m = Application.Current.Properties["mainwindow"] as Window;
                Frame main_frame = m.FindName("main_frame") as Frame;
                main_frame.Navigate(result);

            }

  
        }








        private void char_button_Click(object sender, RoutedEventArgs e)
        {
            // pinyin c
            string let = (e.Source as Button).Content as string;
            
            ALibViewModel vm = listBox.DataContext as ALibViewModel;
            if (vm.Pydic.ContainsKey(let.ToLower()))
            {
                int idc = vm.Pydic[let.ToLower()];
        
                listBox.ScrollIntoView(listBox.Items[idc]);
            }
            



        }


    }
}

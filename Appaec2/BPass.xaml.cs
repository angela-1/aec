﻿//  Modify password page.
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
    /// BPass.xaml 的交互逻辑
    /// </summary>
    public partial class BPass : Page
    {
        public BPass()
        {
            InitializeComponent();
        }

        private void done_button_Click(object sender, RoutedEventArgs e)
        {
      
            AEncrypter encrypter = new AEncrypter();
            if (encrypter.ValidKey(oldkey_textBox.Text))
            {
                if (newkey_textBox.Text == confirm_textBox.Text)
                {
                    AStatic.StringKey = newkey_textBox.Text;
                    encrypter.WriteKeyFile(newkey_textBox.Text);
                    encrypter.ReadKeyFile();
                    
                }
                else
                {
                    tiptextblock.Text = FindResource("StrUid_newkeynotequal").ToString();
                }
                
            }
            else
            {
                tiptextblock.Text = FindResource("StrUid_oldkeywrong").ToString();
            }









        }
    }
}

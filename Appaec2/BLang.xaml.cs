//  Language setting page.
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
    /// BLang.xaml 的交互逻辑
    /// </summary>
    public partial class BLang : Page
    {

        private Dictionary<int, string> dic;

        public BLang()
        {
            dic = new Dictionary<int, string>()
            {
                {0, "zh-CN"},
                {1, "en-US"}
            };

            InitializeComponent();

            comboBox.SelectedIndex = GetLangIndex();
            
        }

        private int GetLangIndex()
        {
            foreach (var item in dic)
            {
                if (item.Value == AStatic.Lang)
                {
                    return item.Key;
                }
            }
            return 0;


        }


        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string chooselang = dic[comboBox.SelectedIndex];

            if (chooselang != AStatic.Lang)
            {
                AStatic.Lang = chooselang;
                AUtils t = new AUtils();
                t.ChooseLang(chooselang);
                t.WriteLang();
            }
           
            


           


        }


    }
}

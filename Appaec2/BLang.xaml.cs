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

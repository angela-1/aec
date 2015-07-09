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
    /// AConfirm.xaml 的交互逻辑
    /// </summary>
    public partial class AConfirm : Page
    {

        private string tag;

        public AConfirm()
        {
            InitializeComponent();
        }

        public AConfirm(string t)
        {
            
            tag = t;
            InitializeComponent();

            account_textBlock.Text = t;
        }


        public int DelFromDb(string t)
        {
            string sql = "delete from accounts where tag='" + t + "'";
            ADbInteractive db = new ADbInteractive(AStatic.DbPath);
            return db.ExecQuery(sql, null);

        }

        private void good_button_Click(object sender, RoutedEventArgs e)
        {
            
            DelFromDb(tag);
            
            AUtils tool = new AUtils();
            tool.ReadCatalog();
            NavigationService.Navigate(new AHome());
        }

        private void cancel_button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AHome());
        }


 



    }
}

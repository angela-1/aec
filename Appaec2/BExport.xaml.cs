




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
    /// BExport.xaml 的交互逻辑
    /// </summary>
    public partial class BExport : Page
    {
        private string exporttype;
        public BExport()
        {
            InitializeComponent();
        }

        private void radioButton_Checked(object sender, RoutedEventArgs e)
        {

            RadioButton choose = e.Source as RadioButton;
            exporttype = choose.Content.ToString();


        }


       


        private void button_Click(object sender, RoutedEventArgs e)
        {
     
            BExporter exporter = new BExporter();

            string fname = exporter.GetSaveFilePath(exporttype);

            if (fname != null)
            {
                exporter.Export(exporttype, fname);
            }

            
        }
    }
}

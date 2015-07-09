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

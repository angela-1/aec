using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Appaec2
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Startup += App_Startup;

        }

        /// <summary>
        /// 程序启动后即读取配置文件config.ini
        /// 获取数据库的文件路径和语言设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void App_Startup(object sender, StartupEventArgs e)
        {
            AUtils t = new AUtils();
            t.ReadDbpath();
            t.ReadLang();
            t.ChooseLang(AStatic.Lang);

            
        }
    }
}

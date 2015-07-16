//  Datacontext of library.
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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Appaec2
{
    class ALibViewModel : INotifyPropertyChanged
    {


        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyChange(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }


        private Dictionary<string, int> pydic;

        public Dictionary<string, int> Pydic
        {
            get
            {
                return pydic;
            }
            set
            {
                pydic = value;
                
            }
        }

        private ObservableCollection<ALibModel> accountlist;
        public ObservableCollection<ALibModel> Accountlist
        {
            get
            {
                return accountlist;
            }
            set
            {
                accountlist = value;
                NotifyChange("Accountlist");
            }
        }

        

        public ALibViewModel()
        {
            pydic = new Dictionary<string, int>();

            int i = -1;
            accountlist = new ObservableCollection<ALibModel>();
            if (AStatic.Catalog != null)
            {
                foreach (var item in AStatic.Catalog)
                {
                    accountlist.Add(item);
                    i++;
                    Regex regex = new Regex("[0-9]{1}");

                    if (regex.IsMatch(item.Pyindex) && !pydic.ContainsKey("#"))
                    {
                        pydic.Add("#", 0);
                    }
                    else if (!pydic.ContainsKey(item.Pyindex.Substring(0,1)))
                    {
                        pydic.Add(item.Pyindex.Substring(0,1), i);
                    }


                }
            }
            
        }




    }
}

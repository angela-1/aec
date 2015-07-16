//  Model of library list.
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

namespace Appaec2
{
    class ALibModel
    {
        private string tag;
        public string Tag
        {
            get
            {
                return tag;
            }
            set
            {
                tag = value;
            }
        }
        private string category;
        public string Category
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
            }
        }


        private string pyindex;
        public string Pyindex
        {
            get
            {
                return pyindex;
            }
            set
            {
                pyindex = value;
            }
        }

        private string pyfspell;
        public string Pyfspell
        {
            get
            {
                return pyfspell;
            }
            set
            {
                pyfspell = value;
            }
        }

        public ALibModel()
        {

        }


        public ALibModel(string t, string c, string py, string pyf)
        {
            tag = t;
            category = c;
            pyindex = py;
            pyfspell = pyf;
        }


    }
}

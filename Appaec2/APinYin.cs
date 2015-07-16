//  Pinyin module.
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
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Text.RegularExpressions;


namespace Appaec2
{
    class APinYin
    {

        private string pyfile = "share\\pydic.txt";


        public APinYin()
        {

        }


        public string GetPyStr(string str, Boolean isfullspell)
        {
            int len = str.Length;
            string pyStr = "";

            for (int i = 0; i < len; i++)
            {
                pyStr += GetPyChar(str.Substring(i, 1), isfullspell);

            }
            return pyStr;
        }


        private string GetPyChar(string ch, Boolean isfullspell)
        {
            string result = ch;
            string buf;
            if (File.Exists(pyfile))
            {
                using (StreamReader sr = new StreamReader(pyfile))
                {
                    while ((buf = sr.ReadLine()) != null)
                    {
                        if (ch == buf.Split(' ')[0])
                        {
                            string pyChar = buf.Split(' ')[1].Trim();
                            result = isfullspell ? pyChar : pyChar.Substring(0, 1);
                        }

                    }

                }


            }

            return result;
        }


    }
}
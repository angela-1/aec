//  Encrypt module.
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
using System.Runtime.InteropServices;

namespace Appaec2
{
    class AEncrypter
    {
        private static int AES_LEN = 16;


        private Byte[] src;
        private Byte[] dst;
        private Byte[] key;
        
        public AEncrypter()
        {

        }



        [DllImport("libencrypt.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int digest_md5(string buf, byte[] md);

        [DllImport("libencrypt.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int encrypt(byte[] src, byte[] dst, int len, byte[] key);

        [DllImport("libencrypt.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int decrypt(byte[] src, byte[] dst, int len, byte[] key);



        private Byte[] ReadBinFile(string fname, int len)
        {
            Byte[] rb = new Byte[len];
            if (File.Exists(fname))
            {
                FileStream fs = new FileStream(fname, FileMode.Open);
                BinaryReader br = new BinaryReader(fs);
                rb = br.ReadBytes(len);
                br.Close();
                fs.Close();
            }

            return rb;
        }


        private void WriteBinFile(string fname, Byte[] bin)
        {
            FileStream fs = new FileStream(fname, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(bin);
            bw.Close();
            fs.Close();

        }


        public int ReadKeyFile()
        {
            if (File.Exists(AStatic.KeyPath))
            {
                AStatic.EncryptKey = ReadBinFile(AStatic.KeyPath, AES_LEN);
                return 0;
            }
            else
            {
                return -1;
            }
            

        }



        public void WriteKeyFile(string keystring)
        {
            Byte[] ek = new Byte[AES_LEN];
            digest_md5(keystring, ek);

            WriteBinFile(AStatic.KeyPath, ek);

        }




        private void PasswordToKey(string str, Byte[] key)
        {
            if (str.Length > AES_LEN)
            {
                str = str.Substring(0, AES_LEN);
            }
            key = Encoding.UTF8.GetBytes(str);

        }


        public Boolean ValidKey(string keystring)
        {
            Byte[] ek = new Byte[AES_LEN];
            digest_md5(keystring, ek);

            for (int i = 0; i < AES_LEN; i++)
            {
                if (AStatic.EncryptKey[i] != ek[i])
                {
                    return false;
                }
            }
            return true;

        }



        public void EncryptFile(string fname)
        {
            string resultfile = fname + "s";

            int len;


            FileInfo fileInfo = new FileInfo(fname);
            len = (int)fileInfo.Length;


            key = new Byte[AES_LEN];
            dst = new Byte[len];
            PasswordToKey(AStatic.StringKey, key);


            src = ReadBinFile(fname, len);
            encrypt(src, dst, len, key);

            WriteBinFile(resultfile, dst);


            File.Delete(fname);




        }

        public Boolean DecryptFile(string fname)
        {
            string resultfile = fname + "s";

            int len;

            FileInfo fileInfo = new FileInfo(resultfile);
            len = (int)fileInfo.Length;

            key = new Byte[AES_LEN];
            dst = new Byte[len];
            PasswordToKey(AStatic.StringKey, key);

            src = ReadBinFile(resultfile, len);
            decrypt(src, dst, len, key);

            WriteBinFile(fname, dst);

            return File.Exists(fname);


        }



    }
}
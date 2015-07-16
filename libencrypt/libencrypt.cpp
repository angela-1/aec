//  libencrypt.cpp : 定义 DLL 应用程序的导出函数。
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


#include "stdafx.h"




#include "libencrypt.h"


#pragma comment(lib, "libeay32.lib")



int digest_md5(char *buf, uchar *md)
{
	MD5_CTX ctx;
	MD5_Init(&ctx);
	MD5_Update(&ctx, buf, strlen(buf));
	MD5_Final(md, &ctx);
	return (sizeof(md));
}





int encrypt(uchar *src, uchar *dst, uint len, uchar *key)
{
	AES_KEY aes;
	uchar iv[AES_BLOCK_SIZE];        // init vector

	uint i;



	for (i = 0; i < AES_BLOCK_SIZE; ++i) {
		iv[i] = 0;
	}
	if (AES_set_encrypt_key(key, 128, &aes) < 0) {
		fprintf(stderr, "Unable to set encryption key in AES\n");
		exit(-1);
	}


	// encrypt (iv will change)
	AES_cbc_encrypt(src, dst, len, &aes, iv, AES_ENCRYPT);

	return len;

}


int decrypt(uchar *src, uchar *dst, uint len, uchar *key)
{
	AES_KEY aes;
	uchar iv[AES_BLOCK_SIZE];        // init vector

	uint i;

	for (i = 0; i < AES_BLOCK_SIZE; ++i) {
		iv[i] = 0;
	}
	if (AES_set_decrypt_key(key, 128, &aes) < 0) {
		fprintf(stderr, "Unable to set decryption key in AES\n");
		exit(-1);
	}


	// decrypt 
	AES_cbc_encrypt(src, dst, len, &aes, iv,
		AES_DECRYPT);

	return len;


}

//  The encrypt library get from OpenSSL.
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




#ifndef _CRYPTO_H
#define _CRYPTO_H


#include <stdio.h>
#include <stdlib.h>



#include "aes.h"
#include "md5.h"

typedef unsigned char uchar;
typedef unsigned int uint;


extern "C" __declspec(dllexport) int digest_md5(char *buf, uchar *md);


extern "C" __declspec(dllexport) int encrypt(uchar *src, uchar *dst, uint len, uchar *key);
extern "C" __declspec(dllexport) int decrypt(uchar *src, uchar *dst, uint len, uchar *key);

















#endif /* _CRYPTO_H*/ 

/* Header of encrypt module. */



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

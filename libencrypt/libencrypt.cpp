

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

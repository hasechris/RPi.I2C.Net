#include <stdio.h>
#include <linux/i2c-dev.h>
#include <fcntl.h>
#include <string.h>
#include <sys/ioctl.h>
#include <unistd.h>
#include <errno.h>
#include "libNativeI2C.h"


int openBus (char* busFileName)
{
	return open (busFileName, O_RDWR);
}

int closeBus (int busHandle)
{
	return close (busHandle);
}

int writeBytes (int busHandle, int addr, byte* buf, int len)
{
	if (ioctl (busHandle, I2C_SLAVE, addr) < 0)
		return -1;

	if (write (busHandle, buf, len) != len)
		return -2;

	return len;
}

int readBytes (int busHandle, int addr, byte* buf, int len)
{
	if (ioctl (busHandle, I2C_SLAVE, addr) < 0)
		return -1;

	int n= read (busHandle, buf, len);

	return n;
}

int write_word_read_byte(int busHandle, int addr, byte* bytes,int len, byte* buf, int len, int* res_write, int* res_read)
{
	if (ioctl(busHandle, I2C_SLAVE, addr) < 0)
	{
		return res_write = -1;
	}

	if (write(busHandle, bytes, len) != len)
	{
		res_write = -2;
	}else {
		res_write = len;
	}
	res_read = read(busHandle, buf, len);
}

#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include <fcntl.h>
#include <linux/i2c-dev.h>
#include <sys/ioctl.h>
#include <stdint.h>
#include <stddef.h>
#include <math.h>

#define InterruptStatusRegister 0x00
#define InterruptEnableRegister 0x01
#define ConfigurationRegister 0x02
#define LuxHighByteRegister 0x03
#define LuxLowByteRegister 0x04
#define UpperThresholdHighByteRegister 0x05
#define LowerThresholdHighByteRegister 0x06
#define ThresholdTimerRegister 0x07

struct max44009_dev {
	int fd;
};

int max44009_create(struct max44009_dev* sensor, const char* device, int address) {
	int fd;
	if ((fd = open(device, O_RDWR)) < 0) {
		return fd;
	}

	if (ioctl(fd, I2C_SLAVE, address) < 0) {
		close(fd);
		return -1;
	}
	sensor->fd = fd;
	return 0;
}

static int8_t user_i2c_read(int fd, uint8_t reg_addr, uint8_t* data, uint16_t len)
{
	if (write(fd, &reg_addr, 1) != 1) {
		return -1;
	}
	return read(fd, data, len);
}

static int8_t user_i2c_write(int fd, uint8_t reg_addr, uint8_t* data, uint16_t len)
{
	int8_t* buf;

	buf = malloc(len + 1);
	buf[0] = reg_addr;
	memcpy(buf + 1, data, len);
	int result = write(fd, buf, len + 1);
	free(buf);
	if (result != len + 1) {
		return -1;
	}
	else {
		return len;
	}
}

int8_t max44009_reset(struct max44009_dev* sensor) {
	char registers[] = { 0x00, 0x03, 0xff, 0x00, 0xff };
	int8_t result = user_i2c_write(sensor->fd, InterruptEnableRegister, registers, 2);
	if (result < 0) {
		return result;
	}

	//result = user_i2c_write(sensor->fd, UpperThresholdHighByteRegister, registers + 2, 3);
	//if (result < 0) {
	//	return result;
	//}

	return 0;
}

int8_t max44009_read(struct max44009_dev* sensor, float* luminance) {
	char data[2];
	if (user_i2c_read(sensor->fd, LuxHighByteRegister, data, 2) != 2) {
		return -1;
	}
	int exponent = (data[0] & 0xF0) >> 4;
	int mantissa = ((data[0] & 0x0F) << 4) | (data[1] & 0x0F);
	*luminance = pow(2, exponent) * mantissa * 0.045;
	return 0;
}


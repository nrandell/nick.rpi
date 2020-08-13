#include "bme280.h"
#include <string.h>
#include <fcntl.h>
#include <stdlib.h>
#include <unistd.h>
#include <linux/i2c-dev.h>
#include <sys/ioctl.h>

struct identifier {
	uint8_t dev_addr;
	int8_t fd;
};

static void user_delay_us(uint32_t period, void* intf_ptr)
{
	usleep(period);
}

static BME280_INTF_RET_TYPE user_i2c_read(uint8_t reg_addr, uint8_t* reg_data, uint32_t len, void* intf_ptr)
{
	struct identifier* id = (struct identifier*)intf_ptr;

	write(id->fd, &reg_addr, 1);
	read(id->fd, reg_data, len);

	return 0;
}

static BME280_INTF_RET_TYPE user_i2c_write(uint8_t reg_addr, const uint8_t* reg_data, uint32_t len, void* intf_ptr)
{
	struct identifier* id = (struct identifier*)intf_ptr;

	int8_t* buf;

	buf = malloc(len + 1);
	buf[0] = reg_addr;
	memcpy(buf + 1, reg_data, len);
	uint32_t status = write(id->fd, buf, len + 1);
	free(buf);

	if (status < len) {
		return BME280_E_COMM_FAIL;
	}
	return BME280_OK;
}

int bme280_create(struct bme280_dev* sensor, const char* device, int address)
{
	int fd;
	if ((fd = open(device, O_RDWR)) < 0)
	{
		return fd;
	}

	if (ioctl(fd, I2C_SLAVE, address) < 0)
	{
		close(fd);
		return -1;
	}

	struct identifier* identifier = malloc(sizeof(struct identifier));
	identifier->fd = fd;
	identifier->dev_addr = (uint8_t)address;

	sensor->intf_ptr = identifier;
	sensor->intf = BME280_I2C_INTF;
	sensor->read = user_i2c_read;
	sensor->write = user_i2c_write;
	sensor->delay_us = user_delay_us;

	return bme280_init(sensor);
}

int bme280_delete(struct bme280_dev* sensor)
{
	struct identifier* id = (struct identifier*)sensor->intf_ptr;
	int fd = id->fd;
	free(id);
	return close(fd);
}

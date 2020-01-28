#include "bme680.h"
#include "bme680_selftest.h"
#include <string.h>
#include <fcntl.h>
#include <stdlib.h>
#include <unistd.h>
#include <linux/i2c-dev.h>
#include <sys/ioctl.h>

static void user_delay_ms(uint32_t period)
{
    usleep(period * 1000);
}

static int8_t user_i2c_read(uint8_t id, uint8_t reg_addr, uint8_t *data, uint16_t len)
{
    int fd = (int)id;
    write(fd, &reg_addr, 1);
    read(fd, data, len);

    return 0;
}

static int8_t user_i2c_write(uint8_t id, uint8_t reg_addr, uint8_t *data, uint16_t len)
{
    int fd = (int)id;
    int8_t *buf;

    buf = malloc(len + 1);
    buf[0] = reg_addr;
    memcpy(buf + 1, data, len);
    if (write(fd, buf, len + 1) < len)
        return BME680_E_COM_FAIL;
    free(buf);
    return BME680_OK;
}

int bme680_create(struct bme680_dev* sensor, const char *device, int address)
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

    sensor->dev_id = (uint8_t)fd;
    sensor->intf = BME680_I2C_INTF;
    sensor->read = user_i2c_read;
    sensor->write = user_i2c_write;
    sensor->delay_ms = user_delay_ms;

    return bme680_init(sensor);
}

int bme680_delete(struct bme680_dev *sensor)
{
    int fd = (int)sensor->dev_id;
    return close(fd);
}

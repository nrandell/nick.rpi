all: libbme280.so

CFLAGS = -fPIC -shared

libbme280.so: bme280.o bme280_selftest.o wrapper.o
	$(CC) $(CFLAGS) $^ -o $@

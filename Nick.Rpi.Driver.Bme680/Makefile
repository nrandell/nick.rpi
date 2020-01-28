all: libbme680.so

CFLAGS = -fPIC -shared

libbme680.so: bme680.o bme680_selftest.o wrapper.o
	$(CC) $(CFLAGS) $^ -o $@

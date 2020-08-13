all: libbme680.so

CFLAGS = -fPIC -shared -Wall -Werror

libbme680.so: bme680.o bme680_selftest.o wrapper.o
	$(CC) $(CFLAGS) $^ -o $@

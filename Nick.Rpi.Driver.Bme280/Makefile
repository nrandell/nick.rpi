all: libbme280.so

CFLAGS = -fPIC -shared -Wall -Werror

libbme280.so: bme280.o wrapper.o
	$(CC) $(CFLAGS) $^ -o $@

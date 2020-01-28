all: libmax44009.so

CFLAGS = -fPIC -shared

libmax44009.so: wrapper.o
	$(CC) $(CFLAGS) $^ -o $@

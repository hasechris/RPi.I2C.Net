Note
====
All Credits and Copyrights under the MIT License to Max!!

This library is originally from Max Shmelev, you can find it [here](https://github.com/mshmelev/RPi.I2C.Net).
I copied it to change and put some new things in it. Max seems to ignore push requests,
a user made a change in his library and Max hasn't imported it in his repo since 2012.

If you have a change, feel free to make a pull request. I try to keep this library tidy and clean =)

### RPi.I2C.Net
We have two parts in this repo. Code and examples are in the 
    repo wiki

### 1. Native I2C C library
Located under [LibNativeI2C/src](https://github.com/hasechris/RPi.I2C.Net/tree/master/LibNativeI2C/src)

You have to compile this on your *unix box for yourself. Sorry :(

### 2. Wrapper for C# Programs
This is the more interesting part of this repo.
This library, which is coded in Visual Studio 2013, is like a wrapper for the C functions in the Native I2C library, so you can use the c functions in C# projects. *YAAY*


All parts are provided as sourcefiles, so you can use them in your next C# project.

Everything down below here is copied from Max's repo for integrity.

#######################################################################################
#######################################################################################

I2C library on C# for Raspberry Pi. About connecting Arduino and Raspberry Pi read this blog posts: [hardware part](http://blog.mshmelev.com/2013/06/connecting-raspberry-pi-and-arduino.html) and [software part](http://blog.mshmelev.com/2013/06/connecting-raspberry-pi-and-arduino-software.html).

### Description
The library provides basic read/write functionality with I2C-devices for Mono v. 2.10.x.
It uses device files exposed by the I2C kernel drivers in Arch Linux.

### Preparations
1. Update your system to get I2C kernel drivers. For Arch Linux:
```bash
$ pacman -Syu
```

2. Load I2C kernel module. You can do
```bash
$ modprobe i2c-dev
```
Or if you want to load the module automatically on boot add `i2c-dev` to `/etc/modules/`. If you're on Arch Linux create file `/etc/modules-load.d/i2c.conf` and add `i2c-dev` to the file.

### Library Usage
1. The RPi.I2C.Net library requires a native-C library [libnativei2c.so](https://github.com/mshmelev/RPi.I2C.Net/blob/master/Lib/LibNativeI2C/libnativei2c.so), which is a part of this project.
   * It's precompiled for Arch Linux. If you need to compile it, run `make` from `Lib/LibNativeI2C/src`.
   * Put `libnativei2c.so` to `/usr/lib/` or to the same folder where `RPi.I2C.Net.dll` is located.
2. Create `I2CBus` instance with `I2CBus.Open()`. The function accepts path to an I2C device file, which is `"/dev/i2c-0"` for RPi rev.1 and `"/dev/i2c-1"` for RPi rev.2 by default.
3. Use `I2CBus.WriteBytes()` or `I2CBus.ReadBytes()`.

```C#
using (var bus = RPi.I2C.Net.I2CBus.Open("/dev/i2c-1"))
{
	bus.WriteByte(42, 77);
}
```


### Performance
The performance testing was done using:
* Raspberry Pi, Rev.2, not overclocked
* Arduino Uno

####Writing
Sending 3-byte packets to Arduino.
Results: **1428 transactions per second** (4284 Bytes/s)

####Reading
Reading 3-byte packets from Arduino.
Results: **1660 transactions per second** (4980 Bytes/s)

####Reading and Writing
Sending 3-byte packet to Arduino and reading back the respose 3-byte packet.
Results: **830 transactions per second** (4980 Bytes/s total)

### License
The project uses [MIT license](https://github.com/hasechris/RPi.I2C.Net/blob/master/License.md): do whatever you want wherever you want it.

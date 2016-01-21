using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var bus = RPi.I2C.Net.I2CBus.Open("/dev/i2c-1"))
			{
				// bus.WriteByte(42, 96);
				// byte[] res = bus.ReadBytes(42, 3);
                ushort dev_address = 0x50;

                byte[] result = bus.write_word_read_byte(dev_address, 0x00, 0x00);

                Console.WriteLine(String.Format("Gelesenes Byte: '{0}'", result));
                
			}
		}
	}
}

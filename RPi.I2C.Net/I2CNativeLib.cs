using System.Runtime.InteropServices;

namespace RPi.I2C.Net
{
	internal static class I2CNativeLib
	{
		[DllImport("libnativei2c.so", EntryPoint = "openBus", SetLastError = true)]
		public static extern int OpenBus(string busFileName);

		[DllImport("libnativei2c.so", EntryPoint = "closeBus", SetLastError = true)]
		public static extern int CloseBus(int busHandle);

		[DllImport("libnativei2c.so", EntryPoint = "readBytes", SetLastError = true)]
		public static extern int ReadBytes(int busHandle, int addr, byte[] buf, int len);

		[DllImport("libnativei2c.so", EntryPoint = "writeBytes", SetLastError = true)]
		public static extern int WriteBytes(int busHandle, int addr, byte[] buf, int len);

        
        // new functions for Adafruit FRAM breakout board
        [DllImport("libnativei2c.so", EntryPoint = "write_word_read_byte", SetLastError = true)]        
        public static extern int write_word_read_byte(int busHandle, int addr, byte byte_msb, byte byte_lsb, byte result, int len);

        [DllImport("libnativei2c.so", EntryPoint = "write_word_read_byte_repeated", SetLastError = true)]
        public static extern int write_word_read_byte_repeated(int busHandle, int addr, byte byte_msb, byte byte_lsb, int len);

        [DllImport("libnativei2c.so", EntryPoint = "fram_write_byte", SetLastError = true)]
        public static extern int fram_write_byte(int busHandle, int addr, byte[] buf, int len);

        [DllImport("libnativei2c.so", EntryPoint = "fram_random_read_byte", SetLastError = true)]
        public static extern int fram_read_byte(int busHandle, int addr, byte[] buf, int len);
	}
}
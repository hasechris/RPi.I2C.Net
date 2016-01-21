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
        [DllImport("libnativei2c.so", SetLastError = true)]
        public static extern int write_word_read_byte(int busHandle, int addr, byte[] bytes, int write_len, byte[] read_buf, int read_len, int res_write, int res_read);
	}
}
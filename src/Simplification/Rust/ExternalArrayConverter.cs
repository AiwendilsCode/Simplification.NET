using System.Runtime.InteropServices;

namespace Simplification.Rust
{
    internal class ExternalArrayConverter : IDisposable
    {
        private IntPtr allocatedMemory = IntPtr.Zero;
        public ExternalArray ExternalArray { get; init; }

        public ExternalArrayConverter(double[][] data)
        {
            ExternalArray = ToExternalArray(data);
        }

        private ExternalArray ToExternalArray(double[][] data)
        {
            try
            {
                allocatedMemory = Marshal.AllocHGlobal(data.Length * 2 * sizeof(double));

                int offset = 0;

                for (int i = 0; i < data.Length; i++)
                {
                    for (int j = 0; j < data[i].Length; j++)
                    {
                        byte[] bytes = BitConverter.GetBytes(data[i][j]);

                        for (int k = 0; k < bytes.Length; k++)
                        {
                            Marshal.WriteByte(allocatedMemory + offset++, bytes[k]);
                        }
                    }
                }

                return new() { data = allocatedMemory, len = (UIntPtr)data.Length };
            }
            catch (Exception ex) 
            {
                Dispose();
                throw ex;
            }
        }

        public static double[][] ToDoubleArray(ExternalArray array)
        {
            var outputArray = new double[array.len][];

            var buffer = new byte[8];
            int offset = 0;

            for (int i = 0; i < outputArray.Length; i++)
            {
                outputArray[i] = new double[2];

                for (int j = 0; j < 2; j++)
                {
                    buffer[0] = Marshal.ReadByte(array.data, offset++);
                    buffer[1] = Marshal.ReadByte(array.data, offset++);
                    buffer[2] = Marshal.ReadByte(array.data, offset++);
                    buffer[3] = Marshal.ReadByte(array.data, offset++);
                    buffer[4] = Marshal.ReadByte(array.data, offset++);
                    buffer[5] = Marshal.ReadByte(array.data, offset++);
                    buffer[6] = Marshal.ReadByte(array.data, offset++);
                    buffer[7] = Marshal.ReadByte(array.data, offset++);

                    outputArray[i][j] = BitConverter.ToDouble(buffer, 0);
                }
            }

            return outputArray;
        }

        public static UIntPtr[] ToUIntPtrArray(ExternalArray array)
        {
            var outputArray = new UIntPtr[array.len];
            int offset = 0;

            for (int i = 0; i < outputArray.Length; i++)
            {
                switch (UIntPtr.Size)
                {
                    case 4: // 32-bit
                        outputArray[i] = (UIntPtr)Marshal.ReadInt32(array.data, offset);
                        offset += 4;
                        break;
                    case 8: // 64-bit
                        outputArray[i] = (UIntPtr)Marshal.ReadInt64(array.data, offset);
                        offset += 8;
                        break;
                }
            }

            return outputArray;
        }

        public void Dispose()
        {
            if (allocatedMemory != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(allocatedMemory);
                allocatedMemory = IntPtr.Zero;
            }
        }
    }
}

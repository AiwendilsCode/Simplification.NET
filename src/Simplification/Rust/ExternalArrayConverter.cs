using System.Diagnostics;
using System.Drawing;
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
            int dataLengthInBytes = data.Length * 2 * sizeof(double);
            allocatedMemory = Marshal.AllocHGlobal(dataLengthInBytes);

            var arrayToCopyFrom = new byte[dataLengthInBytes];
            int indexInByteArray = 0;

            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    byte[] bytes = BitConverter.GetBytes(data[i][j]);

                    for (int k = 0; k < bytes.Length; k++)
                    {
                        arrayToCopyFrom[indexInByteArray++] = bytes[k];
                    }
                }
            }

            Marshal.Copy(arrayToCopyFrom, 0, allocatedMemory, dataLengthInBytes);

            return new() { data = allocatedMemory, len = (UIntPtr)data.Length };
        }

        public static double[][] ToDoubleArray(ExternalArray array)
        {
            var outputByteArray = new byte[array.len * 2 * sizeof(double)];
            Marshal.Copy(array.data, outputByteArray, 0, outputByteArray.Length);

            var outputArray = new double[array.len][];
            int indexInByteArray = 0;

            for (int i = 0; i < outputArray.Length; i++)
            {
                outputArray[i] = new double[2];

                for (int j = 0; j < 2; j++)
                {
                    double coord = BitConverter.ToDouble(
                        outputByteArray[indexInByteArray..(indexInByteArray + sizeof(double))], 0);
                    indexInByteArray += sizeof(double);

                    outputArray[i][j] = coord;
                }
            }

            return outputArray;
        }

        public static UIntPtr[] ToUIntPtrArray(ExternalArray array)
        {
            int sizeOfUIntPtr = UIntPtr.Size;
            var outputByteArray = new byte[(long)array.len * sizeOfUIntPtr];
            Marshal.Copy(array.data, outputByteArray, 0, outputByteArray.Length);

            var outputArray = new UIntPtr[array.len];
            int indexInByteArray = 0;

            for (int i = 0; i < outputArray.Length; i++)
            {
                outputArray[i] = sizeOfUIntPtr switch
                {
                    4 => (UIntPtr)BitConverter.ToUInt32( // 32-bit
                        outputByteArray[indexInByteArray..(indexInByteArray + 4)], 0),
                    8 => (UIntPtr)BitConverter.ToUInt64( // 64-bit
                        outputByteArray[indexInByteArray..(indexInByteArray + 8)], 0)
                };

                indexInByteArray += sizeOfUIntPtr;
            }

            return outputArray;
        }

        public void Dispose()
        {
            if (allocatedMemory != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(allocatedMemory);
            }
        }
    }
}

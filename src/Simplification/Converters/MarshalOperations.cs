using System.Runtime.InteropServices;
using System.Text.Json;

namespace Simplification.Converters
{
    internal class MarshalOperations
    {
        public static nint CopyDataFromFloatJaggedArrayToIntPtr(float[][] jaggedArray)
        {
            int length = jaggedArray.Length;

            double[] joinedArray = jaggedArray.Select(coords =>
            {
                var x = BitConverter.GetBytes(coords[0]);
                var y = BitConverter.GetBytes(coords[1]);
                return BitConverter.ToDouble([..x, ..y], 0);
            }).ToArray();

            nint arrayPtr = Marshal.AllocHGlobal(jaggedArray.Length * sizeof(double));

            Marshal.Copy(joinedArray, 0, arrayPtr, joinedArray.Length);

            return arrayPtr;
        }

        public static float[][] CopyDataFromIntPtrToFloatJaggedArray(nint ptr, int length, int innerLength = 2)
        {
            float[][] jaggedArray = new float[length][];

            for (int i = 0; i < length; i++)
            {
                byte[] x = new byte[4];
                byte[] y = new byte[4];

                Marshal.Copy(ptr + (i * 8), x, 0, 4);
                Marshal.Copy(ptr + (i * 8 + 4), y, 0, 4);

                jaggedArray[i] = [BitConverter.ToSingle(x), BitConverter.ToSingle(y)];
            }

            return jaggedArray;
        }

        public static void FreeIntPtr(nint ptr, int length)
        {
            for (int i = 0; i < length; i++)
            {
                nint innerPtr = Marshal.ReadIntPtr(ptr, i * nint.Size);
                Marshal.FreeHGlobal(innerPtr);
            }

            Marshal.FreeHGlobal(ptr);
        }
    }
}

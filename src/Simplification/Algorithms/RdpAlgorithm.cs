using Simplification.Converters;
using Simplification.Rust;

namespace Simplification.Algorithms
{
    public class RdpAlgorithm : ISimplificationAlgorithm
    {
        public static float[][] Simplify(float[][] data, double tolerance)
        {
            FfiArray? dataInArray = null;
            FfiArray? simplified = null;

            try
            {
                nint dataForSimplification = MarshalOperations.CopyDataFromFloatJaggedArrayToIntPtr(data);

                dataInArray = new FfiArray()
                {
                    data = dataForSimplification,
                    len = (nuint)data.Length
                };

                simplified = RustBindings.simplify_rdp_ffi((FfiArray)dataInArray, tolerance);

                float[][] result = MarshalOperations.CopyDataFromIntPtrToFloatJaggedArray(((FfiArray)simplified).data, (int)((FfiArray)simplified).len);

                return result;
            }
            finally
            {

                if (dataInArray is not null)
                    MarshalOperations.FreeIntPtr(((FfiArray)dataInArray).data, (int)((FfiArray)dataInArray).len);

                if (simplified is not null)
                    RustBindings.drop_float_array((FfiArray)simplified!);

                Console.WriteLine("memory freed");
            }
        }
    }
}

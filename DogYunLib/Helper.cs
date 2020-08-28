namespace DogYun
{
    internal class Helper
    {
        internal static void CheckCvmId(int id)
        {
            if (!id.IsValidCvmId()) throw new InvalidCvmIdException();
        }
    }
}

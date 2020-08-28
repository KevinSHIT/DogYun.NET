namespace DogYun.Model
{
    internal class Configuration
    {
        internal static string ApiKey { get; set; }

        internal static int CvmId { get; set; }

        internal static int Timeout { get; set; } = 10000;
    }
}

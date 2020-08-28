using DogYun.Model;
using DogYun.Net;

using System.Collections.Specialized;

namespace DogYun
{
    public class System
    {
        public bool Reinstall(int vmId, int image, string hostname = "")
        {
            Helper.CheckCvmId(vmId);
            return Http.Put(
                $"https://api.dogyun.com/cvm/server/{vmId}/reinstall",
                new NameValueCollection
                {
                    { "image"   , $"{image}" },
                    { "hostname", hostname }
                },
                Configuration.Timeout)
                .IsSuccess();
        }

        public bool Renstall(int image, string hostname) => Reinstall(Configuration.CvmId, image, hostname);
    }
}

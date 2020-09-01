using DogYun.Model;
using DogYun.Net;

using System.Collections.Specialized;

namespace DogYun
{
    public class System
    {
        /// <summary>
        /// Reinstall you CVM.
        /// </summary>
        /// <param name="vmId"></param>
        /// <param name="image"></param>
        /// <param name="hostname"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Reinstall you default CVM.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="hostname"></param>
        /// <returns></returns>
        public bool Renstall(int image, string hostname) => Reinstall(Configuration.CvmId, image, hostname);
    }
}

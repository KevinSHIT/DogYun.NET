using DogYun.Model;
using DogYun.Net;

using System.Collections.Specialized;

namespace DogYun
{
    public class Iso
    {
        /// <summary>
        /// Unmount ISO.
        /// </summary>
        /// <param name="vmId"></param>
        /// <returns></returns>
        public bool Unmount(int vmId)
        {
            Helper.CheckCvmId(vmId);
            return Http.Put($"https://api.dogyun.com/cvm/server/{vmId}/cdrom/unmount", Configuration.Timeout).IsSuccess();
        }

        /// <summary>
        /// Unmount ISO of default CVM.
        /// </summary>
        /// <returns></returns>
        public bool Unount() => Unmount(Configuration.CvmId);

        /// <summary>
        /// Mount ISO to default CVM.
        /// </summary>
        /// <param name="isoNum"></param>
        /// <returns></returns>
        public bool Mount(int isoNum) => Mount(Configuration.CvmId, isoNum);

        /// <summary>
        /// Mount ISO.
        /// </summary>
        /// <param name="vmId"></param>
        /// <param name="isoNum"></param>
        /// <returns></returns>
        public bool Mount(int vmId, int isoNum)
        {
            Helper.CheckCvmId(vmId);
            var data = new NameValueCollection();
            data.Add("iso", isoNum.ToString());
            return Http.Put($"https://api.dogyun.com/cvm/server/{vmId}/cdrom/unmount", data, Configuration.Timeout).IsSuccess();
        }
    }
}

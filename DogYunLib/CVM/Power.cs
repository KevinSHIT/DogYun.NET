using DogYun.Model;
using DogYun.Net;

namespace DogYun
{
    public class Power
    {
        private bool PowerHelper(int vmId, string operation)
        {
            Helper.CheckCvmId(vmId);
            return Http.Put($"https://api.dogyun.com/cvm/server/{vmId}/power/{operation}", Configuration.Timeout).IsSuccess();
        }

        /// <summary>
        /// Start your CVM.
        /// </summary>
        /// <param name="vmId"></param>
        /// <returns></returns>
        public bool Start(int vmId) => PowerHelper(vmId, "start");

        /// <summary>
        /// Stop your CVM.
        /// </summary>
        /// <param name="vmId"></param>
        /// <returns></returns>
        public bool Stop(int vmId) => PowerHelper(vmId, "stop");

        /// <summary>
        /// Reset your CVM.
        /// </summary>
        /// <param name="vmId"></param>
        /// <returns></returns>
        public bool Reset(int vmId) => PowerHelper(vmId, "reset");

        /// <summary>
        /// Start your default CVM.
        /// </summary>
        /// <returns></returns>
        public bool Start() => PowerHelper(Configuration.CvmId, "start");

        /// <summary>
        /// Stop your default CVM.
        /// </summary>
        /// <returns></returns>
        public bool Stop() => PowerHelper(Configuration.CvmId, "stop");

        /// <summary>
        /// Reset your defalut CVM.
        /// </summary>
        /// <returns></returns>
        public bool Reset() => PowerHelper(Configuration.CvmId, "reset");
    }
}

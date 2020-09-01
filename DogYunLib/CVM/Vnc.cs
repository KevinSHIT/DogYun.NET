using DogYun.Model;
using DogYun.Net;

using Newtonsoft.Json.Linq;

namespace DogYun
{
    public class Vnc
    {
        /// <summary>
        /// Get CVM's VNC info
        /// </summary>
        /// <param name="vmId"></param>
        /// <returns></returns>
        public VncStruct? GetInfo(int vmId)
        {
            Helper.CheckCvmId(vmId);
            var jo = Http.Get($"https://api.dogyun.com/cvm/server/{vmId}/vnc", Configuration.Timeout).ToJObject();
            if (!jo.IsSuccess()) return null;
            jo = jo["data"] as JObject;
            return new VncStruct()
            {
                Host = jo["host"].ToString(),
                Path = jo["path"].ToString(),
                Password = jo["password"].ToString()
            };
        }

        /// <summary>
        /// Get default CVM's VNC info
        /// </summary>
        /// <returns></returns>
        public VncStruct? GetInfo() => GetInfo(Configuration.CvmId);
    }
}

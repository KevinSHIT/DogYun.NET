using DogYun.Model;
using DogYun.Net;

using Newtonsoft.Json.Linq;

namespace DogYun
{
    public class Vnc
    {
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

        public VncStruct? GetInfo() => GetInfo(Configuration.CvmId);
    }
}

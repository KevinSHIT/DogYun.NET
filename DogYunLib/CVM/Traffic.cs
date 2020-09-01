using Newtonsoft.Json.Linq;

using System.Collections.Generic;

namespace DogYun
{
    public class Traffic
    {
        public List<Model.TrafficStruct> GetCvmTraffic(int vmId)
        {
            Helper.CheckCvmId(vmId);
            var x = Net.Http.Get(
                $"https://api.dogyun.com/cvm/server/{vmId}/traffic",
                Model.Configuration.Timeout
                ).ToJObject();

            if (!x.IsSuccess()) return null;

            var ja = x["data"] as JArray;
            var l = new List<Model.TrafficStruct>();
            foreach (JObject jo in ja)
            {
                l.Add(GetTraffic(jo));
            }
            return l;
        }

        public Dictionary<int, List<Model.TrafficStruct>> GetCvmTrafficList(int vmId)
        {
            Helper.CheckCvmId(vmId);
            var x = Net.Http.Get(
                $"https://api.dogyun.com/cvm/server/traffic",
                Model.Configuration.Timeout
                ).ToJObject();

            if (!x.IsSuccess()) return null;

            var d = new Dictionary<int, List<Model.TrafficStruct>>();
            var jo = x["data"] as JObject;
            foreach(var kv in jo)
            {
                var l = new List<Model.TrafficStruct>();
                foreach (JObject joo in kv.Value as JArray)
                {
                    l.Add(GetTraffic(joo));
                }
                d.Add(int.Parse(kv.Key), l);
            }
            return d;
        }


        private Model.TrafficStruct GetTraffic(JObject jo)
            => new Model.TrafficStruct()
            {
                Date = jo["date"].ToString(),
                InputIn = long.Parse(jo["inputIn"].ToString()),
                InputOut = long.Parse(jo["inputOut"].ToString()),
                OutputIn = long.Parse(jo["outputIn"].ToString()),
                OutputOut = long.Parse(jo["outputOut"].ToString())
            };
    }
}

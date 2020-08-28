using DogYun.Model;

using Newtonsoft.Json.Linq;

namespace DogYun
{
    internal static class Ex
    {
        internal static int GetVmId(this string id)
            => int.Parse(
                id.Trim().ToLower().Replace("vm", "")
                );

        internal static bool HasDefaultCvmId() => Configuration.CvmId.IsValidCvmId();

        internal static bool IsValidCvmId(this int id) => id < 1;

        internal static bool IsSuccess(this JObject jo) => bool.Parse(jo["success"].ToString());

        internal static bool IsSuccess(this string str) => str.ToJObject().IsSuccess();

        internal static JObject ToJObject(this string str) => JObject.Parse(str);
    }
}

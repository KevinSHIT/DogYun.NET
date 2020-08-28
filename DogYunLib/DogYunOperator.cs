using DogYun.Model;

namespace DogYun
{
    public class DogYunOperator
    {
        /// <summary>
        /// CVM Class
        /// </summary>
        public CVM CVM = new CVM();

        /// <summary>
        /// DogYun operator without default CVM id.
        /// </summary>
        /// <param name="apiKey"></param>
        public DogYunOperator(string apiKey)
        {
            Configuration.ApiKey = apiKey;
            Configuration.CvmId = 0;
        }

        /// <summary>
        /// DogYun operator without default CVM id.
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="vmId"></param>
        public DogYunOperator(string apiKey, int cvmId)
        {
            Configuration.ApiKey = apiKey;
            Configuration.CvmId = cvmId;
        }

        /// <summary>
        /// Your API Key.
        /// </summary>
        public string ApiKey
        {
            get => Configuration.ApiKey;
            set => Configuration.ApiKey = value;
        }

        /// <summary>
        /// Default CVM ID.
        /// </summary>
        public int DefaultCvmId
        {
            get => Configuration.CvmId;
            set => Configuration.CvmId = value;
        }

        /// <summary>
        /// Timeout settings.
        /// </summary>
        public int Timeout
        {
            get => Configuration.Timeout;
            set => Configuration.Timeout = value;
        }

        /// <summary>
        /// Get now your API key.
        /// </summary>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        public string GetApiKey() => ApiKey;

        /// <summary>
        /// Set your API key.
        /// </summary>
        /// <param name="apiKey"></param>
        public void SetApiKey(string apiKey) => ApiKey = apiKey;

        /// <summary>
        /// Get now your default CVM id.
        /// </summary>
        /// <param name="cvmId"></param>
        /// <returns></returns>
        public int GetDefaultCvmId() => DefaultCvmId;

        /// <summary>
        /// Set your default CVM id.
        /// </summary>
        /// <param name="cvmId"></param>
        public void SetDefaultCvmId(int cvmId) => DefaultCvmId = cvmId;

        /// <summary>
        /// Get now your timeout.
        /// </summary>
        public int GetTimeout() => Timeout;

        /// <summary>
        /// Set timeout.
        /// </summary>
        /// <param name="timeout"></param>
        public void SetTimeout(int timeout) => Timeout = timeout;
    }
}

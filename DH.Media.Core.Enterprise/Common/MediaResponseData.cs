using System.Runtime.Serialization;

namespace DH.Media.Core.Enterprise.Common
{
    /// <summary>
    /// MediaResponse object
    /// </summary>
    /// <typeparam name="T">Type T</typeparam>
    [DataContract(Name = "MediaResponse{0}")]
    public class MediaResponse<T>
    {
        /// <summary>
        /// Service custom code
        /// </summary>
        [DataMember]
        public int Code { get; set; }

        /// <summary>
        /// Service custom message
        /// </summary>
        [DataMember]
        public string Message { get; set; }

        /// <summary>
        /// Response object
        /// </summary>
        [DataMember]
        public T Data { get; set; }
    }
}

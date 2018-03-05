using DH.Media.Core.Enterprise.Enums;

namespace DH.Media.Core.Enterprise.Common
{
    /// <summary>
    /// Manages service response
    /// </summary>
    public class ServiceResponse : SingletonBase<ServiceResponse>
    {
        #region Private Method

        private ServiceResponse() { }

        #endregion

        #region Public Methods
        /// <summary>
        /// Builds the service response
        /// </summary>
        /// <param name="code">ResponseCodes</param>
        /// <returns>MediaResponse object</returns>
        public MediaResponse BuildResponse(ResponseCodes code)
        {
            var curbsideResponse = new MediaResponse
            {
                Code = (int)code,
                Message = EnumManager.Instance.GetDescription(code)
            };
            return curbsideResponse;
        }

        /// <summary>
        /// Builds the service response
        /// </summary>
        /// <param name="code">ResponseCodes</param>
        /// <param name="data">Object of type T</param>
        /// <returns>MediaResponse object</returns>
        public MediaResponse<T> BuildResponse<T>(ResponseCodes code, T data)
        {
            var curbsideResponse = new MediaResponse<T>
            {
                Code = (int)code,
                Message = EnumManager.Instance.GetDescription(code),
                Data = data
            };

            return curbsideResponse;
        }

        public MediaResponse<T> BuildErrorResponse<T>(ResponseCodes code)
        {
            var curbsideResponse = new MediaResponse<T>
            {
                Code = (int)code,
                Message = EnumManager.Instance.GetDescription(code)              
            };

            return curbsideResponse;
        }

        #endregion
    }
}
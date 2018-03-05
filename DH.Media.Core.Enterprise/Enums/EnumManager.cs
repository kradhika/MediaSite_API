using System.ComponentModel;

namespace DH.Media.Core.Enterprise.Enums
{
    /// <summary>
    /// Manages enum related operations
    /// </summary>
    public class EnumManager : SingletonBase<EnumManager>
    {
        #region Private Methods
        private EnumManager() { }

        #endregion

        #region Public Methods
        /// <summary>
        /// Get description of the enum members
        /// </summary>
        /// <typeparam name="T">Enum type</typeparam>
        /// <param name="enumData">Enum member data</param>
        /// <returns>Enum member description</returns>
        public string GetDescription<T>(T enumData)
        {
            var fi = enumData.GetType().GetField(enumData.ToString());
            var attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : enumData.ToString();
        }

        /// <summary>
        /// Gets custom attribute value of the enum member.
        /// </summary>
        /// <typeparam name="T">Enum type</typeparam>
        /// <typeparam name="TR">Attribute type</typeparam>
        /// <typeparam name="TA"></typeparam>
        /// <param name="enumData">Enum Member</param>
        /// <returns></returns>
        public TR GetAttributeValue<T, TA, TR>(T enumData)
        {
            var attributeValue = default(TR);

            var fi = enumData.GetType().GetField(enumData.ToString());

            var attributes = fi?.GetCustomAttributes(typeof(TA), false) as TA[];

            if (attributes != null && attributes.Length > 0)
            {
                var attribute = attributes[0] as IEnumAttribute<TR>;

                if (attribute != null)
                {
                    attributeValue = attribute.Value;
                }
            }

            return attributeValue;
        }
        #endregion
    }
}

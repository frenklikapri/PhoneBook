using PhoneBook.Implementations;
using PhoneBook.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Helpers
{
    /// <summary>
    /// Helps getting the right provider for <see cref="IPhoneBookProvider"/> implementation based on configuration
    /// </summary>
    public class PhoneBookFactory
    {
        /// <summary>
        /// Returns the PhoneBook provider implementation based on filetype configuration
        /// </summary>
        /// <returns></returns>
        public static IPhoneBookProvider GetProvider()
        {
            // Throw exception if provider is not configured
            if (Configuration.Configurations.Config == null)
                throw new Exception("PhoneBook configuration not set");

            return Configuration.Configurations.Config.FileType switch
            {
                Common.Enums.FileTypeEnum.JSON => new JsonPhoneBookProvider(),
                Common.Enums.FileTypeEnum.XML => new XmlPhoneBookProvider(),
                Common.Enums.FileTypeEnum.Binary => new BinaryPhoneBookProvider(),
                _ => new JsonPhoneBookProvider(),
            };
        }
    }
}

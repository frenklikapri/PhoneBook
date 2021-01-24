using PhoneBook.Common;
using PhoneBook.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Configuration
{
    /// <summary>
    /// Helper class for PhoneBook configuration
    /// </summary>
    public static class Configurations
    {
        private static Config _config = new Config
        {
            FileType = FileTypeEnum.JSON
        };

        /// <summary>
        /// Returns the configuration of PhoneBook provider
        /// </summary>
        public static Config Config
        {
            get
            {
                return _config;
            }
        }

        /// <summary>
        /// Used to set the configuration of PhoneBook provider
        /// </summary>
        /// <param name="fileType">The type of file. JSON, XML or Binary</param>
        /// <param name="directory">The directory where file will be saved</param>
        public static void SetConfigurations(FileTypeEnum fileType, string directory)
        {
            _config = new Config
            {
                FileType = fileType,
                Directory = directory
            };
        }

        /// <summary>
        /// Changes the type of file
        /// </summary>
        /// <param name="fileType">The type of file. JSON, XML or Binary</param>
        public static void ChangeFileType(FileTypeEnum fileType)
        {
            if (_config == null)
                throw new Exception("PhoneBook configuration not set");

            _config.FileType = fileType;
        }

        /// <summary>
        /// Changes the working directory of provider
        /// </summary>
        /// <param name="directory">The working directory</param>
        public static void ChangeWorkingDirectory(string directory)
        {
            if (_config == null)
                throw new Exception("PhoneBook configuration not set");

            _config.Directory = directory;
        }
    }
}

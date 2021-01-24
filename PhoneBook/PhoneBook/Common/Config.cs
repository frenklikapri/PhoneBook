using PhoneBook.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Common
{
    public class Config
    {
        public FileTypeEnum FileType { get; set; }
        public string Directory { get; set; } = "/PhoneBook/Persistance";
    }
}

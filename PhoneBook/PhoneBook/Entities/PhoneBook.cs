using PhoneBook.Common;
using PhoneBook.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Entities
{
    public class PhoneBook
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public PhoneNumberTypeEnum Type { get; set; }
        public string Number { get; set; }
    }
}

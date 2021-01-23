using PhoneBook.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhoneBook.Dtos
{
    public class SavePhoneBookDto
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public PhoneNumberTypeEnum Type { get; set; }

        [Required]
        [Phone]
        public string Number { get; set; }
    }
}

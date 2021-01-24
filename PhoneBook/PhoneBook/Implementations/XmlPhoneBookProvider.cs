using PhoneBook.Dtos;
using PhoneBook.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Implementations
{
    public class XmlPhoneBookProvider : IPhoneBookProvider
    {
        public bool DeleteAllPhoneBooks()
        {
            throw new NotImplementedException();
        }

        public bool DeletePhoneBook(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Entities.PhoneBook> GetPhoneBooks()
        {
            throw new NotImplementedException();
        }

        public Entities.PhoneBook SavePhoneBook(SavePhoneBookDto savePhoneBookDto)
        {
            throw new NotImplementedException();
        }
    }
}

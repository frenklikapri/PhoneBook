using PhoneBook.Dtos;
using PhoneBook.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Implementations
{
    public class JsonPhoneBookProvider : IPhoneBookProvider
    {
        public async Task<bool> DeletePhoneBookAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Entities.PhoneBook>> GetPhoneBooksAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Entities.PhoneBook> SavePhoneBookAsync(SavePhoneBookDto savePhoneBookDto)
        {
            throw new NotImplementedException();
        }
    }
}

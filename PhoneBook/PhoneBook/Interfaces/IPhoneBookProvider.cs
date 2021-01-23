using PhoneBook.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Interfaces
{
    public interface IPhoneBookProvider
    {
        Task<List<Entities.PhoneBook>> GetPhoneBooksAsync();
        Task<bool> DeletePhoneBookAsync(Guid id);
        Task<Entities.PhoneBook> SavePhoneBookAsync(SavePhoneBookDto savePhoneBookDto);
    }
}

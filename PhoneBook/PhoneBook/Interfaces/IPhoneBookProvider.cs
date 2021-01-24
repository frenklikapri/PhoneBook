using PhoneBook.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Interfaces
{
    /// <summary>
    /// Helps to Create/Edit/Delete/Read PhoneBook entries from a file
    /// </summary>
    public interface IPhoneBookProvider
    {
        /// <summary>
        /// Get all PhoneBook entries from file
        /// </summary>
        /// <returns></returns>
        List<Entities.PhoneBook> GetPhoneBooks();

        /// <summary>
        /// Deletes a PhoneBook entry
        /// </summary>
        /// <param name="id">The id of PhoneBook entry</param>
        /// <returns></returns>
        bool DeletePhoneBook(Guid id);

        /// <summary>
        /// Deletes all the entries
        /// </summary>
        /// <returns></returns>
        bool DeleteAllPhoneBooks();

        /// <summary>
        /// Creates or modifies a PhoneBook entry depending on id
        /// </summary>
        /// <param name="savePhoneBookDto">Dto used to pass the data</param>
        /// <returns>The Created/Modified entry</returns>
        Entities.PhoneBook SavePhoneBook(SavePhoneBookDto savePhoneBookDto);
    }
}

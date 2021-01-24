using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Dtos;
using PhoneBook.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBookController : ControllerBase
    {
        private readonly IPhoneBookProvider _phoneBookProvider;

        public PhoneBookController(IPhoneBookProvider phoneBookProvider)
        {
            _phoneBookProvider = phoneBookProvider;
        }

        /// <summary>
        /// Returns all the phonebook entries order by fullname
        /// </summary>
        /// <returns>List of <see cref="Entities.PhoneBook"/></returns>
        [HttpGet]
        public ActionResult<List<Entities.PhoneBook>> GetPhoneBooks()
        {
            var phoneBooks = _phoneBookProvider.GetPhoneBooks();

            return phoneBooks;
        }

        /// <summary>
        /// Creates a new phonebook entry
        /// </summary>
        /// <param name="savePhoneBookDto">
        ///     Name: The person's fullname<br />
        ///     Type: 0 - Work, 1 - Cellphone, 2 - Home<br />
        ///     Number: The phone number
        /// </param>
        /// <returns>The created phonebook entry</returns>
        [HttpPost]
        public ActionResult<Entities.PhoneBook> CreatePhonebook(SavePhoneBookDto savePhoneBookDto)
        {
            var phoneBook = _phoneBookProvider.SavePhoneBook(savePhoneBookDto);

            return Ok(phoneBook);
        }

        /// <summary>
        /// Edit an existing phonebook entry
        /// </summary>
        /// <param name="savePhoneBookDto">
        ///     Id: The phonebook entry id<br />
        ///     Name: The person's fullname<br />
        ///     Type: 0 - Work, 1 - Cellphone, 2 - Home<br />
        ///     Number: The phone number
        /// </param>
        /// <returns>The edited phonebook entry</returns>
        [HttpPut]
        public ActionResult<Entities.PhoneBook> EditPhonebook(SavePhoneBookDto savePhoneBookDto)
        {
            var phoneBook = _phoneBookProvider.SavePhoneBook(savePhoneBookDto);

            return Ok(phoneBook);
        }

        /// <summary>
        /// Deletes an existing phonebook entry
        /// </summary>
        /// <param name="id">The id of entry</param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult DeletePhoneBook(Guid id)
        {
            if (!_phoneBookProvider.DeletePhoneBook(id))
                return BadRequest("Couldn't delete the phonebook entry");

            return Ok();
        }
    }
}

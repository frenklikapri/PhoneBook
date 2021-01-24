using PhoneBook.Dtos;
using PhoneBook.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBook.Implementations
{
    public class JsonPhoneBookProvider : IPhoneBookProvider
    {
        private readonly ReaderWriterLockSlim _locker = new ReaderWriterLockSlim();

        public bool DeleteAllPhoneBooks()
        {
            var config = Configuration.Configurations.Config;
            var filePath = Path.Combine(config.Directory, "pb.json");

            CreateFileIfNotExists();

            _locker.EnterWriteLock();

            try
            {
                File.WriteAllText(filePath, "");
            }
            finally
            {
                _locker.ExitWriteLock();
            }

            return true;
        }

        public bool DeletePhoneBook(Guid id)
        {
            var config = Configuration.Configurations.Config;
            var filePath = Path.Combine(config.Directory, "pb.json");

            CreateFileIfNotExists();

            var phoneBooks = GetPhoneBooks();

            var phoneBook = phoneBooks
                .FirstOrDefault(p => p.Id == id);

            if (phoneBook == null)
                throw new Exception("PhoneBook entry not found");

            phoneBooks.Remove(phoneBook);

            var phoneBookStr = JsonSerializer.Serialize(phoneBooks);

            _locker.EnterWriteLock();

            try
            {
                File.WriteAllText(filePath, phoneBookStr);
            }
            finally
            {
                _locker.ExitWriteLock();
            }

            return true;
        }

        public List<Entities.PhoneBook> GetPhoneBooks()
        {
            var config = Configuration.Configurations.Config;
            var filePath = Path.Combine(config.Directory, "pb.json");

            CreateFileIfNotExists();

            _locker.EnterReadLock();

            var phoneBooks = new List<Entities.PhoneBook>();

            try
            {
                var phoneBooksStr = File.ReadAllText(filePath);

                if (!string.IsNullOrEmpty(phoneBooksStr))
                    phoneBooks = JsonSerializer
                        .Deserialize<List<Entities.PhoneBook>>(phoneBooksStr)
                        .OrderBy(p => p.Name)
                        .ToList();
            }
            finally
            {
                _locker.ExitReadLock();
            }

            return phoneBooks;
        }

        public Entities.PhoneBook SavePhoneBook(SavePhoneBookDto savePhoneBookDto)
        {
            var config = Configuration.Configurations.Config;
            var filePath = Path.Combine(config.Directory, "pb.json");

            CreateFileIfNotExists();

            var phoneBooks = GetPhoneBooks();

            var phoneBook = phoneBooks
                .FirstOrDefault(p => p.Id == savePhoneBookDto.Id);

            Entities.PhoneBook toReturn;

            // if null then add new
            if (phoneBook == null)
            {
                var toAdd = new Entities.PhoneBook
                {
                    Id = Guid.NewGuid(),
                    Name = savePhoneBookDto.Name,
                    Number = savePhoneBookDto.Number,
                    Type = savePhoneBookDto.Type
                };

                phoneBooks.Add(toAdd);
                toReturn = toAdd;
            }
            // else edit
            else
            {
                phoneBook.Name = savePhoneBookDto.Name;
                phoneBook.Number = savePhoneBookDto.Number;
                phoneBook.Type = savePhoneBookDto.Type;
                toReturn = phoneBook;
            }

            var phoneBookStr = JsonSerializer.Serialize(phoneBooks);

            _locker.EnterWriteLock();

            try
            {
                File.WriteAllText(filePath, phoneBookStr);
            }
            finally
            {
                _locker.ExitWriteLock();
            }

            return toReturn;
        }

        private void CreateFileIfNotExists()
        {
            var config = Configuration.Configurations.Config;
            var filePath = Path.Combine(config.Directory, "pb.json");

            // if dir not exists, create dir and file
            if (!Directory.Exists(config.Directory))
            {
                _locker.EnterWriteLock();

                try
                {
                    Directory.CreateDirectory(config.Directory);
                    File.Create(filePath);
                }
                finally
                {
                    _locker.ExitWriteLock();
                }
            }
        }
    }
}

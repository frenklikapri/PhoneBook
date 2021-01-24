using PhoneBook.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace PhoneBook.Tests
{
    public class JsonTests
    {
        private void EmptyPhoneBooks()
        {
            var provider = PhoneBook.Helpers.PhoneBookFactory.GetProvider();
            provider.DeleteAllPhoneBooks();
        }

        [Fact]
        public void DeletePhoneBook_Should_Work()
        {
            // Arrange
            PhoneBook.Configuration.Configurations.SetConfigurations(Common.Enums.FileTypeEnum.JSON, @"C:\Users\ADMIN\Desktop\Task Smartwork\File");
            EmptyPhoneBooks();
            var provider = PhoneBook.Helpers.PhoneBookFactory.GetProvider();
            var addedEntry = provider.SavePhoneBook(new Dtos.SavePhoneBookDto
            {
                Name = "Frenkli Kapri",
                Number = "+355691234567",
                Type = Common.Enums.PhoneNumberTypeEnum.Cellphone
            });

            // Act
            provider.DeletePhoneBook(addedEntry.Id);
            var phoneBooks = provider.GetPhoneBooks();

            // Assert
            Assert.False(phoneBooks.Any());
        }

        [Fact]
        public void AddPhoneBook_Should_Work()
        {
            // Arrange
            PhoneBook.Configuration.Configurations.SetConfigurations(Common.Enums.FileTypeEnum.JSON, @"C:\Users\ADMIN\Desktop\Task Smartwork\File");
            EmptyPhoneBooks();
            var provider = PhoneBook.Helpers.PhoneBookFactory.GetProvider();

            // Act
            provider.SavePhoneBook(new Dtos.SavePhoneBookDto
            {
                Name = "Frenkli Kapri",
                Number = "+355691234567",
                Type = Common.Enums.PhoneNumberTypeEnum.Cellphone
            });
            var phoneBooks = provider.GetPhoneBooks();
            var exists = phoneBooks.Any(p => p.Number == "+355691234567");

            // Assert
            Assert.True(exists);
        }

        [Fact]
        public void EditPhoneBook_Should_Work()
        {
            // Arrange
            PhoneBook.Configuration.Configurations.SetConfigurations(Common.Enums.FileTypeEnum.JSON, @"C:\Users\ADMIN\Desktop\Task Smartwork\File");
            EmptyPhoneBooks();
            var provider = PhoneBook.Helpers.PhoneBookFactory.GetProvider();
            var addedEntry = provider.SavePhoneBook(new Dtos.SavePhoneBookDto
            {
                Name = "Frenkli Kapri",
                Number = "+355691234567",
                Type = Common.Enums.PhoneNumberTypeEnum.Cellphone
            });

            // Act
            var toEdit = new SavePhoneBookDto
            {
                Id = addedEntry.Id,
                Name = "Frenkli Kapri 2",
                Number = "+355691234568",
                Type = Common.Enums.PhoneNumberTypeEnum.Cellphone
            };
            provider.SavePhoneBook(toEdit);

            var phoneBooks = provider.GetPhoneBooks();
            var exists = phoneBooks.Any(p => p.Number == "+355691234568");

            // Assert
            Assert.True(exists);
        }

        [Fact]
        public void ReadEntries_Should_Work()
        {
            // Arrange
            PhoneBook.Configuration.Configurations.SetConfigurations(Common.Enums.FileTypeEnum.JSON, @"C:\Users\ADMIN\Desktop\Task Smartwork\File");
            EmptyPhoneBooks();
            var provider = PhoneBook.Helpers.PhoneBookFactory.GetProvider();
            provider.SavePhoneBook(new Dtos.SavePhoneBookDto
            {
                Name = "Frenkli Kapri",
                Number = "+355691234567",
                Type = Common.Enums.PhoneNumberTypeEnum.Cellphone
            });

            // Act
            var phoneBooks = provider.GetPhoneBooks();

            // Assert
            Assert.True(phoneBooks.Any());
        }
    }
}

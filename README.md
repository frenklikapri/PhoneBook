# PhoneBook

A library that saves and reads phonebook entries from a file.

# Solution

## PhoneBook

This is the PhoneBook management library.

## PhoneBook.API

This is the API project. Uses the PhoneBook library.

## PhoneBook.Tests

This is the unit tests project. xunit is used for unit tests.

# PhoneBook library usage

```csharp
PhoneBook.Interfaces.IPhoneBookProvider
```

This is the interface you should use for PhoneBook functionalities. There are 3 implementation of this interface:

```csharp
PhoneBook.Implementations.BinaryPhoneBookProvider
PhoneBook.Implementations.JsonPhoneBookProvider
PhoneBook.Implementations.XmlPhoneBookProvider
```

Currently, only JsonPhoneBookProvider is implemented. You can add your personal implementation of this interface. To access the right implementation, you have to configure the library by calling this function:

```csharp
PhoneBook.Configuration.Configurations.SetConfigurations(Common.Enums.FileTypeEnum.JSON, env.ContentRootPath + "/Persistance");
```

The first paramter is the filetype(JSON, XML or binary) and the other parameter is the directory where the file will be saved. After the configuration of the libary, you can use it by adding the interface in dependency injection configuration or using the factory that library provides.
Factory provided by library:

```csharp
var provider = PhoneBook.Helpers.PhoneBookFactory.GetProvider();
```

Configuring it in dependency injection(.NET Core Web API example):

```csharp
services.AddScoped<IPhoneBookProvider, JsonPhoneBookProvider>();
```

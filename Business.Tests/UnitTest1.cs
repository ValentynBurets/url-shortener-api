using API.Configurations;
using AutoMapper;
using Business.Contract.Models.UrlItemManagement;
using Business.Contract.Models.UserManagement;
using Business.Services.UrlManagement;
using Data.Contract.Repository.UrlItemManagement;
using Data.Contract.Repository.UserManagement;
using Data.Contract.UnitOfWork;
using Domain.Entity.UrlManagement;
using Domain.Entity.Users;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Tests
{
    [TestFixture]
    public class Tests
    {
        private static IMapper mapper = new Mapper(new MapperConfiguration(cnf => cnf.AddProfile(new MapperInitializer())));
        UrlItemService urlItemService;

        static PersonInfoDTO personInfoDTO = new PersonInfoDTO()
        {
            Role = "User"
        };

        static User user = new User(new Guid("2bef5669-55ee-4261-91ab-bd4281cfba3c"));

        static UrlItem urlItem = new UrlItem()
        {
            Id = new Guid("e15a1540-9225-429a-aa1c-028f0023451b"),
            CreatorId = new Guid("2bef5669-55ee-4261-91ab-bd4281cfba3c"),
            Url = "testUrl",
            ShortUrl = "url"
        };

        static UrlItemDTO urlItemDTO = new UrlItemDTO()
        {
            Id = new Guid("e15a1540-9225-429a-aa1c-028f0023451b"),
            CreatorId = new Guid("2bef5669-55ee-4261-91ab-bd4281cfba3c"),
            CreatedDate = DateTime.Now,
            Url = "testUrl",
            ShortUrl = "url"
        };

        static ShortUrlItemDTO shortUrlItemDTO = new ShortUrlItemDTO()
        {
            Id = new Guid("e15a1540-9225-429a-aa1c-028f0023451b"),
            Url = "testUrl",
            ShortUrl = "url"
        };

        static CreateUrlItemDTO createUrlItemDTO = new CreateUrlItemDTO()
        {
            Url = "testUrl",
            ShortUrl = "url"
        };

        IEnumerable<UrlItem> urlItems = new List<UrlItem>()
        {
            urlItem
        };

        IEnumerable<UrlItemDTO> urlItemDTOs = new List<UrlItemDTO>()
        {
            urlItemDTO
        };

        IEnumerable<ShortUrlItemDTO> shortUrlItemDTOs = new List<ShortUrlItemDTO>()
        {
            shortUrlItemDTO
        };

        [SetUp]
        public void Setup()
        {
            IUrlItemRepository stubUrlItemRepository = Mock.Of<IUrlItemRepository>(uR => uR.Add(It.IsAny<UrlItem>()) == Task.CompletedTask &&
                                                                                         uR.GetById(It.IsAny<Guid>()) == Task.FromResult(urlItem) &&
                                                                                         uR.GetAll() == Task.FromResult(urlItems) &&
                                                                                         uR.Remove(It.IsAny<UrlItem>()) == Task.CompletedTask);

            IUserRepository stubUserRepository = Mock.Of<IUserRepository>(uR => uR.GetByIdLink(It.IsAny<Guid>()) == Task.FromResult(user));
            

            IUnitOfWork unitOfWork = Mock.Of<IUnitOfWork>(of => of.UrlItemRepository == stubUrlItemRepository &&
                                                                of.UserRepository == stubUserRepository && 
                                                                of.AdminRepository == null);

            urlItemService = new UrlItemService(mapper, unitOfWork);
        }

        [Test]
        public void Create()
        {
            // Act
            var result = urlItemService.Create(createUrlItemDTO, new Guid("4a08f0b7-4268-43d8-8092-4f2dfc17635e"));

            // Assert
            Assert.That(result.Exception, Is.Null);
        }

        [Test]
        public void GetById()
        {
            // Act
            var result = urlItemService.GetById(urlItemDTO.Id);

            // Assert
            Assert.That(result.Exception, Is.EqualTo(null));
        }

        [Test]
        public void GetAll()
        {
            // Act
            var result = urlItemService.GetAll();

            // Assert
            Assert.That(result.Exception,  Is.EqualTo(null));       }

        [Test]
        public void Remove()
        {
            // Act
            var result = urlItemService.Delete(urlItem.Id);

            // Assert
            Assert.That(result.Exception, Is.Null);
        }
    }
}
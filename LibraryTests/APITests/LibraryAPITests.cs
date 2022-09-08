using LibrarryCrudOps.Controller;
using LibrarryCrudOps.DAL;
using LibrarryCrudOps.DTO;
using LibrarryCrudOps.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace LibraryTests.APITests
{
    public class LibraryAPITests
    {
        private LibrarryController _controller;
        private Mock<IlibrarryRepository> _repositoryMock;
        private Book _testBook;
        private CreateBookDto _createBookDto;

        [SetUp]
        public void Setup()
        {
            _repositoryMock = new Mock<IlibrarryRepository>();
            _repositoryMock.Setup(x => x.CreateAsync(It.IsAny<Book>())).Returns(Task.CompletedTask);
            _controller = new LibrarryController(_repositoryMock.Object);
            _testBook = new Book
            {
                Authors = new string[] { "TestAithor" },
                DateOfPublication = DateTime.Now.AddDays(-10),
                Id = Guid.NewGuid(),
                Title = "TestTitle"
            };
            _createBookDto = new CreateBookDto
            {
                Title = "TestCreateTitle",
                Authors = new string[] { "TestCreateAuthor" },
                DateOfPublication = DateTime.Now.AddDays(-9)
            };
        }

        [Test]
        public async Task CreateBook_CreatingProperBook_SuccessResponse()
        {
            //AAA arrange, act, assert
            var response = await _controller.Create(_createBookDto);

            Assert.IsNotNull(response as OkResult);
        }

        [Test]
        public async Task CreateBook_RequestWithMissingParams_FaliedResponse()
        {
            _createBookDto.Title = null;
            _createBookDto.Authors = null;

            var response = await _controller.Create(_createBookDto);

            Assert.IsNull(response as OkResult);
        }
    }
}
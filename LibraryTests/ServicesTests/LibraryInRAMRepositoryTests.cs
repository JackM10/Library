using LibrarryCrudOps.DAL.Services;
using LibrarryCrudOps.Models;

namespace LibraryTests.ServicesTests
{
    internal class LibraryInRAMRepositoryTests
    {
        private LibraryInRAMRepository _libraryInRAMRepository;
        private Book _testBook;

        [SetUp]
        public void Setup()
        {
            _libraryInRAMRepository = new LibraryInRAMRepository();
            _testBook = new Book
            {
                Authors = new string[] { "testAuth" },
                Title = "testTitle",
                DateOfPublication = DateTime.Now.AddDays(-5),
                Id = Guid.NewGuid()
            };
        }

        [Test]
        public async Task CreateBook_CreatingProperBook_SuccessResponse()
        {
            await _libraryInRAMRepository.CreateAsync(_testBook);
            var resultFromGet = await _libraryInRAMRepository.GetByIdAsync(_testBook.Id);
            await _libraryInRAMRepository.DeleteAsync(_testBook.Id);
            var nullResultAfterCleaning = await _libraryInRAMRepository.GetByIdAsync(_testBook.Id);

            Assert.NotNull(resultFromGet);
            Assert.IsNull(nullResultAfterCleaning);
        }
    }
}

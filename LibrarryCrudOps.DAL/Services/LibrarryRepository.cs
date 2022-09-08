using LibrarryCrudOps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarryCrudOps.DAL.Services
{
    public class LibrarryRepository : IlibrarryRepository
    {
        private List<Book> _inMemoryBooksRepository;

        public LibrarryRepository()
        {
            _inMemoryBooksRepository = new List<Book>();
        }

        public Task CreateAsync(Book librarryToUpdate)
        {
            librarryToUpdate.Id = Guid.NewGuid();

            _inMemoryBooksRepository.Add(librarryToUpdate);

            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            _inMemoryBooksRepository.RemoveAll(b => b.Id == id);

            return Task.CompletedTask;
        }

        public Task<List<Book>> GetAllAsync()
        {
            return Task.FromResult(_inMemoryBooksRepository);
        }

        public Task<Book> GetByIdAsync(Guid id)
        {
            return Task.FromResult(_inMemoryBooksRepository.FirstOrDefault(b => b.Id == id));
        }

        public Task<string> UpdateAsync(Book bookToUpdate)
        {
            var bookToUpdateInRepo = _inMemoryBooksRepository.FirstOrDefault(b => b.Id == bookToUpdate.Id);

            if (bookToUpdateInRepo == null)
                return Task.FromResult($"There is no book in the repo with id: {bookToUpdate.Id}");

            bookToUpdateInRepo.Title = bookToUpdate.Title;
            bookToUpdateInRepo.Authors = bookToUpdate.Authors;
            bookToUpdateInRepo.DateOfPublication = bookToUpdate.DateOfPublication;

            return Task.FromResult(string.Empty);
        }
    }
}

using LibrarryCrudOps.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarryCrudOps.DAL.Services
{
    public class LibraryInRAMRepository : IlibrarryRepository
    {
        private LibraryContext _context;
        public LibraryInRAMRepository()
        {
            var options = new DbContextOptionsBuilder<LibraryContext>()
                            .UseInMemoryDatabase(databaseName: "Library")
                            .Options;

            _context = new LibraryContext(options);
        }

        public async Task CreateAsync(Book librarryToUpdate)
        {
            await _context.Books.AddAsync(librarryToUpdate);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var bookToDelete = await GetByIdAsync(id);
            _context.Books.Remove(bookToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetByIdAsync(Guid id)
        {
            return await _context.Books.Where(b => b.Id == id).FirstOrDefaultAsync();
        }

        public Task<string> UpdateAsync(Book librarryToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}

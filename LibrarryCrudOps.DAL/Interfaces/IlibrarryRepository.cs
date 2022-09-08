using LibrarryCrudOps.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarryCrudOps.DAL
{
    public interface IlibrarryRepository
    {
        /// <summary>
        /// Get book by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>asynchronious result of </returns>
        Task<Book> GetByIdAsync(Guid id);
        Task<List<Book>> GetAllAsync();
        Task<string> UpdateAsync(Book librarryToUpdate);
        Task CreateAsync(Book librarryToUpdate);
        Task DeleteAsync(Guid id);
    }
}

using LibrarryCrudOps.DAL;
using LibrarryCrudOps.DTO;
using LibrarryCrudOps.Models;
using LibrarryCrudOps.Validators;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LibrarryCrudOps.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibrarryController : ControllerBase
    {
        private IlibrarryRepository _ilibrarryRepository;
        public LibrarryController(IlibrarryRepository ilibrarryRepository)
        {
            _ilibrarryRepository = ilibrarryRepository;
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery]Guid id)
        {
            var result = await _ilibrarryRepository.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _ilibrarryRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateBookDto createLibrarryDto)
        {
            var validationResult = CreateBookValidator.IsValid(createLibrarryDto);
            if (!validationResult.Item1)
                return BadRequest($"Passed object isn't valid, {validationResult.Item2}");

            var bookToCreate = new Book
            {
                Authors = createLibrarryDto.Authors,
                DateOfPublication = createLibrarryDto.DateOfPublication,
                Title = createLibrarryDto.Title
            };

            await _ilibrarryRepository.CreateAsync(bookToCreate);

            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Put(UpdateBookDto updateLibrarryDto)
        {
            var validationResult = UpdateBookValidator.IsValid(updateLibrarryDto);
            if (!validationResult.Item1)
                return BadRequest($"Passed object isn't valid, {validationResult.Item2}");

            var bookToCreate = new Book
            {
                Id = updateLibrarryDto.Id,
                Authors = updateLibrarryDto.Authors,
                DateOfPublication = updateLibrarryDto.DateOfPublication,
                Title = updateLibrarryDto.Title
            };

            var updateErrorMessage = await _ilibrarryRepository.UpdateAsync(bookToCreate);

            if (string.IsNullOrEmpty(updateErrorMessage))
                return Ok();
            else
                return BadRequest(updateErrorMessage);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var validationResult = DeleteBookValidator.IsValid(id);
            if (!validationResult.Item1)
                return BadRequest($"Passed id isn't valid, {validationResult.Item2}");
                       

            await _ilibrarryRepository.DeleteAsync(id);

            return Ok();
        }
    }
}

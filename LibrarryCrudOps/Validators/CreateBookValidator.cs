using LibrarryCrudOps.DTO;
using System;
using System.Linq;

namespace LibrarryCrudOps.Validators
{
    public static class CreateBookValidator
    {
        public static (bool, string) IsValid(CreateBookDto createLibrarryDto)
        {
            if (string.IsNullOrEmpty(createLibrarryDto.Title))
                return (false, "Title shouldn'g be null or empty");
            if (createLibrarryDto.Authors.Length == 0)
                return (false, "At least one author should be provided");
            if (!createLibrarryDto.Authors.Any(b => !string.IsNullOrEmpty(b)))
                return (false, "Author shouldn'g be null or empty");
            if (createLibrarryDto.DateOfPublication > DateTime.Now)
                return (false, "Date of publication can't be in future");

            foreach (var author in createLibrarryDto.Authors)
            {
                if (author.Length < 2)
                    return (false, "Author must be at leaast 3 chars long");
            }

            return (true, string.Empty);
        }
    }
}

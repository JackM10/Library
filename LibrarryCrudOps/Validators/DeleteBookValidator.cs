using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarryCrudOps.Validators
{
    public static class DeleteBookValidator
    {
        public static (bool, string) IsValid(Guid id)
        {
            if (Guid.Empty == id)
                return (false, "Id can't be empty Guid");


            return (true, string.Empty);
        }
    }
}

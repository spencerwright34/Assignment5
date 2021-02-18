using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Models
{
    public class EFBookstoreRepository : IBookstoreRepository
    {
        //This private _context will be set in the constructor
        private BookstoreDbContext _context;

        //Constructor
        public EFBookstoreRepository (BookstoreDbContext context)
        {
            _context = context;
        }

        //This is set up in the BookstoreDbContext.cs file
        public IQueryable<Project> Projects => _context.Projects;
    }
}

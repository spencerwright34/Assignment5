using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Models
{
    //A repository provides a consistent way to access the features presented by the DbContext class
    //A repository reduces duplication
    //The interface creates a template
    public interface IBookstoreRepository
    {
        IQueryable<Project> Projects { get; }
    }
}

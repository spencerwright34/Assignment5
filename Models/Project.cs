using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Models
{
    public class Project
    {
        //Model for all the fields in the database
        //Author first and last name as well as Classification and Category have been split up for normalization purposes
        //Every field is required
        //BookId is the primary key in the database and that is why it has "Key" in the data validation
        [Key, Required]
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string AuthorFirstName { get; set; }
        [Required]
        public string AuthorLastName { get; set; }
        [Required]
        public string Publisher { get; set; }
        //The regular expression describes the format needed to enter in an ISBN number
        [Required, RegularExpression("[0-9]{3}-[0-9]{10}", ErrorMessage = "Invalid ISBN number")]
        public string ISBN { get; set; }
        [Required]
        public string Classification { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int NumPages { get; set; }
    }
}

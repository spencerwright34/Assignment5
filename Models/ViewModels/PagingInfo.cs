using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Models.ViewModels
{
    public class PagingInfo
    {
        public int TotalNumItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        //One of these numbers needs to be a decimal
        //After making the outcome a decimal, the Math.Ceiling will make the number go to the next whole number
        //(int) will then turn the whole decimal number into an integer, which is the data type of TotalPages
        public int TotalPages => (int) (Math.Ceiling((decimal) TotalNumItems / ItemsPerPage));
    }
}

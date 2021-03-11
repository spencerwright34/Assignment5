using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Models
{
    public class Cart
    {
        //the = instantiates the variable
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem (Project proj, int qty)
        {
            CartLine line = Lines
                .Where(p => p.Project.BookId == proj.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Project = proj,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public virtual void RemoveLine(Project proj) =>
            Lines.RemoveAll(x => x.Project.BookId == proj.BookId);

        public virtual void Clear() => Lines.Clear();

        public decimal ComputeTotalSum() => (decimal)Lines.Sum(e => e.Project.Price * e.Quantity);
        //public decimal ComputeTotalSum() => Lines.Sum(e => e.Project.Price * e.Quantity);

        public class CartLine
        {
            //You usually capitalize a property (CartLineID, Project, Quantity)
            public int CartLineID { get; set; }
            public Project Project { get; set; }
            public int Quantity { get; set; }
        }

    }
}

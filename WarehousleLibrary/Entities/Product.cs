using System.ComponentModel;

namespace Warehouse.Library.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }

        public Guid StatusId { get; set; }
        public virtual Status? Status { get; set; }

        public virtual ICollection<Transition> Transitions { get; set; }

        public Product()
        {
            Transitions = new HashSet<Transition>();
        }

        public Product(Guid id, string name, decimal price, Guid statusId)
        {
            Id = id;
            Name = name;
            Price = price;
            StatusId = statusId;
            Transitions = new HashSet<Transition>();
        }
    }
}

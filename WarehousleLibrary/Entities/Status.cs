namespace Warehouse.Library.Entities
{
    public class Status
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Transition> TransitionsTo { get; set; }

        public Status()
        {
            Products = new HashSet<Product>();
            TransitionsTo = new HashSet<Transition>();
        }

        public Status(Guid id, string name)
        {
            Id = id;
            Name = name;
            Products = new HashSet<Product>();
            TransitionsTo = new HashSet<Transition>();
        }
    }
}

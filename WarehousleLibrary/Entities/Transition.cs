namespace Warehouse.Library.Entities
{
    public class Transition
    {
        public Guid Id { get; set; }
        public DateTime TransitionDate { get; set; }
        
        public Guid ProductId { get; set; }
        public virtual Product? Product { get; set; }

        public Guid StatusIdTo { get; set; }
        public virtual Status? StatusTo { get; set; }

        public Transition() 
        {
        }

        public Transition(Guid id, DateTime transitionDate, Guid productId, Guid statusIdTo)
        {
            Id = id;
            TransitionDate = transitionDate;
            ProductId = productId;
            StatusIdTo = statusIdTo;
        }
    }
}

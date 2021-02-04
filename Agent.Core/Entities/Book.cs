using Agent.SharedKernel;
using Agent.SharedKernel.Interfaces;

namespace Agent.Core.Entities
{
    public class Book : BaseEntity, IAggregateRoot
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public int CatalogueId { get; set; }

        public Catalogue Catalogue { get; set; }
    }
}

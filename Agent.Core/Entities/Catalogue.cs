using Agent.SharedKernel;
using Agent.SharedKernel.Interfaces;
using System.Collections.Generic;

namespace Agent.Core.Entities
{
    public class Catalogue : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }

        public List<Book> Books { get; set; }
    }
}

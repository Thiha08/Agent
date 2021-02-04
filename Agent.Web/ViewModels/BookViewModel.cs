using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agent.Web.ViewModels
{
    public class BookViewModel : ViewModelBase
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public int CatalogueId { get; set; }
    }
}

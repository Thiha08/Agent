using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agent.Web.ViewModels
{
    public class CatalogueViewModel : ViewModelBase
    {
        public string Name { get; set; }

        public List<BookViewModel> Books { get; set; }
    }
}

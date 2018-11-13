using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SightWordWeb.ViewModels.List
{
    public class CreateWordListViewModel
    {
        [DisplayName("List Name")]
        public string Name { get; set; }

        [DisplayName("Words")]
        public string CommaSeparatedList { get; set; }

    }
}

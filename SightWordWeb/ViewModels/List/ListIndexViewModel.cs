using SightWordWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SightWordWeb.ViewModels.List
{
    public class ListIndexViewModel
    {

        public ListIndexViewModel()
        {
            WordLists = new List<WordList>();
        }


        public IList<WordList> WordLists { get; set; }


    }
}

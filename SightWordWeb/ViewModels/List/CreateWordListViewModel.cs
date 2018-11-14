using Microsoft.ApplicationInsights.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SightWordWeb.ViewModels.List
{
    public class CreateWordListViewModel
    {
        private const string NAME_REGEX_ERR = "Name may only be characters with no punctuation or spaces.";
        private const string LIST_REGEX_ERR = "List may not include punctuation or special characters.";

        [DisplayName("List Name"), StringLength(50)]
        [RegularExpression(@"\w+", ErrorMessage = NAME_REGEX_ERR)]
        public string Name { get; set; }

        [DisplayName("Words")]
        [RegularExpression(@"[\w\s,]+", ErrorMessage = LIST_REGEX_ERR)]
        public string CommaSeparatedList { get; set; }


    }
}

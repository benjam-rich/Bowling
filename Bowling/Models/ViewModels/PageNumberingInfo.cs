using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bowling.Models.ViewModels
{
    //this class helps calculate the number of items that show up on each page and how many pages need to display for Home and each Team
    public class PageNumberingInfo
    {
        public int NumItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalNumItems { get; set; }

        //Calculate Number of Pages
        public int NumPages => (int) (Math.Ceiling((decimal) TotalNumItems / NumItemsPerPage));
    }
}

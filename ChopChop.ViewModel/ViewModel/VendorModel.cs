using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChopChop.ViewModel
{
    public class VendorModel
    {
    }

    public class SearchResturant
    {
        public decimal? Lat { get; set; }
        public decimal? Long { get; set; }
        public int? SortOptionId { get; set; }
        public int? StartIndex { get; set; }
        public int? EndIndex { get; set; }
        public int? LanguageId { get; set; }
        public string SearchText { get; set; }
        public int? TotalRows { get; set; }
    }
    public class ResultSearchRestaurants
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Describtion { get; set; }
        public string ThumbnailURL { get; set; }
        public decimal? Lat { get; set; }
        public decimal? Long { get; set; }
        public int? Distance { get; set; }
    }
}

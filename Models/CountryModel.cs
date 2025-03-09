using System;

namespace SchedulingSystem.Models
{
    public class CountryModel
    {
        public int CountryId { get; set; }
        public string Country { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdateBy { get; set; }
    }
}
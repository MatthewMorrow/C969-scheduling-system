using System;

namespace SchedulingSystem.Models
{
    public class CityModel
    {
        public int CityId { get; set; }
        public string City { get; set; }
        public int CountryId { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdateBy { get; set; }
    }
}
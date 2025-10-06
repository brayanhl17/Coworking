using Cwk.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwk.Domain.DTOs.Requests
{
    public class AddSpaceDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public string Location { get; set; } = string.Empty;
        public decimal PricePerHour { get; set; }
        public string? ImageUrl { get; set; }
        public SpaceType SpaceType { get; set; }
        public List<int> AmenityIds { get; set; } = [];
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwk.Domain.DTOs.Responses
{
    public class ReservationResponseDto
    {
        public List<ReservationDetailsDto> Reservations { get; set; } = new();
        public int TotalCount { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
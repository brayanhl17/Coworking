namespace Cwk.Domain.DTOs.Responses
{
    public class LoginResponseDto
    {
        public bool IsAuthenticated { get; set; }

        public string Token { get; set; } = null!;

        public string Message { get; set; } = null!;
    }
}
namespace Application.DTOs.Authentication
{
    public class ValidateOtpRecoveryPasswordRequest
    {
        public string Email { get; set; }

        public string Token { get; set; }
    }
}

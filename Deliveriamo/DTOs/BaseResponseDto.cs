namespace Deliveriamo.DTOs
{
    public class BaseResponseDto
    {
        public string ErrorMessage { get; set; }
        public bool Success { get; set; } = true;

        public void SetExeption(string errormessage)
        {
            Success = false;
            ErrorMessage = errormessage;
        }
    }
}

namespace Domain.Models
{
    public class OperationResultModel
    {
        public bool IsSuccess { get; set; } = false;
        public string Message { get; set; } = string.Empty;
    }
}
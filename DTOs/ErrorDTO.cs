namespace DTOs
{
    public class ErrorDTO
    {
        public int Code { get; set; }
        public string? Description { get; set; }

        public ErrorDTO()
        {
        }

        public ErrorDTO(int code, string description)
        {
            Code = code;
            Description = description;
        }
    }
}

namespace Application.Requests
{
    public class UpdateAppSettingRequest
    {
        public Guid Id { get; set; }
        public string ReferenceKey { get; set; } = String.Empty;
        public string Value { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string Type { get; set; } = String.Empty;
    }
}

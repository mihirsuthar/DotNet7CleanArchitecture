namespace Application.Requests
{
    public class CreateAppSettingRequest
    {
        public string ReferenceKey { get; set; } = String.Empty;
        public string Value { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string Type { get; set; } = String.Empty;
    }
}

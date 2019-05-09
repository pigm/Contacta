namespace contacta.data.common.Models
{
    /// <summary>
    /// Common response to services.
    /// </summary>
    public struct CommonResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Response { get; set; }
        public int StatusCode { get; set; }
    }
}

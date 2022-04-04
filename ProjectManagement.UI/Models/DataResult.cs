namespace ProjectManagement.UI.Models
{
    public class DataResult<T>
    {
        public List<T> Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Statuscode { get; set; }
    }


}

namespace ProjectManagement.UI.Models
{
    public class OnlyDataResult<T>
    {
            public T Data { get; set; }
            public bool Success { get; set; }
            public string Message { get; set; }
            public string Statuscode { get; set; }
        }
    }

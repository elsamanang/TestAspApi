namespace TestAspApi.Commons
{
    public class Reponse<TData> where TData : class
    {
        public Reponse(bool isSucceed, string? message)
        {
            IsSucceed = isSucceed;
            Message = message;
        }

        public Reponse(bool isSucceed, string? message, TData? data)
        {
            IsSucceed = isSucceed;
            Message = message;
            Data = data;
        }

        public Reponse(bool isSucceed, string? message, int status, TData? data)
        {
            IsSucceed = isSucceed;
            Message = message;
            Status = status;
            Data = data;
        }

        public bool IsSucceed { get; set; }
        public string? Message { get; set; }
        public int Status { get; set; }
        public TData? Data { get; set; }
    }
}

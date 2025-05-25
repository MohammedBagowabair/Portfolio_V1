namespace Ultimate.WebApp.Model
{
    public class ResponsePut<T>
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public T Content { get; set; }

    }
}

namespace Ultimate.WebApp.Model
{
    public class ResponsePost<T>
    {
        public int Code { get; set; }
        public string Message { get; set; }


        public T Content { get; set; }
    }
}

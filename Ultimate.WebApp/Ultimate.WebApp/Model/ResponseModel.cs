namespace Ultimate.WebApp.Model
{
    public class ResponseModel<T>
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public List<T> Content { get; set; }
    }

    public class ResponseModel
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public object Content { get; set; }
    }
    public class ResponsGeneric<T>
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public T Content { get; set; }
    }


}

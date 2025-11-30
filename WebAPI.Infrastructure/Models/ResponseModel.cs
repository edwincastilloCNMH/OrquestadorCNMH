namespace WebAPI.Infrastructure.Models
{
    public class ResponseModel<T>
    {

        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public string Message { get; set; }

        public ResponseModel() { }

        public ResponseModel(T data)
        {
            this.Succeeded = true;
            this.Message = string.Empty;
            this.Errors = null;
            this.Data = data;
        }

    }
}

namespace ECommerce.Shared.Dtos
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> ErrorMessage { get; set; }

        public static ResponseDto<T> Success()
        {
            return new ResponseDto<T> { ErrorMessage = new List<string>(), IsSuccess = true, StatusCode = 200 };
        }

        public static ResponseDto<T> Success(T data)
        {
            return new ResponseDto<T> { Data = data, ErrorMessage = new List<string>(), IsSuccess = true, StatusCode = 200 };
        }

        public static ResponseDto<T> Fail(List<string> errors)
        {
            return new ResponseDto<T> { ErrorMessage = errors, IsSuccess = false, StatusCode = 400 };
        }
    }
}

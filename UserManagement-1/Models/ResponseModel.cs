namespace UserManagement_1.Models
{
   public class ResponseModel
    {
        public ResponseModel()
        {
            IsSuccess = false;
            Message = string.Empty;
            Response = null;
            Errors = string.Empty;
            TotalRecords = 0;
        }

        public bool IsSuccess { get; set; }
        public Status StatusCode { get; set; }
        public string Message { get; set; }
        public object Response { get; set; }
        public string Errors { get; set; }

        public int Status
        {
            get { return IsSuccess ? 200 : 400; }
        }

        public int TotalRecords { get; set; }
    }

    public enum Status
    {
        BadRequest = 400,
        Forbidden = 403,
        InternalServerError = 500,
        MethodNotAllowed = 405,
        NotFound = 404,
        OK = 200,
        RecordNotFound = 204,
        RequestTimeout = 408,
        Unauthorized = 401,
    }
}

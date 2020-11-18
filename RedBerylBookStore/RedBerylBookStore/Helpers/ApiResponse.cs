namespace RedBerylBookStore.Helpers
{
    using System.Dynamic;
    using Common.Enums;

    public class ApiResponse
    {
        public AcknowledgementType Acknowledgement { get; protected set; }
     
        public string ErrorMessage { get; set; }

        public dynamic Result { get; set; }

        public static ApiResponse OK(object result)
        {
            dynamic expando = new ExpandoObject();
            expando.data = result;
            return new ApiResponse
            {
                Acknowledgement = AcknowledgementType.Success,
                Result = expando
            };
        }

        public static ApiResponse BadRequest(string errorMessage, object result = null)
        {
            dynamic expando = new ExpandoObject();
            if (result != null)
            {
                expando.data = result;
            }

            return new ApiResponse
            {
                Acknowledgement = AcknowledgementType.Failure,
                Result = expando,
                ErrorMessage = errorMessage
            };
        }
    }
}
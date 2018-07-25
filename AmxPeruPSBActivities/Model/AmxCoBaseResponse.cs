namespace AmxCoPSBActivities.Model
{
    public class BaseResponse<TResponseType>
    {
        public TResponseType Value { get; set; }

        public bool Success { get; set; }

        public string ErrorMessage { get; set; }

        public string Message { get; set; }
    }
}
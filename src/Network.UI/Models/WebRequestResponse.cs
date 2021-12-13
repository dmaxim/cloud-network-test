
namespace Network.UI.Models
{
    public class WebRequestResponse
    {
        public WebRequestResponse(int statusCode)
        {
            StatusCode = statusCode;
        }

        public int StatusCode { get; }
    }
}

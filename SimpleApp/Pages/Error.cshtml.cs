using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SimpleApp
{
    public class ErrorModel : PageModel
    {
        public string ErrorCode { get; set; }
        public void OnGet(string errorCode)
        {
            ErrorCode = errorCode;
        }
    }
}
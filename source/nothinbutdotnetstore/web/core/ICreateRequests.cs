using System.Web;

namespace nothinbutdotnetstore.web.core
{
  public interface ICreateRequests
  {
    object create_request_from(HttpContext context);
  }
}
using System;
using System.Web;

namespace nothinbutdotnetstore.web.core
{
  public class RawHandler : IHttpHandler
  {
      private readonly IProcessIncomingRequests _processIncomingRequest;
      private readonly ICreateRequests _createRequests;

      public RawHandler(IProcessIncomingRequests processIncomingRequest, ICreateRequests createRequests)
      {
          _processIncomingRequest = processIncomingRequest;
          _createRequests = createRequests;
      }

      public void ProcessRequest(HttpContext context)
    {
      _processIncomingRequest.process(_createRequests.create_request_from(context));
    }

    public bool IsReusable
    {
      get { throw new NotImplementedException(); }
    }
  }
}
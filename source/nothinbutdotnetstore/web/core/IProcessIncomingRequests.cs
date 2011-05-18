using System;

namespace nothinbutdotnetstore.web.core
{
  public interface IProcessIncomingRequests
  {
    void process(object request);
  }

    public class FrontController : IProcessIncomingRequests

    {
        public void process(object request)
        {
            throw new NotImplementedException();
        }
    }
}
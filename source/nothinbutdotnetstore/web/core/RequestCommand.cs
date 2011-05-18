using System;

namespace nothinbutdotnetstore.web.core
{
  public class RequestCommand : IProcessRequestInformation
  {
    public void run(IContainRequestInformation request)
    {
      throw new NotImplementedException();
    }

    public bool can_process(IContainRequestInformation request)
    {
      throw new NotImplementedException();
    }
  }
}
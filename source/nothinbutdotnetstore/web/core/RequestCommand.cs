using System;

namespace nothinbutdotnetstore.web.core
{
  public class RequestCommand : IProcessRequestInformation
  {
      private readonly RequestCriteria request_criteria;

      public RequestCommand(RequestCriteria request_criteria)
      {
          this.request_criteria = request_criteria;
      }

      public void run(IContainRequestInformation request)
    {
      throw new NotImplementedException();
    }

    public bool can_process(IContainRequestInformation request)
    {
       return request_criteria(request);
    }
  }
}
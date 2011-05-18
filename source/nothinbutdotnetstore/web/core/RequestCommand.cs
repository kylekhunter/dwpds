using System;

namespace nothinbutdotnetstore.web.core
{
  public class RequestCommand : IProcessRequestInformation
  {
      private readonly RequestCriteria request_criteria;
      private readonly IProcessAnApplicationSpecificBehaviour behavior;

      public RequestCommand(RequestCriteria request_criteria, IProcessAnApplicationSpecificBehaviour behavior)
      {
          this.request_criteria = request_criteria;
          this.behavior = behavior;
      }

      public void run(IContainRequestInformation request)
    {
         behavior.run(request);
    }

    public bool can_process(IContainRequestInformation request)
    {
       return request_criteria(request);
    }
  }
}
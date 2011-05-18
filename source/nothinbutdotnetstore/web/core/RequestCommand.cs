namespace nothinbutdotnetstore.web.core
{
  public class RequestCommand : IProcessRequestInformation
  {
    RequestCriteria request_criteria;
    IProcessAnApplicationSpecificBehaviour application_behaviour;

    public RequestCommand(RequestCriteria request_criteria, IProcessAnApplicationSpecificBehaviour application_behaviour)
    {
      this.request_criteria = request_criteria;
      this.application_behaviour = application_behaviour;
    }

    public void run(IContainRequestInformation request)
    {
      application_behaviour.run(request);
    }

    public bool can_process(IContainRequestInformation request)
    {
      return request_criteria(request);
    }
  }
}
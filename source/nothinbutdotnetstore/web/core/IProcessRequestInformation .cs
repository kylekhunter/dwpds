namespace nothinbutdotnetstore.web.core
{
  public interface IProcessRequestInformation  : IProcessAnApplicationSpecificBehaviour
  {
    bool can_process(IContainRequestInformation request);
  }
}
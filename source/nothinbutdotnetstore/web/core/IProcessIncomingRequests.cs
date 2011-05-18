namespace nothinbutdotnetstore.web.core
{
  public interface IProcessIncomingRequests
  {
    void process(IContainRequestInformation request);
  }
}
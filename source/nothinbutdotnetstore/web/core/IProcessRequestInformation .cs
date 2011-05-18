namespace nothinbutdotnetstore.web.core
{
  public interface IProcessRequestInformation 
  {
    void run(IContainRequestInformation request);
    bool can_process(IContainRequestInformation request);
  }
}
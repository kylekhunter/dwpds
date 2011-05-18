namespace nothinbutdotnetstore.web.core
{
  public interface IProcessAnApplicationSpecificBehaviour 
  {
    void run(IContainRequestInformation request);
  }
}
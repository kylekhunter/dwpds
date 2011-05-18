namespace nothinbutdotnetstore.web.core
{
  public interface IFindCommands
  {
    IProcessRequestInformation get_the_command_that_can_process(IContainRequestInformation request);
  }
}
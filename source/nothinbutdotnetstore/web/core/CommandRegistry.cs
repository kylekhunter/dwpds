using System;

namespace nothinbutdotnetstore.web.core
{
  public class CommandRegistry : IFindCommands
  {
    public IProcessRequestInformation get_the_command_that_can_process(IContainRequestInformation request)
    {
      throw new NotImplementedException();
    }
  }
}
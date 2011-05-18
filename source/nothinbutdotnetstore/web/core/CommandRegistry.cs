using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.core
{
  public class CommandRegistry : IFindCommands
  {
    IEnumerable<IProcessRequestInformation> process_request_commands;

    public CommandRegistry(IEnumerable<IProcessRequestInformation> process_request_commands)
    {
      this.process_request_commands = process_request_commands;
    }

    public IProcessRequestInformation get_the_command_that_can_process(IContainRequestInformation request)
    {
      return process_request_commands.First(x => x.can_process(request));
    }
  }
}
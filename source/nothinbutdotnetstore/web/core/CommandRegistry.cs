using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.core
{
  public class CommandRegistry : IFindCommands
  {
    IEnumerable<IProcessRequestInformation> process_request_commands;
    MissingCommandFactory missing_command_factory;

    public CommandRegistry(IEnumerable<IProcessRequestInformation> process_request_commands, MissingCommandFactory missing_command_factory)
    {
      this.process_request_commands = process_request_commands;
      this.missing_command_factory = missing_command_factory;
    }

    public IProcessRequestInformation get_the_command_that_can_process(IContainRequestInformation request)
    {
      var result =  process_request_commands.FirstOrDefault(x => x.can_process(request));
      return result ?? missing_command_factory();
    }
  }
}
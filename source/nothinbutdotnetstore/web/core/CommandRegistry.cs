using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.core
{
  public class CommandRegistry : IFindCommands
  {
    IEnumerable<IProcessRequestInformation> process_request_commands;
    MissingCommandFactory missing_command_factory;

    public CommandRegistry():this(Stub.with<StubSetOfCommands>(),
      Stub.with<StubMissingRequest>().create)
    {
    }

    public CommandRegistry(IEnumerable<IProcessRequestInformation> process_request_commands, MissingCommandFactory missing_command_factory)
    {
      this.process_request_commands = process_request_commands;
      this.missing_command_factory = missing_command_factory;
    }

    public IProcessRequestInformation get_the_command_that_can_process(IContainRequestInformation request)
    {
      return process_request_commands.FirstOrDefault(x => x.can_process(request)) ?? missing_command_factory();
    }
  }
}
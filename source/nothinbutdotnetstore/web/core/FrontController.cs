namespace nothinbutdotnetstore.web.core
{
  public class FrontController : IProcessIncomingRequests
  {
    IFindCommands command_registry;

    public FrontController():this(new CommandRegistry())
    {
    }

    public FrontController(IFindCommands command_registry)
    {
      this.command_registry = command_registry;
    }

    public void process(IContainRequestInformation request)
    {
      command_registry.get_the_command_that_can_process(request).run(request);
    }
  }
}
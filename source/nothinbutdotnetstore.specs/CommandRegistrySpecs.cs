 using System.Collections.Generic;
 using System.Linq;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{  
  [Subject(typeof(CommandRegistry))]  
  public class CommandRegistrySpecs
  {
    public abstract class concern : Observes<IFindCommands,
                                      CommandRegistry>
    {
        
    }

   
    public class when_getting_the_command_that_can_process_a_request_and_it_has_the_command : concern
    {
      Establish c = () =>
      {
        all_possible_commands = Enumerable.Range(1, 100).Select(x => fake.an<IProcessRequestInformation>()).ToList();
        depends.on<IEnumerable<IProcessRequestInformation>>(all_possible_commands);

        request = fake.an<IContainRequestInformation>();
        the_command_that_can_process_the_request = fake.an<IProcessRequestInformation>();

        all_possible_commands.Add(the_command_that_can_process_the_request);


        the_command_that_can_process_the_request.setup(x => x.can_process(request))
          .Return(true);
      };

      Because b = () =>
        result = sut.get_the_command_that_can_process(request);


      It should_return_the_command_to_the_caller = () =>
        result.ShouldEqual(the_command_that_can_process_the_request);

      static IProcessRequestInformation result;
      static IProcessRequestInformation the_command_that_can_process_the_request;
      static IContainRequestInformation request;
      static IList<IProcessRequestInformation> all_possible_commands;
    }
  }
}

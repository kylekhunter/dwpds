 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{  
  [Subject(typeof(RequestCommand))]  
  public class RequestCommandSpecs
  {
    public abstract class concern : Observes<IProcessRequestInformation,
                                      RequestCommand>
    {
        
    }

   
    public class when_determining_if_it_can_process_a_request : concern
    {
      Establish c = () =>
      {
        request = fake.an<IContainRequestInformation>();
        depends.on<RequestCriteria>(x => x.Equals(request));
      };

      Because b = () =>
        result = sut.can_process(request);


      It should_make_the_determination_by_using_its_request_specification = () =>
        result.ShouldEqual(true);


      static bool result;
      static IContainRequestInformation request;
    }

    public class when_processing_a_request : concern
    {
      Establish c = () =>
      {
        request = fake.an<IContainRequestInformation>();
        application_command = depends.on<IProcessAnApplicationSpecificBehaviour>();
      };

      Because b = () =>
        sut.run(request);



      It should_delegate_to_the_application_specific_behaviour = () =>
        application_command.received(x => x.run(request));



      static bool result;
      static IContainRequestInformation request;
      static IProcessAnApplicationSpecificBehaviour application_command;
    }
  }
}

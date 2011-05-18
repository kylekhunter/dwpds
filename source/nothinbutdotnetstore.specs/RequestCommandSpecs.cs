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
        depends.on<RequestCriteria>(x => x.Equals(request));
        request = fake.an<IContainRequestInformation>();
      };

      Because b = () =>
        result = sut.can_process(request);


      It should_make_the_determination_by_using_its_request_specification = () =>
        result.ShouldEqual(true);


      static bool result;
      static IContainRequestInformation request;
    }
  }
}

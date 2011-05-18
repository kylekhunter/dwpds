 using System.Web;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.specs.utility;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{   
    [Subject(typeof(RawHandler))]
  public class RawHandlerSpecs
  {
    public abstract class concern : Observes<IHttpHandler ,
                                      RawHandler>
    {
        
    }

    public class when_processing_an_incoming_http_context  : concern
    {
      Establish c = () =>
      {
        front_controller = depends.on<IProcessIncomingRequests>();
        request_factory = depends.on<ICreateRequests>();

        request = fake.an<IContainRequestInformation>();
        the_current_context = ObjectFactory.web.create_http_context();

        request_factory.setup(x => x.create_request_from(the_current_context)).Return(request);
      };

      Because b = () =>
        sut.ProcessRequest(the_current_context);

        
      It should_dispatch_processing_of_a_request_to_the_front_controller = () =>
        front_controller.received(x => x.process(request));


      static IProcessIncomingRequests front_controller;
      static IContainRequestInformation request;
      static HttpContext the_current_context;
      static ICreateRequests request_factory;
    }
  }
}

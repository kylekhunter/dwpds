using System;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.specs
{
    public class StubGatewaySpecs
    {
        public abstract class concern : Observes<StubGateway>
        {
           
        }

        [Subject(typeof (StubGateway))]
        public class when_a_stub_is_requested : concern
        {
            private Establish c = () =>
                                      {
                                          
                                      };

            private Because b = () => 
               stub =  StubGateway.GetStub<StubDisplayEngine>();


            private It should_return_new_display_engine_stub = () =>
            {
                stub.ShouldNotBeNull();
            };
                    
                  static  object stub;
                           
        }
    }
}

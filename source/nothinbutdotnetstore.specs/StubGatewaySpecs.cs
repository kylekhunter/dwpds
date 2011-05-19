using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.specs
{
  public class StubGatewaySpecs
  {
    public abstract class concern : Observes<Stub>
    {
    }

    [Subject(typeof(Stub))]
    public class when_a_stub_is_requested : concern
    {
      Establish c = () => { };

      Because b = () =>
        stub = Stub.with<OurItemToStub>();

      It should_return_new_display_engine_stub = () => { stub.ShouldNotBeNull(); };

      static object stub;
    }

    public class OurItemToStub
    {
    }
  }
}
 using System.Web;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{   
  [Subject(typeof(RenderDisplay))]
  public class CanRenderInformationSpecs
  {
    public abstract class concern : Observes<ICanRenderInformation,
                                      RenderDisplay>
    {
        
    }

    public class when_observation_name : concern
    {
      Establish c = () =>
      {
        depends.on<HttpContext>();
        report_model = fake.an<ReportModel>();
      };

      Because b = () =>
        sut.display(report_model);

      private It should_return_a_report_model_for_the_view =
        () =>
          {

          };

      private It should_add_the_report_model_to_the_http_context =
        () =>
          {
            HttpContext.Current.Items.Contains("blah");
          };

      private static object report_model;
    }
  }
}

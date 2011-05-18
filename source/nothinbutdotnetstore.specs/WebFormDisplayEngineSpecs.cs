using System.Web;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.aspnet;
using developwithpassion.specifications.extensions;

namespace nothinbutdotnetstore.specs
{
  [Subject(typeof(WebFormDisplayEngine))]
  public class WebFormDisplayEngineSpecs
  {
    public abstract class concern : Observes<ICanRenderInformation,
                                      WebFormDisplayEngine>
    {
    }

    public class when_displaying_a_report_model : concern
    {
      Establish c = () =>
      {
        the_active_context = ObjectFactory.web.create_http_context();

        depends.on<CurrentContextResolver>(() => the_active_context);
        view = fake.an<IHttpHandler>();
        view_factory = depends.on<ICreateAnAspxTemplateForAReportModel>();
        report_model = new OurReportModel();

        view_factory.setup(x => x.create_view_to_render(report_model)).Return(view);
      };

      Because b = () =>
        sut.display(report_model);

      It should_create_the_view_that_can_display_the_report_model = () =>
      {

      };

      It should_tell_the_view_to_render_in_the_active_context = () =>
        view.received(x => x.ProcessRequest(the_active_context));

  


      static OurReportModel report_model;
      static ICreateAnAspxTemplateForAReportModel view_factory;
      static IHttpHandler view;
      static HttpContext the_active_context;
    }

    public class OurReportModel
    {
    }
  }
}
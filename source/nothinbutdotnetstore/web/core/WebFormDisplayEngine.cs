using System.Web;
using nothinbutdotnetstore.web.core.aspnet;

namespace nothinbutdotnetstore.web.core
{
  public class WebFormDisplayEngine : ICanRenderInformation
  {
    ICreateAnAspxTemplateForAReportModel view_factory;
    CurrentContextResolver current_context_resolver;

    public WebFormDisplayEngine():this(new WebFormFactory(),
      () => HttpContext.Current)
    {
    }

    public WebFormDisplayEngine(ICreateAnAspxTemplateForAReportModel view_factory,
                                CurrentContextResolver current_context_resolver)
    {
      this.view_factory = view_factory;
      this.current_context_resolver = current_context_resolver;
    }

    public void display<ReportModel>(ReportModel report_model)
    {
      view_factory.create_view_to_render(report_model).ProcessRequest(current_context_resolver());
    }
  }
}
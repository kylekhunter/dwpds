using System.Web;
using System.Web.Compilation;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.core.aspnet
{
  public class WebFormFactory : ICreateAnAspxTemplateForAReportModel
  {
    PageFactory page_factory;

    IFindAspxPagesForReportModels page_registry;

    public WebFormFactory():this(BuildManager.CreateInstanceFromVirtualPath,
      Stub.with<StubPathRegistry>())
    {
    }

    public WebFormFactory(PageFactory page_factory, IFindAspxPagesForReportModels page_registry)
    {
      this.page_factory = page_factory;
      this.page_registry = page_registry;
    }

    public IHttpHandler create_view_to_render<ReportModel>(ReportModel report_model)
    {
      var view =
        (IReportModelBoundAspx<ReportModel>)
          page_factory(page_registry.get_the_path_to_a_page_that_can_render<ReportModel>(),
                       typeof(IReportModelBoundAspx<ReportModel>));
      view.model = report_model;
      return view;
    }
  }
}
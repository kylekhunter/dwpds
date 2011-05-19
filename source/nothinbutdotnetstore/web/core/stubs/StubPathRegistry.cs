using System.Collections.Generic;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core.aspnet;

namespace nothinbutdotnetstore.web.core.stubs
{
  public class StubPathRegistry : IFindAspxPagesForReportModels
  {
    public string get_the_path_to_a_page_that_can_render<ReportModel>()
    {
      if (typeof(ReportModel).Equals(typeof(IEnumerable<DepartmentItem>))) return create_path_to("DepartmentBrowser");
      return create_path_to("ProductBrowser");
    }

    string create_path_to(string page)
    {
      return string.Format("~/views/{0}.aspx", page);
    }
  }
}
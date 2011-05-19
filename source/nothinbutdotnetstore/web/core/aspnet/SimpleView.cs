using System.Web.UI;

namespace nothinbutdotnetstore.web.core.aspnet
{
  public class SimpleView<ReportModel> : Page,IReportModelBoundAspx<ReportModel>
  {
    public ReportModel model { get; set; }
  }
}
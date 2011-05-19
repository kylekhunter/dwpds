using System.Web;

namespace nothinbutdotnetstore.web.core.aspnet
{
  public interface IReportModelBoundAspx<ReportModel> : IHttpHandler
  {
    ReportModel model { get; set; }
  }
}
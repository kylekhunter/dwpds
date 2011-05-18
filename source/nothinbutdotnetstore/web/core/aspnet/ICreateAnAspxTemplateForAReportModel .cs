using System.Web;

namespace nothinbutdotnetstore.web.core.aspnet
{
  public interface ICreateAnAspxTemplateForAReportModel 
  {
    IHttpHandler create_view_to_render<ReportModel>(ReportModel report_model);
  }
}
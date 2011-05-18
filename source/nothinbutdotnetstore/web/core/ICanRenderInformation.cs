namespace nothinbutdotnetstore.web.core
{
  public interface ICanRenderInformation
  {
    void display<ReportModel>(ReportModel report_model);
  }
}
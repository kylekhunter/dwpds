using System.Collections.Generic;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
  public interface ICanFindDetailsInTheStore
  {
    IEnumerable<DepartmentItem> get_the_main_departments();
  }
}
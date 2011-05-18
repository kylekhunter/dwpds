using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.application.catalogbrowsing.stubs
{
  public class StubStoreCatalog : ICanFindDetailsInTheStore
  {
    public IEnumerable<DepartmentItem> get_the_main_departments()
    {
      return Enumerable.Range(1, 100).Select(x => new DepartmentItem {name = x.ToString("Department 0")});
    }

    public IEnumerable<DepartmentItem> get_departments_for(DepartmentItem department)
    {
      return Enumerable.Range(1, 100).Select(x => new DepartmentItem {name = x.ToString("Sub Department 0")});
    }
  }
}
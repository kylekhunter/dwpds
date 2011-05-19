using System.Collections.Generic;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
  public interface ICanFindDetailsInTheStore
  {
    IEnumerable<DepartmentItem> get_the_main_departments();
    IEnumerable<DepartmentItem> get_departments_for(DepartmentItem department);
    IEnumerable<ProductItem> get_products_for(DepartmentItem department);
  }
}
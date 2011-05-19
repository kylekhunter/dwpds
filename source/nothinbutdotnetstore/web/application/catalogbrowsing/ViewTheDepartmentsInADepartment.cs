using nothinbutdotnetstore.web.application.catalogbrowsing.stubs;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
  public class ViewTheDepartmentsInADepartment : IProcessAnApplicationSpecificBehaviour
  {
    ICanRenderInformation display_engine;
    ICanFindDetailsInTheStore store_catalog;

    public ViewTheDepartmentsInADepartment():this(new WebFormDisplayEngine(),
      new StubStoreCatalog())
    {
    }

    public ViewTheDepartmentsInADepartment(ICanRenderInformation display_engine,
                                           ICanFindDetailsInTheStore store_catalog)
    {
      this.display_engine = display_engine;
      this.store_catalog = store_catalog;
    }

    public void run(IContainRequestInformation request)
    {
      display_engine.display(store_catalog.get_departments_for(request.map<DepartmentItem>()));
    }
  }
}
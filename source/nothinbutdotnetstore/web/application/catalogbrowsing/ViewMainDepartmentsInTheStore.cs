using nothinbutdotnetstore.web.application.catalogbrowsing.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
  public class ViewMainDepartmentsInTheStore : IProcessAnApplicationSpecificBehaviour
  {
    ICanFindDetailsInTheStore store_catalog;

    ICanRenderInformation display_engine;

    public ViewMainDepartmentsInTheStore():this(new StubStoreCatalog(),
      new StubDisplayEngine())
    {
    }

    public ViewMainDepartmentsInTheStore(ICanFindDetailsInTheStore store_catalog, ICanRenderInformation display_engine)
    {
      this.store_catalog = store_catalog;
      this.display_engine = display_engine;
    }

    public void run(IContainRequestInformation request)
    {
      display_engine.display(store_catalog.get_the_main_departments());
    }
  }
}
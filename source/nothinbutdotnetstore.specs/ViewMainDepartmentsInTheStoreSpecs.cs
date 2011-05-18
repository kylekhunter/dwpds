 using System.Collections.Generic;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.web.application.catalogbrowsing;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{  
  [Subject(typeof(ViewMainDepartmentsInTheStore))]  
  public class ViewMainDepartmentsInTheStoreSpecs
  {
    public abstract class concern : Observes<IProcessAnApplicationSpecificBehaviour,
                                      ViewMainDepartmentsInTheStore>
    {
        
    }

   
    public class when_run : concern
    {
      Establish c = () =>
      {
        display_engine = depends.on<ICanRenderInformation>();
        store_catalog = depends.on<ICanFindDetailsInTheStore>();
        request = fake.an<IContainRequestInformation>();

        the_main_departments = new List<DepartmentItem> {new DepartmentItem()};

        store_catalog.setup(x => x.get_the_main_departments()).Return(the_main_departments);
      };

      Because b = () =>
        sut.run(request);


      It should_get_the_list_of_the_main_departments_in_the_store = () =>
      {
      };

      It should_tell_the_display_engine_to_display_the_departments = () =>
        display_engine.received(x => x.display(the_main_departments));

  

      static ICanFindDetailsInTheStore store_catalog;
      static IContainRequestInformation request;
      static ICanRenderInformation display_engine;
      static IEnumerable<DepartmentItem> the_main_departments;
    }
  }
}

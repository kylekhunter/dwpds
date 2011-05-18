using System.Collections.Generic;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
  [Subject(typeof(ViewTheDepartmentsInADepartment))]  
  public class ViewTheDepartmentsInADepartmentSpecs
  {
    public abstract class concern : Observes<IProcessAnApplicationSpecificBehaviour,
                                      ViewTheDepartmentsInADepartment>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        department = depends.on<DepartmentItem>();
        store_catalog = depends.on<ICanFindDetailsInTheStore>();
        display_engine = depends.on<ICanRenderInformation>();
        request = fake.an<IContainRequestInformation>();
        sub_departments = new List<DepartmentItem> {new DepartmentItem()};

        store_catalog.setup(x => x.get_departments_for(department)).Return(sub_departments);
      };

      Because b = () =>
        sut.run(request);

      It should_get_the_list_of_departments_for_a_given_department = () =>
      {

      };

      It should_tell_the_display_engine_to_display_the_departments = () =>
        display_engine.received(x => x.display(sub_departments));

      static IContainRequestInformation request;
      static ICanRenderInformation display_engine;
      static ICanFindDetailsInTheStore store_catalog;
      static DepartmentItem department;
      static List<DepartmentItem> sub_departments;
    }
  }
}
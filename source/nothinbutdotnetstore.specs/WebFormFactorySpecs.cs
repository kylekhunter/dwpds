using System.Web;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using nothinbutdotnetstore.web.core.aspnet;

namespace nothinbutdotnetstore.specs
{
  [Subject(typeof(WebFormFactory))]
  public class WebFormFactorySpecs
  {
    public abstract class concern : Observes<ICreateAnAspxTemplateForAReportModel,
                                      WebFormFactory>
    {
    }

    public class when_creating_an_aspx_httphandler_for_a_report_model : concern
    {
      Establish c = () =>
      {
        the_model = new OurModel();
        path_to_page = "the_path_to_THe_page";

        depends.on<PageFactory>((path,type) =>
        {
          path.ShouldEqual(path_to_page);
          type.ShouldEqual(typeof(IReportModelBoundAspx<OurModel>));
          return view;
        });

        aspx_page_registry = depends.on<IFindAspxPagesForReportModels>();
        view = fake.an<IReportModelBoundAspx<OurModel>>();
        aspx_page_registry.setup(x => x.get_the_path_to_a_page_that_can_render<OurModel>()).Return(path_to_page);
      };

      Because b = () =>
        result = sut.create_view_to_render(the_model);


      It should_populate_the_view_with_its_report_model = () =>
        view.model.ShouldEqual(the_model);


      It should_return_the_Created_view = () =>
        result.ShouldEqual(view);
  


      static IHttpHandler result;
      static IFindAspxPagesForReportModels aspx_page_registry;
      static IReportModelBoundAspx<OurModel> view;
      static OurModel the_model;
      static string path_to_page;
    }

    public class OurModel
    {
    }
  }
}
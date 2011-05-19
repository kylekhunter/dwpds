 using System.Collections.Generic;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.web.application.catalogbrowsing;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{   
    [Subject(typeof(ViewProducts))]
    public class ViewProductsSpecs
    {
        public abstract class concern : Observes<IProcessAnApplicationSpecificBehaviour,
                                            ViewProducts>
        {
        
        }

        public class when_observation_name : concern
        {
            Establish c = () =>
            {
                store_catalog = depends.on<ICanFindDetailsInTheStore>();
                display_engine = depends.on<ICanRenderInformation>();

                parent_department = fake.an<DepartmentItem>();
                request = fake.an<IContainRequestInformation>();
                products = new List<ProductItem> { new ProductItem() };

                request.setup(x => x.map<DepartmentItem>()).Return(parent_department);

                store_catalog.setup(x => x.get_products_for(parent_department)).Return(products);
            };

            Because b = () =>
              sut.run(request);

            It should_get_the_list_of_products_for_a_given_department = () =>
            {
            };

            It should_tell_the_display_engine_to_display_the_products = () =>
              display_engine.received(x => x.display(products));

            static IContainRequestInformation request;
            static ICanRenderInformation display_engine;
            static ICanFindDetailsInTheStore store_catalog;
            static DepartmentItem parent_department;
            static IEnumerable<ProductItem> products;
        }
    }
}

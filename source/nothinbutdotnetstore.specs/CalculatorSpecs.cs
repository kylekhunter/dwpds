using System;
using System.Data;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using developwithpassion.specifications.extensions;

namespace nothinbutdotnetstore.specs
{
  [Subject(typeof(Calculator))]
  public class CalculatorSpecs
  {
    public abstract class concern : Observes<Calculator>
    {
    }

    public class when_adding_two_positive_numbers : concern
    {
      Establish c = () =>
      {
        connection = depends.on<IDbConnection>();
        command = fake.an<IDbCommand>();

        connection.setup(x => x.CreateCommand()).Return(command);
      };

      Because b = () =>
        result = sut.add(2, 3);

      It should_return_the_sum = () =>
        result.ShouldEqual(5);

      It should_connect_to_the_database = () =>
        connection.received(x => x.Open());

      It should_run_a_query = () =>
        command.received(x => x.ExecuteNonQuery());


      static int result;
      static IDbConnection connection;
      static IDbCommand command;
    }

    public class when_attempting_to_add_a_negative_number : concern
    {
      Because b = () =>
        spec.catch_exception(() => sut.add(2, -1));

      It should_throw_an_argument_exception = () =>
        spec.exception_thrown.ShouldBeAn<ArgumentException>();

    }
  }
}
using System;
using System.Data;
using System.Security;
using System.Security.Principal;
using System.Threading;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using Rhino.Mocks;

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

      It should_dispose_the_connection_and_command = () =>
      {
        connection.received(x => x.Dispose());
        command.received(x => x.Dispose());
      };

      static int result;
      static IDbConnection connection;
      static IDbCommand command;
    }
    public class when_attempting_to_shut_down_the_calculator_and_they_are_not_in_the_correct_security_role : concern
    {
      Establish c = () =>
      {
        fake_principal = fake.an<IPrincipal>();

        spec.change(() => Thread.CurrentPrincipal).to(fake_principal);

        fake_principal.setup(x => x.IsInRole(Arg<string>.Is.Anything)).Return(false);
      };

      Because b = () =>
        spec.catch_exception(() => sut.shut_down());



      It should_throw_a_security_exception = () =>
        spec.exception_thrown.ShouldBeAn<SecurityException>();


      static int result;
      static IDbConnection connection;
      static IDbCommand command;
      static IPrincipal fake_principal;
    }
    public class when_attempting_to_shut_down_the_calculator_and_they_are_in_the_correct_security_role: concern
    {
      Establish c = () =>
      {
        fake_principal = fake.an<IPrincipal>();

        spec.change(() => Thread.CurrentPrincipal).to(fake_principal);

        fake_principal.setup(x => x.IsInRole(Arg<string>.Is.Anything)).Return(true);
      };

      Because b = () =>
        sut.shut_down();


      It should_not_throw_a_security_exception = () =>
      {
      };


      static int result;
      static IDbConnection connection;
      static IDbCommand command;
      static IPrincipal fake_principal;
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
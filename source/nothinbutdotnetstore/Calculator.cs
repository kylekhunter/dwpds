using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.Threading;

namespace nothinbutdotnetstore
{
  public class Calculator
  {
    IDbConnection connection;

    public Calculator(IDbConnection connection,int number,int number2)
    {
      this.connection = connection;
    }

    public int add(int first_number, int second_number)
    {
      ensure_all_numbers_are_positive(first_number, second_number);
      using(connection)
      using (var command = connection.CreateCommand())
      {
        connection.Open();
        command.ExecuteNonQuery();
      }

      return first_number + second_number;
    }

    void ensure_all_numbers_are_positive(params int[] values)
    {
      if (values.Any(x => x < 0)) throw new ArgumentException();
    }

    public void shut_down()
    {
      ensure_in_correct_security_role();
    }

    void ensure_in_correct_security_role()
    {
      if (Thread.CurrentPrincipal.IsInRole("blasdfsdf")) return;
      throw new SecurityException();
    }
  }
}
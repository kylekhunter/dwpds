using System;
using System.Data;
using System.Linq;

namespace nothinbutdotnetstore
{
  public class Calculator
  {
    IDbConnection connection;

    public Calculator(IDbConnection connection)
    {
      this.connection = connection;
    }

    public int add(int first_number, int second_number)
    {
      ensure_all_numbers_are_positive(first_number, second_number);
      connection.Open();
      connection.CreateCommand().ExecuteNonQuery();

      return first_number + second_number;
    }

    void ensure_all_numbers_are_positive(params int[] values)
    {
      if (values.Any(x => x < 0)) throw new ArgumentException();
    }
  }
}
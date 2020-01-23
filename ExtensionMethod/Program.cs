using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {

        // write to console the date format using the extension method
        DateTime dd = new DateTime(2014, 09, 08);
        Console.WriteLine(dd.ToMyFormat());

        // write to console the date format using the extension method - with bool parameter
        Console.WriteLine(new DateTime(2014, 09, 08).ToMyFormat(false));

        // write to console the string format using the string extension method
        string myString = "this is my string";
        Console.WriteLine(myString.ToMyFormat());

        string g = "payal";
        Console.WriteLine(g.ToReverseString());

        //Interface extenction
        Something something = new Something();
        something.GetSomethingElse();

        //Generic
        List<string> test = new List<string>(new string[] {
            "David", "Morgan", "Philip" });
        Console.WriteLine(test.AsDelimited(" => "));

        List<int> primes = new List<int>(new int[] {
            2, 3, 5, 7, 11, 13, 17 });
        Console.WriteLine(primes.AsDelimited(" , "));

        //Chaining Extension Methods
        Console.WriteLine("I have "+"Cat".Pluralize().Capitalize());
    }
}

//Chaining Extension Methods
public static class StringHelper
{
    public static string Pluralize(this string s)
    {
        return s += "s";
    }

    public static string Capitalize(this string s)
    {
        return s.ToUpper();
    }
}

//Generic
static class EnumerableExtensions
{
    public static string AsDelimited<T>(this List<T> obj, string delimiter)
    {
        List<string> items = new List<string>();
        foreach (T data in obj)
        {
            items.Add(data.ToString());
        }
        return String.Join(delimiter, obj.ToArray());
    }
}

public static class StringExtensions
{
    public static string ToReverseString(this string s)
    {
        char[] array = s.ToCharArray();
        Array.Reverse(array);
        return new string(array);
    }
}

public static class DateTimeExtensions
{
    // extension method - specified using the 'this' keyword as the first parameter
    public static string ToMyFormat(this DateTime dateTime)
    {
        return "My format " + dateTime.ToString("yyyy-MM-dd");
    }


    public static string ToMyFormat(this DateTime dateTime, bool reverse)
    {
        string result = string.Empty;
        return result = reverse ? "My format " +
            dateTime.ToString("yyyy-MM-dd") :
            "My format " + dateTime.ToString("dd-MM-yyyy");
    }

    public static string ToMyFormat(this string mystring)
    {
        return "My format " + mystring.ToUpper();
    }

}

//Interface 
public interface ISomething
{
    void GetSomething();
}

public static class SomethingExtensions
{
    public static void GetSomethingElse(this ISomething something)
    {
        Console.WriteLine("Something Else");
    }
}
public class Something : ISomething
{
    public void GetSomething()
    {
        Console.WriteLine("Something");
    }
}
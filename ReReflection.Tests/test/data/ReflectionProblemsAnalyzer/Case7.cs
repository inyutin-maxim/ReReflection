using System;

namespace N
{
public class A<T>
{

public class B<T1>
{

}


public class C
{

}
}


    static void Main(string[] args)
    {
      var t = typeof(A<>.B<>).MakeGenericType(typeof(int), typeof(int)); //correct
      var types = new Type[] { typeof(int), typeof(int) };
      var t1 = typeof(A<>.B<>).MakeGenericType(types); //correct
      var t2 = typeof(A<>.C).MakeGenericType(typeof(int), typeof(int));
    }
  }
}

# ConvertToNullable

A simple static C# method that allows you to convert any primitive value to a nullable value of any other primitive type (provided the two types are compatible). This works whether the input primitive is non-nullable or nullable.

**The use-case for this method is, of course, extremely niche**. It's only needed in cases where you are forced to receive numeric primitives via plain object references and then must convert them to a nullable numeric primitive without knowing beforehand the bit-ness or nullability of the values you are receiving. 

For example, perhaps you are receiving both nullable and non-nullable 32-bit integers via a plain object reference and then you must convert all of them to nullable 64-bit integers.

Usage is like so:

```
object a = 5;
long? d = NullableHelper.ConvertToNullable<long>(a);
```

For the story on why this very niche method came to be created, see below!

## ...Why? Just, why?!

In C#, when dealing with a non-nullable integer that is referenced as a plain object, converting it to a nullable integer of a different type becomes needlessly difficult.

```
object a = 5;       //Becomes an int under the hood
int? b = (int?)a;   //Works
long? c = (long?)b; //Works
long? d = (long?)a; //Doesn't work, invalid cast exception.
```

Why the last line doesn't work is strange, especially given that it works when strongly typed:

```
int a = 5;
long? d = (long?) a; //Works
```

Whatever incompatibility exists between different-typed nullables is apparently resolved by the compiler when the types of both variables are known beforehand, but it doesn't work when the input variable is referenced as an object. Even when the input variable is an object, it only takes one extra cast to get the desired result, but what if you are working in a very type-agnostic environment for some reason?

I had a need in my project to dynamically convert a set of heterogeneous integer inputs into nullable 64-bit integers. In this project I was forced to receive those integers as objects, thus I could not rely on the compiler's ihelp. Moreover, I could not know beforehand whether the inputted integers were 32- or 64-bit, nor could I know whether they were already nullable or not. So, I whipped up a quick, simple method to accomplish the task.


## How does it work?

Under the hood, the method essentially works by first attempting to cast the inputted object to the desired nullable type directly and, if that fails, it instead converts the input to the non-nullable version of the desired type and then converts that intermediate value into the desired nullable version of that type. With these two different behaviors, the method can produce the same output from either already-nullable objects or non-nullable objects. (But if you supply a non-struct object as input, e.g. a string, the method will of course fail)

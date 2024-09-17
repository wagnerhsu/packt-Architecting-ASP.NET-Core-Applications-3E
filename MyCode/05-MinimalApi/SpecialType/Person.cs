using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SpecialType;

public class Person : IBindableFromHttpContext<Person>
{
    public required string Name { get; set; }
    public required DateOnly Birthday { get; set; }

    public static ValueTask<Person?> BindAsync(HttpContext context, ParameterInfo parameter)
    {
        // Example implementation
        var person = new Person
        {
            Name = context.Request.Query["name"],
            Birthday = DateOnly.Parse(context.Request.Query["birthday"])
        };
        return new ValueTask<Person?>(person);
    }
}
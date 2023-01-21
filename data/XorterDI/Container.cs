using System.Reflection;

namespace XorterDI;

public class Container
{
    private Dictionary<Type, object> Bindings { get; set; } = new();

    public void Bind<T>(T value)
    {
        Bindings.Add(typeof(T), value);
    }

    public void SetBindings<T>(T value)
    {
        MethodInfo method = GetInjectMethod<T>();
        object[] values = GetMethodParametersValues(method);

        method.Invoke(value, values);
    }

    private static MethodInfo GetInjectMethod<T>()
    {
        Type type = typeof(T);
        MethodInfo[] methods = type.GetMethods();

        return methods.Single(m => m.GetCustomAttribute<InjectAttribute>() is not null);
    }

    private object[] GetMethodParametersValues(MethodInfo method)
    {
        ParameterInfo[] parameters = method.GetParameters();
        var result = new object[parameters.Length];

        for (int i = 0; i < parameters.Length; i++)
        {
            Type type = parameters[i].ParameterType;

            result[i] = Bindings.First(b => b.Key == type).Value;
        }

        return result;
    }
}

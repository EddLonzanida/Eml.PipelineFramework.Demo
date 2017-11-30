using System;

namespace Eml.PipelineFramework.Tests.Integration.Helpers
{
    public static class TypeExtensions
    {
        public static bool IsAssignableTo<TTarget>(this Type type)
        {
            return typeof(TTarget).IsAssignableFrom(type);
        }
    }
}

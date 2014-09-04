namespace UmbracoV7Demo.Infrastructure.Interfaces
{
    using System.Collections.Generic;

    public interface IPaged<T> : IEnumerable<T>
    {
        int Count { get; }

        IEnumerable<T> GetRange(int index, int count);
    }
}

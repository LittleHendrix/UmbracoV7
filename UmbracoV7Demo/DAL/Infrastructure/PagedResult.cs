namespace UmbracoV7Demo.DAL.Infrastructure
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using UmbracoV7Demo.DAL.Interfaces;

    public class PagedResult<T> : IPaged<T>
    {
        private readonly IQueryable<T> source;

        public PagedResult(IQueryable<T> source)
        {
            this.source = source;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.source.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public int Count
        {
            get
            {
                return this.source.Count();
            }
        }

        public IEnumerable<T> GetRange(int index, int count)
        {
            return this.source.Skip(index).Take(count);
        }
    }
}
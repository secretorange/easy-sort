using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SecretOrange.Data
{
    public class EasySort<T> where T : class
    {
        private readonly IDictionary<string, Expression<Func<T, object>>> KeySelectors;

        public EasySort()
        {
            KeySelectors = new Dictionary<string, Expression<Func<T, object>>>();
        }

        public EasySort(IDictionary<string, Expression<Func<T, object>>> keySelectors)
        {
            KeySelectors = keySelectors;
        }

        public EasySort<T> Map(string key, Expression<Func<T, object>> keySelector)
        {
            KeySelectors.Add(key, keySelector);

            return this;
        }

        public IQueryable<T> Sort(IQueryable<T> query, string key, Order order)
        {
            Expression<Func<T, object>> sort;

            if (KeySelectors.ContainsKey(key))
            {
                sort = KeySelectors[key];

                if (order == Order.Desc)
                {
                    query = query.OrderByDescending(sort);
                }
                else
                {
                    query = query.OrderBy(sort);
                }
            }

            return query;
        }
    }

    public enum Order
    {
        Unknown,
        Asc,
        Desc
    }
}

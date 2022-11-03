using ArchiLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiLibrary.Extensions
{
    public static class QueryExtensions
    {

        public static IOrderedQueryable<TModel> Sort<TModel>(this IQueryable<TModel> query, Params p)
        {
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Demo1.Extensions;
using LinqToQuerystring;

namespace Demo1.KendoHelper
{
    public static class KendoUiHelper
    {
        public static KendoGridResult<T> ReturnGridData<T>(KendoGridQueryModel requestParams, IQueryable<T> collection)
        {
            var collectionType = typeof(T);
            var collectionProperties = collectionType.GetProperties();

            //filter
            if (requestParams.FilterUri.IsNotEmpty())
            {
                collection = collection.LinqToQuerystring(requestParams.FilterUri);
            }

            //Order
            if (requestParams.EnableOrder == true)
            {
                if (requestParams.SortOn.IsNotEmpty())
                {
                    if (requestParams.SortOrd.IsNotEmpty())
                    {
                        collection = requestParams.SortOrd == "desc"
                                     ? collection.OrderByDescending(requestParams.SortOn)
                                     : collection.OrderBy(requestParams.SortOn);
                    }
                    else
                        collection = collection.OrderBy(requestParams.SortOn);
                }
                else
                {
                    var p = collectionType.GetProperties().FirstOrDefault(z => z.Name.ToUpper() == "ID");
                    if (p == null)
                        p = collectionType.GetProperties().First();

                    collection = collection.OrderBy(p.Name);
                }
            }

            //Pagination
            IQueryable<T> gridData = collection;
            if (requestParams.EnablePagination == true)
            {
                if (requestParams.Skip.HasValue)
                    gridData = gridData.Skip(requestParams.Skip.Value);

                if (requestParams.Take.HasValue)
                    gridData = gridData.Take(requestParams.Take.Value);
            }


            var rto = new KendoGridResult<T>()            
            {
                Items = gridData.ToList(),
                TotalCount = collection.Count()
            };
            return rto;
        }
         


    }
}
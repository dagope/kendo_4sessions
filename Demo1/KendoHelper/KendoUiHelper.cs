using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Demo1.Extensions;

namespace Demo1.KendoHelper
{
    public static class KendoUiHelper
    {
        public static KendoGridResult<T> ParseGridData<T>(IQueryable<T> collection)
        {
            return ParseGridData<T>(collection, new KendoGridQueryModel());
        }
        public static KendoGridResult<T> ParseGridData<T>(IQueryable<T> collection, KendoGridQueryModel requestParams)
        {
            if (requestParams.Export.IsNotEmpty())
            {
                //ReturnXlsExport<T>(collection, requestParams);
            }
            else
            {
                return ReturnGridData<T>(requestParams, ref collection);
            }

            return null;
        }


        //private static void ReturnXlsExport<T>(IQueryable<T> collection, KendoGridPost requestParams)
        //{
        //    var o2x = new ObjectsToXls();
        //    o2x.AddSheet((IEnumerable<object>)collection, requestParams.Export);
        //    o2x.WriteToHttpResponse(requestParams.Export + ".xlsx");
        //}

        public static KendoGridResult<T> ReturnGridData<T>(KendoGridQueryModel requestParams, ref IQueryable<T> collection)
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
                var collectionType = typeof(T);
                var collectionProperties = collectionType.GetProperties();
                var p = collectionType.GetProperties().FirstOrDefault(z => z.Name.ToUpper() == "ID");
                if (p == null)
                    p = collectionType.GetProperties().First();

                collection = collection.OrderBy(p.Name);
            }

            IQueryable<T> gridData = collection;
            if (requestParams.Skip.HasValue)
                gridData = gridData.Skip(requestParams.Skip.Value);

            if (requestParams.Take.HasValue)
                gridData = gridData.Take(requestParams.Take.Value);


            return new KendoGridResult<T>
            {
                Items = gridData.ToList(),
                TotalCount = collection.Count()
            };


        }


        /*
         
         public GridResult<T> returnDataPaginationOrder<T>(KendoGridQueryModel requestParams, IQueryable<T> collection)
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
            IQueryable<TS> gridData = collection;
            if (requestParams.EnablePagination == true)
            {
                if (requestParams.Skip.HasValue)
                    gridData = gridData.Skip(requestParams.Skip.Value);

                if (requestParams.Take.HasValue)
                    gridData = gridData.Take(requestParams.Take.Value);
            }


            var result = gridData.ToList();
            var rto = new GridResult<TD>
            {
                Items = result.ToMappedList<TS, TD>().ToList(),
                TotalCount = collection.Count()
            };

            return rto;

        }
         * 
         */


    }
}
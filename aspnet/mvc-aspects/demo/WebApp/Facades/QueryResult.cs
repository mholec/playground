using System.Collections.Generic;

namespace WebApp.Facades
{
    public class QueryResult<TResult>
    {
        public int TotalItems { get; set; }
        public List<TResult> Result { get; set; }

        public QueryResult(List<TResult> result, int totalItems)
        {
            Result = result;
            TotalItems = totalItems;
        }
    }
}
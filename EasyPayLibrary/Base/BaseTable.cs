using System.Collections.Generic;
using System.Linq;

namespace EasyPayLibrary
{
    public class BaseTable<T> : BasePageObject where T : BaseRow
    {
        public List<T> Rows { get; set; }

        public T FirstRow 
            => Rows.First();

        public T LastRow 
            => Rows.Last();

        public T this[int index] 
            => Rows[index];
    }
}
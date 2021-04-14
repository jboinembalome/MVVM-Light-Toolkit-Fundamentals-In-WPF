using System;
using System.Collections.Generic;

namespace EventToCommandListbox.Model
{
    public class DataService : IDataService
    {
        public void GetData(Action<IList<DataItem>> callback)
        {
            var result = new List<DataItem>();

            for (var index = 0; index < 10; index++)
            {
                result.Add(new DataItem("This is item # " + index));
            }

            callback(result);
        }
    }
}

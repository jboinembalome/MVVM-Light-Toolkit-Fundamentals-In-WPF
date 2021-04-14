using System;
using System.Collections.Generic;

namespace EventToCommandListbox.Model
{
    public interface IDataService
    {
        void GetData(Action<IList<DataItem>> callback);
    }
}

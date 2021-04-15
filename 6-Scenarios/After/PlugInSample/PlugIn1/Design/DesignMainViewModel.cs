using System.Windows.Input;

namespace PlugIn1.Design
{
    public class DesignMainViewModel
    {
        public string Counter
        {
            get
            {
                return "Counter value goes here";
            }
        }

        public ICommand IncrementCounterCommand
        {
            get;
            set;
        }
    }
}
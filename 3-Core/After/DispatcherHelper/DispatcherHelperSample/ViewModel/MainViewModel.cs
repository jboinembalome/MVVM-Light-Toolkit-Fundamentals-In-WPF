using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Threading;
using System;
using System.IO;
using System.Net;

namespace DispatcherHelperSample.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private RelayCommand _refreshCommand;

        /// <summary>
        /// The <see cref="Status" /> property's name.
        /// </summary>
        public const string StatusPropertyName = "Status";

        private string _status = "Initializing";

        /// <summary>
        /// Sets and gets the Status property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                Set(StatusPropertyName, ref _status, value);
            }
        }

        /// <summary>
        /// Gets the RefreshCommand.
        /// </summary>
        public RelayCommand RefreshCommand
        {
            get
            {
                return _refreshCommand
                    ?? (_refreshCommand = new RelayCommand(
                    () =>
                    {
                        var request = WebRequest.Create("https://localhost:44376/swagger");
                        request.BeginGetResponse(BeginGetResponseCompleted, request);
                    }));
            }
        }

        private void BeginGetResponseCompleted(IAsyncResult ar)
        {
            // We are on a background thread here!
            var request = ar.AsyncState as HttpWebRequest;
            if (request != null)
            {
                using (var stream = request.EndGetResponse(ar).GetResponseStream())
                {
                    using (var reader = new StreamReader(stream))
                    {
                        var result = reader.ReadToEnd();

                        // Do something with result
                        DispatcherHelper.CheckBeginInvokeOnUI(
                            () =>
                            {
                                Status = "Web page was loaded";
                            });
                    }
                }
            }
        }
    }
}

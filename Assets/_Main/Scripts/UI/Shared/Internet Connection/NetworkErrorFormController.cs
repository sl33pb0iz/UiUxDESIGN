using System;
using System.ComponentModel;

public class NetworkErrorFormController : IDisposable
{
    private NetworkConnectionService _connectionService;
    private ApplicationService _applicationService;


    public ICommand HideNotifySignal;

    private bool _isDisposed;

    public NetworkErrorFormController(NetworkConnectionService connectionService, ApplicationService applicationService) 
    {
        _connectionService = connectionService;
        _applicationService = applicationService;
        _connectionService.PropertyChanged += OnNetworkConnectionChanged;
    }

    private void OnNetworkConnectionChanged(object sender, PropertyChangedEventArgs e)
    {
        if (_connectionService.IsConnected == true)
        {
            HideNotifySignal.Execute(null);
        }
    }

    public void ApplicationQuit()
    {
        _applicationService.ApplicationQuit();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_isDisposed)
        {
            if (disposing)
            {
                _connectionService.PropertyChanged -= OnNetworkConnectionChanged;
                HideNotifySignal = null;
                _connectionService = null;
                _applicationService = null;
            }
            _isDisposed = true;
        }
    }

    ~NetworkErrorFormController()
    {
        Dispose(false);
    }
}

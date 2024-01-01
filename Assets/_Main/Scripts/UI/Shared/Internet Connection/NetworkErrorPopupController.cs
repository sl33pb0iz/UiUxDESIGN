using System.ComponentModel;
using VContainer;

public class NetworkErrorPopupController
{
    private NetworkConnectionService _connectionService;
    private NetworkErrorPopupService _connectionNotifyPopupService;

    public ICommand _popupNotifySignal; 

    [Inject]    
    private NetworkErrorPopupController(NetworkConnectionService connectionService)
    {
        _connectionService = connectionService;
        _connectionService.PropertyChanged += OnNetworkConnectionChanged;
    }

    private void OnNetworkConnectionChanged(object sender, PropertyChangedEventArgs e)
    {
        if(_connectionService.IsConnected == false)
        {
            _popupNotifySignal.Execute(e.ToString());
        }
    }
}


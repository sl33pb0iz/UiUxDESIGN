using System.ComponentModel;
using VContainer;

public class CheckConnectionController
{
    private NetworkConnectionService _connectionService;

    public ICommand _popupNotifySignal; 

    [Inject]    
    private CheckConnectionController(NetworkConnectionService connectionService)
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


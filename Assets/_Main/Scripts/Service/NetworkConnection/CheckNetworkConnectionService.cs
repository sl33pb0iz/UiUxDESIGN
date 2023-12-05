using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class CheckNetworkConnectionService :INotifyPropertyChanged
{
    private bool _isConnected;
    public bool IsConnected
    {
        get
        {
            return _isConnected;
        }
        set
        {
            _isConnected = value;
            OnPropertyChanged(UIStringHelper.NetworkConnectedChanged);
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void CheckNetworkConnection()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            IsConnected = false;
        }
        else
        {
            IsConnected = true;
        }
    }

    public IEnumerator CoroutineCheckNetworkConnection()
    {
        while (true)
        {
            CheckNetworkConnection();
            yield return new WaitForSeconds(3f);
        }
    }
}

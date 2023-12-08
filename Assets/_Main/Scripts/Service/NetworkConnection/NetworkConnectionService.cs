using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using VContainer.Unity;

public class NetworkConnectionService : INotifyPropertyChanged, ITickable
{
    private bool _isConnected = true;

    public bool IsConnected
    {
        get
        {
            return _isConnected;
        }
        set
        {
            if (_isConnected == value) { return; }

            _isConnected = value;
            Debug.Log(_isConnected);
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

    public void Tick()
    {
        CheckNetworkConnection();
    }
}

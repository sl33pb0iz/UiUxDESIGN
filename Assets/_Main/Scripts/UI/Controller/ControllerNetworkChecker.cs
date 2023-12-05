using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.WebSockets;
using System.Windows.Input;
using UI.Enum;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]

public class ControllerNetworkChecker : MonoBehaviour
{
   /* public ICommand NetworkErrorCommand;   
    private ModelNetwork _modelNetwork;

    public void Awake()
    {
        _modelNetwork = new();
        _modelNetwork.PropertyChanged += OnNetworkConnectionChanged;
    }

    public void OnEnable()
    {
        StartCoroutine(_modelNetwork.CoroutineCheckNetworkConnection());
    }

    public void OnDisable()
    {
        StopAllCoroutines();
    }

    private void OnNetworkConnectionChanged(object sender, PropertyChangedEventArgs e)
    {
        if (sender is ModelNetwork modelNetworkChecker)
        {
            if (e.PropertyName == UIStringHelper.NetworkConnectedChanged)
            {
                if (NetworkErrorCommand.CanExecute(true))
                {
                    NetworkErrorCommand.Execute(!modelNetworkChecker.IsConnected);
                }
                return;

            }
        }
    }*/
}

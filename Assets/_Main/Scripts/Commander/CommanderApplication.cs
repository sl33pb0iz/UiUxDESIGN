using System;
using System.Collections;
using System.Collections.Generic;
//using UI.Splash;
using UnityEngine;

public class CommanderApplication : ICommandTest
{
    private ControllerNetworkChecker _viewModelNetworkChecker;

    public CommanderApplication(ControllerNetworkChecker viewModelNetworkChecker)
    {
        _viewModelNetworkChecker = viewModelNetworkChecker;
    }

    public void Execute(object parameter)
    {
        //_viewModelNetworkChecker.OnApplicationQuit();
    }

    public void Undo(object parameter)
    {
        throw new NotImplementedException();
    }
}

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class EULAPolicyNotifyController 
{
    private EULAPolicyService _service;

    public ICommand PolicyCheckedSignal;

    public EULAPolicyNotifyController(EULAPolicyService service)
    {
        _service = service;
        _service.PropertyChanged += OnPropertyChanged;
    }

    public void OpenPolicyURL()
    {
        _service.OpenPolicyURL();
    }

    public void OnCheckPolicy()
    {
        _service.Checked();
    }

    private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (_service.IsPolicyChecked)
        {
            PolicyCheckedSignal.Execute(null);
        }
    }
}

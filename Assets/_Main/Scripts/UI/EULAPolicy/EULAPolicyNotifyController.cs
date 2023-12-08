using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class EULAPolicyNotifyController 
{
    private EULAPolicyService m_service;

    public ICommand PolicyCheckedSignal;

    public EULAPolicyNotifyController(EULAPolicyService service)
    {
        m_service = service;
        m_service.PropertyChanged += OnPropertyChanged;
    }

    public void OpenPolicyURL()
    {
        m_service.OpenPolicyURL();
    }

    public void OnCheckPolicy()
    {
        m_service.Checked();
    }

    private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (m_service.IsPolicyChecked)
        {
            PolicyCheckedSignal.Execute(null);
        }
    }
}

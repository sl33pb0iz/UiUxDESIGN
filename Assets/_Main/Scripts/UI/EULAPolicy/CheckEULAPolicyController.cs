using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using VContainer.Unity;

public class CheckEULAPolicyController : IPostStartable
{
    private EULAPolicyService m_service;

    public ICommand _popupPolicySignal;

    public CheckEULAPolicyController(EULAPolicyService service)
    {
        m_service = service;
    }

    public void PostStart()
    {
        if (!m_service.IsPolicyChecked)
        {
            _popupPolicySignal.Execute(null);
        }
    }
}

using Doozy.Runtime.UIManager.Containers;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class UISplashPopupFactory : MonoBehaviour
{
    [Title("POPUP", titleAlignment: TitleAlignments.Centered)]
    [SerializeField] private UIPopup _popupNetworkErrorPrefab;
    [SerializeField] private UIPopup _popupEULAPrivacyPrefab; 

    private CheckConnectionController _checkConnectionController;

    private CheckEULAPolicyController _checkEULAPolicyController;

    [Inject]
    private IObjectResolver _container;

    private ICommand _popupNetworkErrorNotifySignal;
    private ICommand _popupPolicyNotifySignal; 

    [Inject]
    private Func<NetworkConnectionService, ApplicationService, NetworkErrorNotifyController> _errorNetworkNotifyFactory;

    [Inject]
    private Func<EULAPolicyService, EULAPolicyNotifyController> _policyNotifyFactory;

    private void Start()
    {
        _popupNetworkErrorNotifySignal = new RelayCommand<string>(_ => true, _ => ShowPopupNetworkErrorNotify()); 
        _checkConnectionController = _container.Resolve<CheckConnectionController>();
        _checkConnectionController._popupNotifySignal = _popupNetworkErrorNotifySignal;

        _popupPolicyNotifySignal = new RelayCommand<string>(_ => true, _ => ShowPopupEULAPrivacy());
        _checkEULAPolicyController = _container.Resolve<CheckEULAPolicyController>();
        _checkEULAPolicyController._popupPolicySignal = _popupPolicyNotifySignal;
    }

    private void ShowPopupNetworkErrorNotify()
    {
        var popup = UIPopup.Get(_popupNetworkErrorPrefab.name);
        
        var netWorkService = _container.Resolve<NetworkConnectionService>();
        var applicationService = _container.Resolve<ApplicationService>();

        var controller = _errorNetworkNotifyFactory(netWorkService, applicationService);

        var form = popup.GetComponent<NetworkErrorNotifyView>();
        form._controller = controller;

        popup.Show();
    }

    private void ShowPopupEULAPrivacy()
    {
        var popup = UIPopup.Get(_popupEULAPrivacyPrefab.name);

        var policyService = _container.Resolve<EULAPolicyService>();

        var controller = _policyNotifyFactory(policyService);
        var form = popup.GetComponent<EULAPolicyNotifyView>();

        form.m_controller = controller;

        popup.Show();
    }
}

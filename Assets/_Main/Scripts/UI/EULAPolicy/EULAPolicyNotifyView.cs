using Doozy.Runtime.UIManager.Components;
using Doozy.Runtime.UIManager.Containers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EULAPolicyNotifyView : MonoBehaviour
{
    public EULAPolicyNotifyController m_controller;

    [SerializeField] private UIButton _buttonAccept;
    [SerializeField] private UIButton _buttonTermsOfService;
    [SerializeField] private UIButton _buttonInfo;

    private ICommand _checkedPolicySignal;

    private void Start()
    {
        _checkedPolicySignal = new RelayCommand<string>(_ => true, _ => CheckedPolicy());
        m_controller.PolicyCheckedSignal = _checkedPolicySignal;

    }

    private void OnEnable()
    {
        _buttonAccept.onLeftClickEvent.AddListener(() => m_controller.OnCheckPolicy());
        _buttonTermsOfService.onLeftClickEvent.AddListener(() => m_controller.OpenPolicyURL());
        _buttonInfo.onLeftClickEvent.AddListener(() => m_controller.OpenPolicyURL());
    }

    private void OnDisable()
    {
        _buttonAccept.onLeftClickEvent.RemoveListener(m_controller.OnCheckPolicy);
        _buttonTermsOfService.onLeftClickEvent.RemoveListener(m_controller.OpenPolicyURL);
        _buttonInfo.onLeftClickEvent.RemoveListener(m_controller.OpenPolicyURL);
    }

    private void CheckedPolicy()
    {
        var popup = GetComponent<UIPopup>();
        popup.Hide();
    }


}

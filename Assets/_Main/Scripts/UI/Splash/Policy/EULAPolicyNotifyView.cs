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
        _buttonAccept.onClickEvent.AddListener(() => m_controller.OnCheckPolicy());
        _buttonTermsOfService.onClickEvent.AddListener(() => m_controller.OpenPolicyURL());
        _buttonInfo.onClickEvent.AddListener(() => m_controller.OpenPolicyURL());
    }

    private void OnDisable()
    {
        _buttonAccept.onClickEvent.RemoveListener(m_controller.OnCheckPolicy);
        _buttonTermsOfService.onClickEvent.RemoveListener(m_controller.OpenPolicyURL);
        _buttonInfo.onClickEvent.RemoveListener(m_controller.OpenPolicyURL);
    }

    private void CheckedPolicy()
    {
        var popup = GetComponent<UIPopup>();
        popup.Hide();
    }


}

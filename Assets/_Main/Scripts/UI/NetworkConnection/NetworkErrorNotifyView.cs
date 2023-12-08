using Doozy.Runtime.UIManager.Components;
using Doozy.Runtime.UIManager.Containers;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkErrorNotifyView : MonoBehaviour
{
    public NetworkErrorNotifyController _controller;

    private ICommand _hideNotifySignal;

    [Title("BUTTON", titleAlignment: TitleAlignments.Centered)]
    [SerializeField] private UIButton _quitButton;

    private void Start()
    {
        _hideNotifySignal = new RelayCommand<string>(_ => true, _ => HideNotify());
        _controller.HideNotifySignal = _hideNotifySignal;
    }

    private void OnEnable()
    {
        _quitButton.onLeftClickEvent.AddListener(() => _controller.ApplicationQuit());
    }

    private void OnDisable()
    {
        _quitButton.onLeftClickEvent.AddListener(() => _controller.ApplicationQuit());
    }

    private void HideNotify()
    {
        var popup = this.GetComponent<UIPopup>();
        popup.Hide();
    }

    private void OnDestroy()
    {
        _controller.Dispose();
        _hideNotifySignal = null;
        _controller = null;
    }

}

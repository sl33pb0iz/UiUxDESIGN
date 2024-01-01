using Doozy.Runtime.UIManager.Components;
using Doozy.Runtime.UIManager.Containers;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopLobbyView : MonoBehaviour
{
    [Title("BUTTON", titleAlignment: TitleAlignments.Centered)]
    [SerializeField] private UIButton _buttonSettings;
    [SerializeField] private UIButton _buttonUserInfo;  

    [Title("COMPONENT", titleAlignment: TitleAlignments.Centered)]
    [SerializeField] private StatusBarGroupView _statusBarView;
    [SerializeField] private UserInfoView _userInfoView;

    [Title("PREFAB", titleAlignment: TitleAlignments.Centered)]
    [SerializeField] private UIPopup _popupSettings;
    [SerializeField] private UIPopup _popupUserInfo;

    private void OnEnable()
    {
        _buttonSettings.onClickEvent.AddListener(ShowPopupSettings);
        _buttonUserInfo.onClickEvent.AddListener(ShowPopupUserInfo);

    }

    private void OnDisable()
    {
        _buttonSettings.onClickEvent.RemoveListener(ShowPopupSettings);
        _buttonUserInfo.onClickEvent.RemoveListener(ShowPopupUserInfo);

    }

    private void ShowPopupSettings()
    {
        var popup = UIPopup.Get(_popupSettings.name);
        popup.Show();
    }

    private void ShowPopupUserInfo()
    {
        Debug.Log("show info");
        var popup = UIPopup.Get(_popupUserInfo.name);
        popup.Show();
    }


}

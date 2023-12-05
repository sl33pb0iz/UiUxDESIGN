using Doozy.Runtime.UIManager.Components;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopLobbyView : MonoBehaviour
{
    [Title("BUTTON", titleAlignment: TitleAlignments.Centered)]
    [SerializeField] private UIButton _buttonSettings;

    [Title("COMPONENT", titleAlignment: TitleAlignments.Centered)]
    [SerializeField] private StatusBarGroupView _statusBarView;
    [SerializeField] private UserInfoView _userInfoView;

    private void OnEnable()
    {
        _buttonSettings.onLeftClickEvent.AddListener(PopupSettings);
    }

    private void OnDisable()
    {
        _buttonSettings.onLeftClickEvent.RemoveListener(PopupSettings);
    }

    private void PopupSettings()
    {
        Debug.Log("hahahaha");
    }
}

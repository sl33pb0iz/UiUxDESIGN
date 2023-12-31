using Doozy.Runtime.UIManager.Components;
using Doozy.Runtime.UIManager.Containers;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightSideLobbyView : MonoBehaviour
{
    [Title("BUTTON", titleAlignment: TitleAlignments.Centered)]
    [SerializeField] private UIButton _buttonChat;

    [Title("PREFAB", titleAlignment: TitleAlignments.Centered)]
    [SerializeField] private UIPopup _popupChat; 

    private void OnEnable()
    {
        _buttonChat.onClickEvent.AddListener(ShowPopupChat);
    }

    private void OnDisable()
    {
        _buttonChat.onClickEvent.RemoveListener(ShowPopupChat);
    }

    private void ShowPopupChat()
    {
        var popup = UIPopup.Get(_popupChat.name);
        popup.Show();
    }
}

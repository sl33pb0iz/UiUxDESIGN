using Doozy.Runtime.UIManager.Components;
using Doozy.Runtime.UIManager.Containers;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftSideLobbyView : MonoBehaviour
{
    [Title("BUTTON", titleAlignment: TitleAlignments.Centered)]
    [SerializeField] private UIButton _buttonReward;

    [Title("PREFAB", titleAlignment: TitleAlignments.Centered)]
    [SerializeField] private UIPopup _popupReward;

    private void OnEnable()
    {
        _buttonReward.onClickEvent.AddListener(ShowPopupReward);
    }

    private void OnDisable()
    {
        _buttonReward.onClickEvent.RemoveListener(ShowPopupReward);
    }

    private void ShowPopupReward()
    {
        var popup = UIPopup.Get(_popupReward.name);
        popup.Show();
    }

}

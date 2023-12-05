using Doozy.Runtime.UIManager.Components;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopLobbyView : MonoBehaviour
{
    [Title("BUTTON", titleAlignment: TitleAlignments.Centered)]
    [SerializeField] private UIButton buttonSettings;

    private void OnEnable()
    {
        buttonSettings.onLeftClickEvent.AddListener(PopupSettings);
    }

    private void OnDisable()
    {
        buttonSettings.onLeftClickEvent.RemoveListener(PopupSettings);
    }

    private void PopupSettings()
    {
        Debug.Log("settings");
    }
}

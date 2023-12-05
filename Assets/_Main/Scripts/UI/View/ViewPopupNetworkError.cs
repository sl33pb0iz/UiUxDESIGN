using Doozy.Runtime.UIManager.Containers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ViewPopupNetworkError : MonoBehaviour
{
    public UIPopup PopupNetworkErrorPrefab;

    private void OnEnable()
    {
        var popup = UIPopup.Get(PopupNetworkErrorPrefab.name);
        popup.Show();
    }

    private void OnDisable()
    {
        var popup = UIPopup.visiblePopups.Where(x => x.name == PopupNetworkErrorPrefab.name + "(Clone)");
        foreach (var item in popup)
        {
            item.Hide();
        }
    }
}

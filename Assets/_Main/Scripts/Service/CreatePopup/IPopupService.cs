using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public interface IPopupService : INotifyPropertyChanged
{
    public bool IsPopup {  get; set; }
}

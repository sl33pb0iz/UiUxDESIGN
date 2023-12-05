using Doozy.Runtime.UIManager.Components;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GuestSignUpForm : MonoBehaviour
{
    [Title("BUTTON", titleAlignment: TitleAlignments.Centered)]

    [Title("TOGGLE", titleAlignment: TitleAlignments.Centered)]

    [Title("INPUT FIELD", titleAlignment: TitleAlignments.Centered)]
    [SerializeField] private TMP_InputField _usernameID;
    [SerializeField] private TMP_InputField _passwordID;

    [HideInInspector] public GuestSignUpFormController _guestSignUpFormController;

    private ICommand _signedUpSignal;

    public void Init()
    {
      
    }

    private void SignedIn()
    {
      
    }
}

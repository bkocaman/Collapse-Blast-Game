using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
public class ErrorMessage : MonoBehaviour
{
    public RectTransform ErrorUI;
    public Button ReturnMenuButton;

    void Start()
    {
        ReturnMenuButton = ErrorUI.GetComponentInChildren<Button>();
        ReturnMenuButton.onClick.AddListener(Button);
    }


    void Button()
    {
        ErrorUI.gameObject.SetActive(false);

    }

    public void DisplayMessage(string errorMessage)
    {
        Text errorMessageText = ErrorUI.GetComponentInChildren<Text>();
        errorMessageText.text = errorMessage;
        ErrorUI.gameObject.SetActive(true);
    }
}

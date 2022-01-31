using UnityEngine;
using UnityEngine.UI;
public class ErrorMessage : MonoBehaviour
{
    public RectTransform errorUI;
    public Button ReturnMenu;

    void Start()
    {
        ReturnMenu = errorUI.GetComponentInChildren<Button>();
        ReturnMenu.onClick.AddListener(Click);
    }


    void Click()
    {
        errorUI.gameObject.SetActive(false);

    }

    public void ShowErrorMessage(string errorMessage)
    {
        Text errorMessageText = errorUI.GetComponentInChildren<Text>();
        errorMessageText.text = errorMessage;
        errorUI.gameObject.SetActive(true);
    }
}

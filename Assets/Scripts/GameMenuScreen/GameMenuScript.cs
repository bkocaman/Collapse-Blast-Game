using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameMenuScript : MonoBehaviour
{
    public RectTransform errorUI;
    public Button StartUI;
    private ErrorMessage errorMessageScript;

    int[] Array = new int[6];
    string[] componentNames = { "RowText", "ColumnText", "ColorText", "AText", "BText", "CText" };
    int[] lowerLimits = { 2, 2, 1, 0, 0, 0 };
    int[] higherLimits = { 10, 10, 6, 50, 50, 50 };
    int Row = 0, Column = 1, Color = 2, A = 3, B = 4, C = 5;


    void Start()
    {
        Button btn = StartUI.GetComponent<Button>();
        btn.onClick.AddListener(Button);
        GameObject go = errorUI.gameObject;
        errorMessageScript = errorUI.GetComponentInChildren<ErrorMessage>();


    }


    string GetInputFieldText(string componentName)
    {
        GameObject inputFieldGo = GameObject.Find(componentName);
        InputField inputFieldCo = inputFieldGo.GetComponent<InputField>();
        return inputFieldCo.text;
    }



    bool CheckingInput(string componentName, ref int value, int lowerLimit, int higherLimit, string errorMessage)
    {
        string inputValue = GetInputFieldText(componentName);
        bool result = false;
        if (Int32.TryParse(inputValue, out value))
        {
            if (lowerLimit <= value && value <= higherLimit)
            {
                result = true;
            }
            else
            {
                errorMessageScript.DisplayMessage(errorMessage);
            }
        }
        else
        {
            errorMessageScript.DisplayMessage("ERROR !!" + componentName + "Number is wrong");
        }
        return result;
    }

    void Button()
    {
        bool iscorrect = false;
        for (int valueIndex = 0; valueIndex < Array.Length; valueIndex++)
        {

            int lowlimit = lowerLimits[valueIndex];
            int highlimit = higherLimits[valueIndex];
            string name = componentNames[valueIndex];

            iscorrect = CheckingInput(name, ref Array[valueIndex], lowlimit, highlimit,
               name + " number must be" + lowlimit + " to " + highlimit );

            if (!iscorrect)
            {
                break;
            }
            else if (valueIndex == A)
            {
                lowerLimits[B] = Array[A] + 1;
                Debug.Log(lowerLimits[B]);
            }
            else if (valueIndex == B)
            {
                lowerLimits[C] = Array[B] + 1;
            }
        }
        if (iscorrect)
        {
            PlayerPrefs.SetInt("row", Array[Row]);
            PlayerPrefs.SetInt("column", Array[Column]);
            PlayerPrefs.SetInt("color", Array[Color]);
            PlayerPrefs.SetInt("A", Array[A]);
            PlayerPrefs.SetInt("B", Array[B]);
            PlayerPrefs.SetInt("C", Array[C]);

            SceneManager.LoadScene("Game");
        }

    }






}

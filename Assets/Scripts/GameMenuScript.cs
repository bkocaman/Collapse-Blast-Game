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
    

    // Created Array
    int[] propertiesArray = new int[6];
    string[] componentNames = { "Row", "Column", "Color", "A", "B", "C" };
    int[] lowerLimits = { 2, 2, 1, 0, 0, 0 };
    int[] higherLimits = { 10, 10, 6, 20, 20, 20 };
    int Row = 0, Column = 1, Color = 2, A = 3, B = 4, C = 5;


    void Start()
    {
        Button button = StartUI.GetComponent<Button>();
        button.onClick.AddListener(Click);

        GameObject go = errorUI.gameObject;
        errorMessageScript = errorUI.GetComponentInChildren<ErrorMessage>();
       
    }

    string GetInputFieldText(string componentName)
    {
        GameObject input = GameObject.Find(componentName);
        InputField inputfield = input.GetComponent<InputField>();
        return inputfield.text;
    }


    //Checking input method

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
                errorMessageScript.ShowErrorMessage(errorMessage);
            }
        }
        else
        {
            errorMessageScript.ShowErrorMessage("-------------ERROR !!! -------------");
            errorMessageScript.ShowErrorMessage( componentName + " entered wrong number !!");
        }
        return result;
    }

    void Click()
    {
        bool iscorrect = false;
        for (int valueIndex = 0; valueIndex < propertiesArray.Length; valueIndex++)
        {

            int lowLimit = lowerLimits[valueIndex];
            int highLimit = higherLimits[valueIndex];
            string name = componentNames[valueIndex];

            iscorrect = CheckingInput(name, ref propertiesArray[valueIndex], lowLimit, highLimit,
              "ERROR !!!" +  name + " number should be between " + lowLimit + " - " + highLimit );

            if (!iscorrect)
            {
                break;
            }
            else if (valueIndex == A)
            {
                lowerLimits[B] = propertiesArray[A] + 1;
                Debug.Log(lowerLimits[B]);
            }
            else if (valueIndex == B)
            {
                lowerLimits[C] = propertiesArray[B] + 1;
            }
        }
        if (iscorrect)
        {
            PlayerPrefs.SetInt("row", propertiesArray[Row]);
            PlayerPrefs.SetInt("column", propertiesArray[Column]);
            PlayerPrefs.SetInt("color", propertiesArray[Color]);
            PlayerPrefs.SetInt("A", propertiesArray[A]);
            PlayerPrefs.SetInt("B", propertiesArray[B]);
            PlayerPrefs.SetInt("C", propertiesArray[C]);

            SceneManager.LoadScene("Game");
        }

    }




}

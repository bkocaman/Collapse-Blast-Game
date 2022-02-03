using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
   
    int [] Array = new int[3];
    int Row = 0, Column = 1, Color = 2; 
    ArrayList level;
    void Awake()
    {
        SetAllAttributes();
    }

   
    private void CalculateLevel(ArrayList levels) {
        int startValue = Int32.MinValue;
        int endValue; 
        for (int i = 0; i < levels.Count; i++)
        {
            endValue = (int) levels[i];
            level.Add(new ArrayList{startValue, endValue});
            startValue = endValue += 1;
        }
         endValue = Int32.MaxValue;
        level.Add(new ArrayList{startValue, endValue});
    }

    public int GetRowNumber() {
       return Array[Row];
    }

    public int GetColumnNumber() {
        return Array[Column];
    }

    public int GetColorNumber() {
        return Array[Color];
    }

    public ArrayList GetLevel() {
        return level;
    }

    private void SetAllAttributes()
    {
        level = new ArrayList();
        Array[Row] = PlayerPrefs.GetInt("rowNumber");
        Array[Column] = PlayerPrefs.GetInt("columnNumber");
        Array[Color] = PlayerPrefs.GetInt("colorNumber");
        ArrayList levels = new ArrayList { PlayerPrefs.GetInt("A"), PlayerPrefs.GetInt("B"), PlayerPrefs.GetInt("C") };
        CalculateLevel(levels);
    }
}

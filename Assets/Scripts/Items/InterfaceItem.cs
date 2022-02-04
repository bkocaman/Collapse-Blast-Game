using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items 
{
    public interface InterfaceItem 
    {
        void Initialize(ItemColors.IColor color, int order, float speed, GameManager gameManager,
         float initialXCoordinate, float initialYCoordinate, float rowLength, float columnLength);

        void SetSortingOrder(int order);

        int GetSortingOrder();

        void SetLevel(int level);

        void ChangeLevelToDefault();

        //IColor GetColor();

        bool IsEqual(Items.Item item);

        void Move(float targetRow, float targetColumn);
    }
}


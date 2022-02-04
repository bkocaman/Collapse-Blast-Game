using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public class ItemFactory
    {
        private GameManager gameManager;
        private GameObject itemPrefab;
        private ArrayList colors;


        
        private float rowLength;
        private float columnLength;
        private float itemSpeed;
        private float newItemPointYCordinate;
        private float initialXCoordinate;
        private float initialYCoordinate;
        private float initialZCoordinate;

        public ItemFactory(GameManager gameManager, GameObject itemprefab, ArrayList colors, float rowLength, float columnLength, 
            float Itemspeed, float NewItemPointYCoordinate, float initialXCoordinate, float initialYCoordinate, float initialZCoordinate) {
            this.gameManager = gameManager;
            itemPrefab = itemprefab;
            this.colors = colors;
            this.rowLength = rowLength;
            this.columnLength = columnLength;
            itemSpeed = Itemspeed;
            newItemPointYCordinate = NewItemPointYCoordinate;
            this.initialXCoordinate = initialXCoordinate;
            this.initialYCoordinate = initialYCoordinate;
            this.initialZCoordinate = initialZCoordinate;
        }

       

        public  Items.Item CreateItem(int colorIndex, int order, float row, float column) {
            float yCoordinate =  initialYCoordinate + columnLength * column; 
            float xCoordinate = initialXCoordinate + rowLength * row;
            GameObject ItemPrefab = GameObject.Instantiate(itemPrefab, 
                new Vector3(xCoordinate, yCoordinate, initialZCoordinate), Quaternion.identity) as GameObject;
            Items.Item item = ItemPrefab.gameObject.GetComponent<Items.Item>();
            item.Initialize((ItemColors.IColor) colors[colorIndex], order, itemSpeed, gameManager, initialXCoordinate, initialYCoordinate, rowLength, columnLength);
            return item;
        }

        public  Items.Item CreateItemSpacePoint(int colorIndex, int order, float row, float column) {
            float yCoordinate =  initialYCoordinate + columnLength * column + newItemPointYCordinate; 
            float xCoordinate = initialXCoordinate + rowLength * row;
            GameObject ItemPrefab = GameObject.Instantiate(itemPrefab, 
                new Vector3(xCoordinate, yCoordinate, initialZCoordinate), Quaternion.identity) as GameObject;
            Items.Item item = ItemPrefab.gameObject.GetComponent<Items.Item>();
            item.Initialize((ItemColors.IColor) colors[colorIndex], order, itemSpeed, gameManager, initialXCoordinate, initialYCoordinate, rowLength, columnLength);
            item.Move(row, column);
            return item;
        }
    }
}

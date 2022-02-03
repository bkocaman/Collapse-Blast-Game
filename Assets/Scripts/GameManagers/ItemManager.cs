using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;
using ItemColors;
public class ItemManager : MonoBehaviour
{

    private InputManager inputManager;
    public GameObject inputManagerObject;
    private ItemCanvas itemCanvas;
    public GameObject itemCanvasObject;
    public GameObject itemPrefab;
    public GameProperties gameProperties;
    private GameManager gameManager;
    public GameObject gameManagerObjects;
    private System.Random random;
    private Items.ItemFactory itemFactory;


    private float initialXCoordinate;
    private float initialYCoordinate;
    private float initialZCoordinate;
    private int rowNumber;
    private int columnNumber;
    private int colorNumber;
    

  
    void Start()
    {
        SetAllAttributes();
        SetCoordinates();
        SetItemFactory();
        CreateCanvas();
    }
    private void SetAllAttributes() {
        gameManager = (GameManager) gameManagerObjects.GetComponent("GameManager");
        inputManager = (InputManager) inputManagerObject.GetComponent("InputManager");
        itemCanvas = (ItemCanvas) itemCanvasObject.GetComponent("ItemCanvas");
    }
    private void SetCoordinates() {
        initialXCoordinate = (Screen.width / 2) - ((gameProperties.RowLength * inputManager.GetRowNumber()) / 2);
        initialYCoordinate = (Screen.height / 2) - ((gameProperties.ColumnLength * inputManager.GetColumnNumber()) / 2);
        initialZCoordinate = gameProperties.ZValue;
    }

    private void SetItemFactory() {
        ArrayList levelBoundaries = inputManager.GetLevel();
        ArrayList colors = new ArrayList{
            new ItemColors.Purple(levelBoundaries),
            new ItemColors.Red(levelBoundaries),
            new ItemColors.Yellow(levelBoundaries),
            new ItemColors.Blue(levelBoundaries), 
            new ItemColors.Green(levelBoundaries), 
            new ItemColors.Pink(levelBoundaries), 
            
        };
        itemFactory = new Items.ItemFactory(gameManager, itemPrefab, colors, gameProperties.RowLength, 
            gameProperties.ColumnLength, gameProperties.itemSpeed, gameProperties.NewItemPointY,
            initialXCoordinate, initialYCoordinate, initialZCoordinate);
    }
    private void SetInputManagers() {  
        rowNumber = inputManager.GetRowNumber();
        columnNumber = inputManager.GetColumnNumber();
        colorNumber = inputManager.GetColorNumber();
    }

    private int RandomColor() {
        int randomIndex = random.Next(colorNumber);
        return randomIndex;
    }
    public void CreateCanvas() {
        random = new System.Random();
        
        SetInputManagers();
        itemCanvas.SetRowAndColumn(rowNumber,columnNumber);
        for(int column = 0; column < columnNumber; column++) {
            for(int row = 0; row < rowNumber; row++) {
                int order = itemCanvas.GetAndIncreaseOrder();

                Items.Item item = itemFactory.CreateItem(RandomColor(), order, row, column);   
                itemCanvas.SetItem(row, column, item);
            }
        }
    }

    public void CreateItemIntoCanvas(int row, int column) {
        int order = itemCanvas.GetAndIncreaseOrder();
        Items.Item item = itemFactory.CreateItemSpacePoint(RandomColor(), order, row, column);
        itemCanvas.SetItem(row, column, item);
    }


}

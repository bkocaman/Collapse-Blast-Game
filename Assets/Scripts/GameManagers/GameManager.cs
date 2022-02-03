using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Items.ItemCanvas itemCanvas;
    public GameObject itemCanvasObject;
    private ArrayList itemGroups;

    void Start()
    {
        SetItemCanvasandGroups();
        FieldSpaceItem();
        FieldSpaceItemUntilNoLock();
    }
    private void SetItemCanvasandGroups() {
        itemCanvas = (Items.ItemCanvas) itemCanvasObject.GetComponent("ItemCanvas");
        itemGroups = new ArrayList();
    }
   
   

    private void FieldSpaceItem() {
        if(itemCanvas == null ) {
        }
        itemCanvas.DefaultAllItem();
        itemGroups = itemCanvas.GetCubeGroups();
        foreach (ArrayList itemGroup in itemGroups) {
            itemCanvas.SetItemGroup(itemGroup);
        }
    }

   

    private void UpdateCanvasWhenItemsExplode() {
        itemCanvas.SlideItemGoSpaces();
        itemCanvas.CreateNewItemForEmptyCells();
        FieldSpaceItem(); 
        bool isNoLock = CheckNoLock();
        if(isNoLock) {
            FieldSpaceItemUntilNoLock();
        }
    }

    private int IsExploded(Items.Item block) {
        int result = -1;
        int index = 0;
        foreach (ArrayList itemGroup in itemGroups) {
            foreach (int[] itemCoordinate in itemGroup) {
                int row = itemCoordinate[0];
                int column = itemCoordinate[1];
                Items.Item itemInGroup = itemCanvas.GetItem(row, column);
                if(block.IsEqual(itemInGroup)) {
                    result = index;
                    break;
                }
            }
            if(result != -1) {
                break;
            }
            index++;
        }
        return result;
    }

    private void DestroyItem(ArrayList itemGroup) {
        foreach (int[] coordinates in itemGroup)
        {
            int row = coordinates[0];
            int column = coordinates[1];
            itemCanvas.DestroyItem(row, column);
        }
    }

    private bool CheckNoLock() {
        int thereIsNoGroup = 0;
        bool isLock = itemGroups.Count == thereIsNoGroup;
        return isLock;
    }

    private void FieldSpaceItemUntilNoLock() {
        int count = 0;
        bool isLock = CheckNoLock();
        while(isLock) {
            count++;
            itemCanvas.ChangeLocationOfTwoBlocksRandomly();
            FieldSpaceItem();
            if(count > 100) {
                ResetCanvas();
            }
            isLock = CheckNoLock();
        }
    }

    public void itemClicked(Items.Item item)
    {
        int isExploded = IsExploded(item);
        int isnotExploded = -1;
        if (isExploded != isnotExploded)
        {
            int itemGroupIndex = isExploded;
            ArrayList itemGroup = (ArrayList)itemGroups[itemGroupIndex];
            DestroyItem(itemGroup);
            UpdateCanvasWhenItemsExplode();
        }
    }

    private void ResetCanvas() {
        itemCanvas.ResetCanvas();
        FieldSpaceItem();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items 
{
    public class ItemCanvas : MonoBehaviour
    {
        private ItemManager _itemManager;
        public GameObject itemManager; 
        private Items.Item [,] _item;
        private int _rowNumber;
        private int _columnNumber;
        private int _order;
        private System.Random _random;

        void Awake() {
            _itemManager = (ItemManager) itemManager.GetComponent("ItemManager");
            _random = new System.Random();
            _order = 0;
            _rowNumber = 0;
            _columnNumber = 0;
            _item = new Items.Item[10,10];
        }

        public void SetRowAndColumn( int rowNumber, int columnNumber) {
            _rowNumber = rowNumber;
            _columnNumber = columnNumber;
        }

        public void SetItem(int row, int column, Items.Item block) {
            _item[row, column] = block;
        }

        public Items.Item GetItem(int row, int column) {
            return _item[row, column];
        }

        public void DestroyItem(int row, int column) {
            Destroy(_item[row, column].gameObject);
            _item[row, column] = null;
        }

        public int GetAndIncreaseOrder() {
            int order = _order;
            _order += 1;
            return order;
        }

        private void ChangeLevelItem(int row, int col, int level) {
            _item[row, col].SetLevel(level);
        }

        public void DefaultAllItem() {
            for(int column = 0; column < _columnNumber; column++) {
                for(int row = 0; row < _rowNumber; row++) {
                    _item[row, column].ChangeLevelToDefault();
                }
            }
        }

        public void SetItemGroup(ArrayList blockGroup) {
            int level = blockGroup.Count;
            foreach (int[] blockCoordinates in blockGroup) {
                int row = blockCoordinates[0];
                int column = blockCoordinates[1];
                ChangeLevelItem(row, column, level);
            }
        }

        private ArrayList ExploreItem(ref int[,] visited, int row, int column)
        {
            ArrayList itemGroup = new ArrayList();
            Stack<int[]> stack = new Stack<int[]>();
            int[] rowCoor = { -1, 1, 0, 0 };
            int[] colCoor = { 0, 0, -1, 1 };
            int notVisited = 0;
            stack.Push(new int[] { row, column });
            ItemColors.IColor color = _item[row, column].GetColor();
            while (stack.Count > 0)
            {
                int[] point = stack.Peek();
                stack.Pop();
                itemGroup.Add(point);
                visited[point[0], point[1]] = 1;
                for (int i = 0; i < 4; i++)
                {
                    int newRow = point[0] + rowCoor[i];
                    int newCol = point[1] + colCoor[i];
                    if (0 <= newRow && newRow < _rowNumber
                        && 0 <= newCol && newCol < _columnNumber)
                    {
                        if (visited[newRow, newCol] == notVisited)
                        {
                            if (color.IsSame(_item[newRow, newCol].GetColor()))
                            {
                                stack.Push(new int[] { newRow, newCol });
                                visited[newRow, newCol] = 1;
                            }
                        }
                    }
                }
            }
            return itemGroup;
        }

        public ArrayList GetCubeGroups() {
            ArrayList itemGroups = new ArrayList();
            int [,] visited = new int[10,10]; 
            int notVisited = 0; 
            for(int column = 0; column < _columnNumber; column++) {
                for(int row = 0; row < _rowNumber; row++) {
                    if(visited[row, column] == notVisited) { 
                        ArrayList blockGroup = ExploreItem(ref visited, row, column);
                        if(blockGroup.Count > 1) {
                            itemGroups.Add(blockGroup);
                        }
                    }
                }
            }
            return itemGroups;
        }


        public void SlideItemGoSpaces() {
            for(int row = 0; row < _rowNumber; row++) {         
                for(int column = 0; column < _columnNumber; column++) {     
                    if(_item[row, column] != null) { 
                        int[] emptyCell  = GetEmptyCellInColumn(row, column);
                        if(emptyCell != null) {      
                            _item[row, column].Move(emptyCell[0], emptyCell[1]);
                            _item[emptyCell[0], emptyCell[1]] = _item[row, column];
                            _item[row, column] = null;
                        }
                    }
                } 
            }
        }

        private int[] GetEmptyCellInColumn(int row, int columnLimit) {
            int[] coordinates = null;
            for(int column = 0; column < columnLimit; column++) {
                if(_item[row, column] == null) {
                    coordinates = new int[] {row, column};
                    break;
                }
            }
            return coordinates;
        }

        public void CreateNewItemForEmptyCells() {
            for(int row = 0; row < _rowNumber; row++) {         
                for(int column = 0; column < _columnNumber; column++) {     
                    if(_item[row, column] == null) {
                        _itemManager.CreateItemIntoCanvas(row, column);
                    }
                } 
            }
        }

        public void ChangeLocationOfTwoBlocksRandomly() {
            bool blocksAreSame = true;
            int first_row = 0;
            int first_col = 0;
            int second_row = 0;
            int second_col = 0;
            while(blocksAreSame) {
                first_row = _random.Next(_rowNumber);
                first_col = _random.Next(_columnNumber);
                second_row = _random.Next(_rowNumber);
                second_col = _random.Next(_columnNumber);
                blocksAreSame = first_row == second_row && first_col == second_col;
            }

            Item tmp = _item[first_row, first_col];
            _item[first_row, first_col] = _item[second_row, second_col];
            _item[second_row, second_col] = tmp;

            ResetOrder();
            _item[first_row, first_col].Move(second_row, second_col);
            _item[second_row, second_col].Move(first_row, first_col);
        }

        private void ResetOrder() {
            for(int column = 0; column < _columnNumber; column++) {
                for(int row = 0; row < _rowNumber; row++) {
                    _item[row, column].SetSortingOrder(_order++); 
                }
            }
        }

        public void ResetCanvas() {
            DestroyAllItems();
            _itemManager.CreateCanvas();
        }

        private void DestroyAllItems() {
            for(int column = 0; column < _columnNumber; column++) {
                for(int row = 0; row < _rowNumber; row++) {
                    DestroyItem(row, column);
                }
            }
            _item = new Items.Item[10,10];
        }
    }

}

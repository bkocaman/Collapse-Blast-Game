using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using ItemColors;

namespace Items
{
    public class Item : MonoBehaviour
    {
        private ItemColors.IColor _color;
        private MeshRenderer _renderer;
        private SortingGroup _sortingGroup;
        private Vector3 _target;
        private bool isTarget;
        private float _speed;

        private float _initialXCoordinate;
        private float _initialYCoordinate;
        private float _rowLength;
        private float _columnLength;


        void Update()
        {
            if (!isTarget)
            {
                transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
                if (_target.x == transform.position.x && _target.y == transform.position.y)
                {
                    isTarget = true;
                }
            }

        }
            public void Initialize(ItemColors.IColor color, int order, float speed,
         float initialXCoordinate, float initialYCoordinate, float rowLength, float columnLength) {
            SetBoardProperties(initialXCoordinate, initialYCoordinate, rowLength, columnLength);
            SetColor(color);
            SetSortingOrder(order);
            SetSpeed(speed);
           
            SetRenderer();
            SetTarget(this.transform);
            ChangeLevelToDefault();
        }
        private void SetBoardProperties(float initialXCoordinate, float initialYCoordinate, float rowLength, float columnLength) {
            _initialXCoordinate = initialXCoordinate;
            _initialYCoordinate = initialYCoordinate;
            _rowLength = rowLength;
            _columnLength = columnLength;
        }

        private void SetTarget(Transform transformObject) {
            isTarget = true;
            _target = transformObject.position;
        }
      
        private void SetSpeed(float speed) {
            _speed = speed;
        }
        private void SetColor(ItemColors.IColor color) {
            _color = color;
        }

        public void SetSortingOrder(int order) {
            if(_sortingGroup == null) {
                _sortingGroup = GetComponent<SortingGroup>();
            }
            _sortingGroup.sortingOrder = order;
        }

        public int GetSortingOrder() {
            if(_sortingGroup == null) {
                _sortingGroup = GetComponent<SortingGroup>();
            }
            return _sortingGroup.sortingOrder;
        }

        private void SetRenderer() {
            _renderer = GetComponent<MeshRenderer>();
            
        }

        public void SetLevel(int level) {
            _renderer.sharedMaterial = _color.GetMaterial(level);
        }

        public void ChangeLevelToDefault() {
            _renderer.sharedMaterial = _color.GetMaterial(0);
        }

        public IColor GetColor() {
            return _color;
        }

        public bool IsEqual(Items.Item block) {
            bool result = false;
            Debug.Log(block == null);
            if(block.GetSortingOrder() == _sortingGroup.sortingOrder) {
                result = true;
            }
            return result;
        } 

        public void Move(float targetRow, float targetColumn) {
            float yCoordinate =  _initialYCoordinate + _columnLength * targetColumn; 
            float xCoordinate = _initialXCoordinate + _rowLength * targetRow;
            _target = new Vector3(xCoordinate, yCoordinate, transform.position.z);
            isTarget = false;
        }
        

 

       
        }
    }


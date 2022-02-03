using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemColors;
using System;
namespace ItemColors 
{

    public class Level : ItemColors.ILevel
    {
        private Material _material;
        private int _startValue;
        private int _endValue;

        public Level(Material material) 
        {
            _material = material;
            _startValue = Int32.MinValue; 
            _endValue = Int32.MaxValue;

        }

        public Level(Material material, int startValue, int endValue) 
        {
            _material = material;
            _startValue = startValue;
            _endValue = endValue;

        }

        public Material GetMaterial()
        {
            return _material;
        }
        
        public bool IsThisLevel(int itemNumber) 
        {
            bool isThisLevel = _startValue <= itemNumber && itemNumber <= _endValue;
            return isThisLevel;
        }

        public void SetLevelBoundary(int startValue, int endValue) {
            _startValue = startValue;
            _endValue = endValue;
        }
    }

}



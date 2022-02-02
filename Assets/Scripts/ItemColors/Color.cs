using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemColors 
{
    
    public abstract class Color : IColor
    {

        public ArrayList levels = new ArrayList();
        protected ArrayList initialMaterials = new ArrayList();

        public Material GetMaterial(int levelNumber) {
            Material material = null;
            foreach (ItemColors.Level level in this.levels)
            {
                bool isThisLevel = level.IsThisLevel(levelNumber);
                if(isThisLevel) {
                    material = level.GetMaterial();
                }
            }
            return material;
        }

        public bool IsSame(IColor color) {
            return this.GetType().IsEquivalentTo(color.GetType());
        }

        protected void SetInitialLevels(ArrayList levelBoundaries) {
            for (int index = 0; index < this.initialMaterials.Count; index++)
            {
                ArrayList levelBoundary = (ArrayList) levelBoundaries[index];
                int startValue = (int) levelBoundary[0];
                int endValue = (int) levelBoundary[1];
                Material material = (Material) this.initialMaterials[index];
                ItemColors.Level level = new ItemColors.Level(material, startValue, endValue);
                this.levels.Add(level);
            }
        }
    }


}


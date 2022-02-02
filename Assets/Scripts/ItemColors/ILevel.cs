using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ItemColors 
{
    public interface ILevel
    {
        bool IsThisLevel(int blockNumber);
        Material GetMaterial();

        void SetLevelBoundary(int startValue, int endValue);

    }

}

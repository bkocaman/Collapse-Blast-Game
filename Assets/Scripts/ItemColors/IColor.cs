using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemColors 
{

    public interface IColor
    {
        Material GetMaterial(int levelNumber);
        bool IsSame(IColor color);
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemColors 
{
    public class Blue :  ItemColors.Color
    {
        // Start is called before the first frame update
        public Blue(ArrayList levelBoundaries)
        {
            this.initialMaterials = new ArrayList{ 
                Resources.Load<Material>("Materials/Blue_Default"), 
                Resources.Load<Material>("Materials/Blue_A"),
                Resources.Load<Material>("Materials/Blue_B"),
                Resources.Load<Material>("Materials/Blue_C"),
            };

            SetInitialLevels(levelBoundaries);

        }
    }
}
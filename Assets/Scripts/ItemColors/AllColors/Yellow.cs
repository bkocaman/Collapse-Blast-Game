using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace ItemColors 
{
    public class Yellow :  ItemColors.Color
    {
        // Start is called before the first frame update
        public Yellow(ArrayList levelBoundaries)
        {
            this.initialMaterials = new ArrayList{ 
                Resources.Load<Material>("Materials/Yellow_Default"), 
                Resources.Load<Material>("Materials/Yellow_A"),
                Resources.Load<Material>("Materials/Yellow_B"),
                Resources.Load<Material>("Materials/Yellow_C"),
            };

            SetInitialLevels(levelBoundaries);

        }
    }
}
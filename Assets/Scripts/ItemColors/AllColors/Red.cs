using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemColors 
{
    public class Red :  ItemColors.Color
    {
        // Start is called before the first frame update
        public Red(ArrayList levelBoundaries)
        {
            this.initialMaterials = new ArrayList{ 
                Resources.Load<Material>("Materials/Red_Default"), 
                Resources.Load<Material>("Materials/Red_A"),
                Resources.Load<Material>("Materials/Red_B"),
                Resources.Load<Material>("Materials/Red_C"),
            };

            SetInitialLevels(levelBoundaries);

        }
    }
}

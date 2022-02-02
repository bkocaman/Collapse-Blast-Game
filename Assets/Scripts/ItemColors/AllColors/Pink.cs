using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemColors 
{
    public class Pink :  ItemColors.Color
    {
        // Start is called before the first frame update
        public Pink(ArrayList levelBoundaries)
        {
            this.initialMaterials = new ArrayList{ 
                Resources.Load<Material>("Materials/Pink_Default"), 
                Resources.Load<Material>("Materials/Pink_A"),
                Resources.Load<Material>("Materials/Pink_B"),
                Resources.Load<Material>("Materials/Pink_C"),
            };

            SetInitialLevels(levelBoundaries);

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ItemColors 
{
    public class Green :  ItemColors.Color
    {
        // Start is called before the first frame update
        public Green(ArrayList levelBoundaries)
        {
            this.initialMaterials = new ArrayList{ 
                Resources.Load<Material>("Materials/Green_Default"), 
                Resources.Load<Material>("Materials/Green_A"),
                Resources.Load<Material>("Materials/Green_B"),
                Resources.Load<Material>("Materials/Green_C"),
            };

            SetInitialLevels(levelBoundaries);

        }
    }
}

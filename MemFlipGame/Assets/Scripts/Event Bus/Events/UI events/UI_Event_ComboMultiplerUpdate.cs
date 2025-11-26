using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public readonly struct UI_Event_ComboMultiplerUpdate
{
   public int comboMultiplier { get;  }
   
   public UI_Event_ComboMultiplerUpdate(int multiplier)
   {
       this.comboMultiplier = multiplier;
   }
}

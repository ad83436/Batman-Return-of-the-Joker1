using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverRender : UnityEngine.UI.Selectable
{
    BaseEventData newGameButt;
    public static  bool isHovering;
    LayerMask ButtonLayer;
   

    
    // Update is called once per frame
    void Update()
    {

        
    }



    public  void HoveringNG()
    {
        if (IsHighlighted(newGameButt))
        {

            isHovering = true;

        }

        else
        {
            isHovering = false;
        }
   }

   
}

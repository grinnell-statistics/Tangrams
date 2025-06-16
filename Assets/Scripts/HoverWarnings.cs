using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/* 
 * Class: HoverWarnings
 * Purpose: Sets active warning/info associated with:
 *          - pressing on hint button, 
 *          - hovering over info icon in additional variables
 */
public class HoverWarnings : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject hoverWarning;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Additional Variables hovering");
        hoverWarning.SetActive(true);
    }
 
    public void OnPointerExit(PointerEventData eventData)
    {
        hoverWarning.SetActive(false);
    }
}

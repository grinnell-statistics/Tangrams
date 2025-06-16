using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/* 
 * Class: HintVisibility
 * Purpose: Sets active the hint button and timer according to users selection
 */
public class HintVisibility : MonoBehaviour
{
    public Button hint; //hint Button in Game Scene
    public Text timerText; //time display in Game Scene

    // Start is called before the first frame update
    void Start()
    {
        // sets hintStatus to selected option 
        hint.gameObject.SetActive(GameOptionsScript.hintOn);

        // sets timerStatus to selected option
        timerText.gameObject.GetComponent<Timer>().isOn = GameOptionsScript.timerOn;
    } 

}

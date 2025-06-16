using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patterns : MonoBehaviour
{
    public static GameObject currentPattern;
    public static int currentPatternNum;
    public GameObject[] patterns;
    private int patternChosen;


    void Start()
    {
        patternChosen = currentPatternNum;
        currentPattern = patterns [currentPatternNum];

        //deactivate all other game objects apart from the one you have chosen
        foreach (GameObject gb in patterns) {
            if (gb != patterns[currentPatternNum]) {
                gb.SetActive(false);
            }
        }
    }

    /*

    GameObject[] patterns = {"House of Tangrams",  
                            "Diamond", "The G", 
                            "Candle","A Nice Lighthouse", 
                            "Crouching Cat", "Laughing Man"
                            "The Hook", "Simple Chair", "Piano"};

    */





}

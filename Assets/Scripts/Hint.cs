using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/* 
 * Class: Hint
 * Purpose: Manages the hints 
 */
public class Hint : MonoBehaviour
{

    public static int hintsGiven;
    public float startTime;
    Puzzle[] puzzles;

    // Start is called before the first frame update
    void Start()
    {
        hintsGiven = 0;
        startTime = Time.time;
        puzzles = GameObject.FindObjectsOfType<Puzzle>();
    }

    // Gives hint 
    public void GiveHint()
    {
        //give the time of when the hint button was clicked on the first time
        if (hintsGiven == 0)
            DataManager.gameData.hintTime = Time.time - startTime;

        //if hint button has been clicked 7 times, return
        if (hintsGiven == 7)
            return;

        int i;

        //give a random hint
        do
        {
            i = Random.Range(0, puzzles.Count());

        } while (puzzles[i].hasBeenHinted);

        puzzles[i].Hint();
        hintsGiven++;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* 
 * Class: Data
 * Purpose: contains variables to be stored in the database
 */
public class Data : MonoBehaviour
{
    public struct datum
    {
        public System.DateTime date;
        public string playerID;
        public string groupID;
        public float time;
        public string puzzle;
        public int puzzleIndex;
        public bool win;
        public int numClicks;
        public int regTime;
        public bool displayTime;
        public bool hintOn;
        public int numHints;
        public float hintTime;
        public string var1;
        public string var2;
        public string var3;
    }
}

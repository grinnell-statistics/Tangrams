using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* 
 * Class: PlayerData
 * Purpose: Manages the player data that is displayed in the win scene
 */
public class PlayerData : MonoBehaviour
{
    public static string playerAliasStr;
    public static string groupIDstr;
    bool timerStatus;
    public Text playerAlias;
    public Text groupID;
    public Text puzzleChosenStr;
    public Text timeTaken;
    public Text penaltyTime;

    private static int puzzleNum;

    void Start()
    {
        playerAlias.text = playerAliasStr;
        if(groupID != null)
            groupID.text = groupIDstr;

        //puzzleNum = puzzleChosenNumber;
        if(puzzleChosenStr != null)
        puzzleChosenStr.text = DataManager.gameData.puzzle;

        timerStatus = GameOptionsScript.timerOn;
        if (timeTaken == null)
            return;

        //time presented in seconds
        timeTaken.text = DataManager.gameData.time.ToString("F2").Split(new char[] { '.' }, System.StringSplitOptions.None)[0] + "." + DataManager.gameData.time.ToString().Split(new char[] { '.' }, System.StringSplitOptions.None)[1].Substring(0, 2);
        penaltyTime.text = (DataManager.gameData.time + DataManager.gameData.numHints * 5).ToString("F2").Split(new char[] { '.' }, System.StringSplitOptions.None)[0] + "." + (DataManager.gameData.time + DataManager.gameData.numHints * 5).ToString("F2").Split(new char[] { '.' }, System.StringSplitOptions.None)[1];
    }
}

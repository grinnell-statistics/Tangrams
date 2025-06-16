using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

/* 
 * Class: LeaderBoard
 * Purpose: Manages the display in the Leaderboard in the WinScene
 */
public class Leaderboard : MonoBehaviour
{

    public int rowNum;
    public Text PlayerIDText;
    public Text GroupIDText;
    public Text ScoreText;

    private static string[] splitData;


    private static bool isReturned;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(isReturned)
        {
            PlayerIDText.text = "No Data";
            GroupIDText.text = "No Data";
            ScoreText.text = "No Data";
            if (3 * rowNum < splitData.Count() - 1)
            {
                PlayerIDText.text = splitData[3 * rowNum];
            }
            if (3 * rowNum + 1 < splitData.Count())
            {
                GroupIDText.text = splitData[3 * rowNum + 1];
            }
            if (3 * rowNum + 2 < splitData.Count())
            {
                ScoreText.text = splitData[3 * rowNum + 2].Split(new char[] { '.' }, System.StringSplitOptions.None)[0] + "." + splitData[3 * rowNum + 2].Split(new char[] { '.' }, System.StringSplitOptions.None)[1];
            }
        }
    }

    public static IEnumerator GetLeaderBoard(string level)
    {
        //get data
        string url = "https://stat2games.sites.grinnell.edu/php/gettangramsleaderboard.php?puzzle=" + level;
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        try
        {
            string data = www.downloadHandler.text;
            //csv-ify data
            splitData = data.Split(new char[] { ',' }, System.StringSplitOptions.None);
        }
        catch(System.Exception e)
        {
            Debug.Log("Fetching Leaderboard failed.  Error Message: " + e.Message);
        }
        isReturned = true;
    }
}

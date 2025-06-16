using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* Class: GameOptions
 * Purpose: Managage the options selected by the user
 */
public class GameOptionsScript : MonoBehaviour
{
    public InputField[] vars;
    public GameObject startButton;
    public Dropdown puzzleType;
    public Toggle noLimit;
    public Toggle shortTime;
    public Toggle mediumTime;
    public Toggle longTime;
    public Toggle hint;
    public Toggle timer;
    public GameObject startErrorWarning;
    public static bool hintOn;
    public static bool timerOn;
    public static float time;
    public static string timeTag = "";
    public static int buildIndexScene;
    string[] puzzleArr;

    public GameObject badWordMenu;

    [SerializeField] public TextAsset badWordsFile;
    private string[] badWords;
    System.Random rnd = new System.Random();


    public void Start()
    {
        // if not the first time playing, puzzle type dropdown displays previously played game
        if (DataManager.gameData.puzzleIndex != 0)
            puzzleType.value = DataManager.gameData.puzzleIndex;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if (vars[0].isFocused)
                vars[2].ActivateInputField();
            if (vars[2].isFocused)
                vars[1].ActivateInputField();
            if (vars[1].isFocused)
                startButton.GetComponent<Button>().Select();
        }
    }

    // initializes the hint selection, time selection, and loads game scene
    public void StartGame()
    {
        //checks if the additional variables have any bad words inputted
         if (IsBadWord(vars[0].text) || IsBadWord(vars[1].text) || IsBadWord(vars[2].text))
        {
            badWordMenu.SetActive(true);
        }

        else {
            //stores additional variables if they're not empty
            if (!(vars[0].text=="")) {
                GetVariable1(vars[0].text);
            }
            if (!(vars[1].text=="")) {
                GetVariable2(vars[1].text);
            }
            if (!(vars[2].text=="")) {
                GetVariable3(vars[2].text);
            }

            hintOn = hint.isOn;
            timerOn = timer.isOn;
            DataManager.gameData.puzzleIndex = puzzleType.value;
            DataManager.gameData.displayTime = timer.isOn;
            DataManager.gameData.hintOn = hint.isOn;
            TimeSelection();

            if (puzzleType.value == 0){
                StartError();
                return;
            }
            else if (puzzleType.value == 1){ 
                //allows the user to select a random puzzle
                startErrorWarning.SetActive(false);
                int randomPuzzle = rnd.Next(2, 11); 
                buildIndexScene = SceneManager.GetActiveScene().buildIndex + randomPuzzle - 1;
                SceneManager.LoadScene(buildIndexScene);
            }
            else {
                startErrorWarning.SetActive(false);
                Debug.Log ("the puzzle value is " + puzzleType.value);
                buildIndexScene = SceneManager.GetActiveScene().buildIndex + puzzleType.value - 1;
                SceneManager.LoadScene(buildIndexScene);
            }

        }
        
    }

     /// <summary>
    /// Checks to see if the corresponding word matches with any words in the bad word file.
    /// </summary>
    /// <param name="word"></param>
    /// <returns></returns>
    private bool IsBadWord(string word)
    {
        word = word.ToLower();
        //Removes whitespace. Another method might be better (splitting the word and checking each)
        word = word.Replace(" ", string.Empty);
        
        int left, right;
        left = 0;
        right = badWords.Length - 1;

        while (right >= left)
        {
            if (word.Length <= 3 && word == badWords[left])
            {
                return true;
            }
            else if (word.Length > 3 && badWords[left].Length > 2 && word.Contains(badWords[left]))
            {
                return true;
            }
            else
                left++;
        }
        
        return false;
    }

     
    public void Awake()
    {
        
        badWords = badWordsFile.text.Split(',');
        for (int i = 0; i < badWords.Length; i++)
        {
            badWords[i] = badWords[i].Replace(" ", string.Empty);
            badWords[i] = badWords[i].ToLower();
        }
       
    }


    //displays an error message if user tries to proceed without clicking a puzzle
    public void StartError()
    {
        startErrorWarning.SetActive(true);
    }

    // assigns time depending on time selection
    public void TimeSelection()
    {
        if (noLimit.isOn)
        {
            time = 0;
            timeTag = "no limit"; 
        }

        else if (shortTime.isOn)
        {
            time = 60;
            timeTag = "other";
        }

        else if (mediumTime.isOn)
        {
            time = 120;
            timeTag = "other";
        }

        else if (longTime.isOn)
        {
            time = 180;
            timeTag = "other";
        }
        DataManager.gameData.regTime = (int) time;
    }


    public void GetVariable1(string s)
    {
        DataManager.gameData.var1 = s;
    }

    public void GetVariable2(string s)
    {
        DataManager.gameData.var2 = s;
    }

    public void GetVariable3(string s)
    {
        DataManager.gameData.var3 = s;
    }
}

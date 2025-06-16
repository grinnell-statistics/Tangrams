using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using UnityEngine.EventSystems;

/* 
 * Class: MainSceneScript
 * Purpose: Manages the first scene
 */
public class MainSceneScript : MonoBehaviour
{
    public GameObject playerName;
    public GameObject groupName;
    public GameObject toggleObj;
    public GameObject inputFieldsCompiled;
    public GameObject btnSubmit;
    public GameObject message;
    public GameObject creditsPanel;
    public GameObject playButton;
    public GameObject badWordMenu;

    public InputField playerAlias;
    public InputField groupID;
    private bool groupSet;
    private bool playerSet;

    private float colorProgress;

    [SerializeField] public TextAsset badWordsFile;
 
    private string[] badWords;

    [DllImport("__Internal")]
    private static extern void OpenWindow(string url);

    public void Start()
    {
        playerAlias.ActivateInputField();
        message.SetActive(false);
        groupSet = false;
        playerSet = false;
        colorProgress = 1;

        if (DataManager.gameData.playerID!=null)
            playerAlias.text = DataManager.gameData.playerID;
        if (DataManager.gameData.groupID!=null)
            groupID.text = DataManager.gameData.groupID;
            
    }

    // Loads the GameOptions Scene
    public void PlayGame()
    {
         
        if (IsBadWord(playerAlias.text) || IsBadWord(groupID.text))
        {
            badWordMenu.SetActive(true);
        }
        else if (groupSet && playerSet && (!IsBadWord(playerAlias.text)) && (!IsBadWord(groupID.text)))
        {
            PlayerData.playerAliasStr = playerAlias.text;
            PlayerData.groupIDstr = groupID.text;
            DataManager.gameData.playerID = playerAlias.text;
            DataManager.gameData.groupID = groupID.text;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            badWordMenu.SetActive(false);
        }
        else
        {
            //highlights the input fields as red if not filled
            playerAlias.image.color = Color.red;
            groupID.image.color = Color.red;
            colorProgress = 0;
            message.SetActive(true);
        }
    }


    public void Update()
    {

        //allows users to use 'tab' to return to the next input field
        if(Input.GetKeyDown(KeyCode.Tab)&&playerAlias.isFocused)
        {
            groupID.ActivateInputField();
        }
        if(Input.GetKeyDown(KeyCode.Tab)&&groupID.isFocused)
        {
            playButton.GetComponent<Button>().Select();
        }
        float garbage = .3f;
        colorProgress = Mathf.SmoothDamp(colorProgress, 1, ref garbage, 1);
        try
        {
           playerAlias.image.color = Color.Lerp(Color.red, Color.white, colorProgress);
           groupID.image.color = Color.Lerp(Color.red, Color.white, colorProgress); 
        }
        catch (System.Exception)
        {
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
                Debug.Log(badWords[left]);
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
        /*
        //Debug.Assert(creditsMenu, "Wrong initial settings");
        // Sets up data structure from bad word file
        #if !UNITY_EDITOR
            Init();
            CreateDataContext();
            CODAPSendDataAll();
        #endif
        */
        
        badWords = badWordsFile.text.Split(',');
        for (int i = 0; i < badWords.Length; i++)
        {
            badWords[i] = badWords[i].Replace(" ", string.Empty);
            badWords[i] = badWords[i].ToLower();
        }
       
    }



    /* All of the methods below that open an external link
        will not work in the Unity Editor as it is made for 
        WebGL.
        
        See Link for more info :https://va.lent.in/opening-links-in-a-unity-webgl-project/ */
    // Plays video tutorial
    public void PlayTutorial()
    {

        string Url = "https://youtu.be/D6fpjiqk0M0";
        #if !UNITY_EDITOR
            OpenWindow(Url);
        #endif
        #if UNITY_EDITOR
            Application.OpenURL(Url);
        #endif
        EventSystem.current.SetSelectedGameObject(null);
    }

    //plays resources
    public void PlayResources()
    {
        //Un-invoke button after press
        string Url = "https://stat2labs.sites.grinnell.edu/Tangrams.html";
        #if !UNITY_EDITOR
            OpenWindow(Url);
        #endif
        #if UNITY_EDITOR
            Application.OpenURL(Url);
        #endif
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void ShowCredits()
    {
        creditsPanel.SetActive(true);
    }
 
    public void ExitCredits()
    {
        creditsPanel.SetActive(false);
    }

    // Changes visibility of Gather Data UI


    public void GetGameData()
    {
        string Url = "https://stat2games.sites.grinnell.edu/data/tangrams/tangrams.php";
        #if !UNITY_EDITOR
            OpenWindow(Url);
        #endif
        #if UNITY_EDITOR
            Application.OpenURL(Url);
        #endif
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void GroupSet()
    {
        groupSet = (groupID.text.Length != 0);
    }

    public void PlayerSet()
    {
        playerSet = (playerAlias.text.Length!= 0);
    }



}

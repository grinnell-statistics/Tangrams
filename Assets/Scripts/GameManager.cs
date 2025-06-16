using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* 
 * Class: GameManager
 * Purpose: Manages the game scene, win conditions
 */
public class GameManager : MonoBehaviour
{
    /*
    struct ColliderInfo
    {
        public Collider2D collider;
        public int touching;
        public ColliderInfo(Collider2D c, int t)
        {
            collider = c;
            touching = t;
        }
    }
    */

    public static GameManager instance;
    public GameObject square;
    //public static string previousShapeTag; (REINAS TRY)
    // public Data.datum gameData;
    //private GameObject[] pieces;
    //private List<ColliderInfo> colliders;

    private void Awake()
    {
        //singleton
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        //persistent
        DontDestroyOnLoad(gameObject);
        //pieces = new GameObject[7];
    }


    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += OnLevelLoaded;
        //colliders = new List<ColliderInfo>();
        //gameData = new Data.datum();
    }

    public void gameWon()
    {
        DataManager.gameData.win = true;
        StartCoroutine(DataManager.instance.SendData());
        SceneManager.LoadScene("WinScene");
    }

    public void gameLost()
    {
        DataManager.gameData.win = false;
        StartCoroutine(DataManager.instance.SendData());
        SceneManager.LoadScene("TimeOverScene");
    }

    public void tooLong()
    {
        SceneManager.LoadScene("TooLongScene");
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //Update so no blue piece is touching other blue ones
        bool won = true;
        if (pieces[0] != null)
        {
            foreach (GameObject piece in pieces)
            {
                if (!piece.GetComponent<PieceController>().isSnapped)
                    won = false;
            }
        }
        else
            won = false;
        var puzzles = GameObject.FindObjectsOfType<Puzzle>();
        foreach(ColliderInfo ci in colliders)
        { 
            if(ci.touching==ci.collider.OverlapCollider(new ContactFilter2D().NoFilter(), new Collider2D[10]))
                won = false;
        }
        DataManager.gameData.win = won;
        if (won)
        {
            StartCoroutine(DataManager.instance.SendData());
            SceneManager.LoadScene("WinScene");
        }
        */  
    }

    public void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name=="House of Tangrams" || scene.name == "A Nice Lighthouse" || scene.name == "Candle" || scene.name == "Crouching Cat" || scene.name == "Diamond" || scene.name == "Laughing Man" 
            || scene.name == "Piano" || scene.name == "Simple Chair" || scene.name == "The G" || scene.name == "The Hook")
        {
            DataManager.gameData.puzzle = scene.name;
            //Instantiate(Patterns.currentPattern, new Vector3(9.5f, 1, 0), Quaternion.identity);
            /*
            square = GameObject.FindGameObjectWithTag("Square");
            int i = 0;
            foreach (PieceController piece in square.GetComponentsInChildren<PieceController>())
            {
                Timer.pieces[i] = piece.gameObject;
                i++;
            }
            
            var puzzles = GameObject.FindObjectsOfType<Puzzle>();
            Timer.colliders.Clear();
            foreach (Puzzle puzzle in puzzles)
            {
                foreach (Collider2D col in puzzle.gameObject.GetComponentsInChildren<Collider2D>())
                {
                    Timer.colliders.Add(new Timer.ColliderInfo(col, col.OverlapCollider(new ContactFilter2D().NoFilter(), new Collider2D[10])));

                }
            }
            */
        }
        else
        {
            //Timer.colliders.Clear();
            PieceController.outline = null;
        }
    }
}

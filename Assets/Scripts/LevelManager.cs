using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* 
 * Class: LevelManager
 * Purpose: Contains functions that restart current game and exit to the first scene
 */
public class LevelManager : MonoBehaviour
{
    // Restarts the previous game
    public void RestartGame()
    {
        // Load previous game scene
        SceneManager.LoadScene(GameOptionsScript.buildIndexScene);
    }

    // Returns to Main Scene
    public void MainMenu()
    {
        // Load main scene
        SceneManager.LoadScene("MainScene");
    }

    // Returns to Game Options
    public void QuitGame()
    {
        // Load main scene
        SceneManager.LoadScene("GameOptionsScene");
    }
}

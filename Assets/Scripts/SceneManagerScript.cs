﻿using UnityEngine;

//scene managager
public class SceneManagerScript : MonoBehaviour
{
    //go to main menu scene
    public void GoToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("mainmenu");
    }
    
    //go to credits scene
    public void GoToCredits()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("credits");

    }

    //go to playgame scene
    public void GoToPlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Endless");

    }

    //go to bonus/difficulty selection scene
    public void GoToBonusSelection()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("bonusSelect");

    }

    //how to play the game scene
    public void GoToHowToPlay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("howToPlay");

    }

    //quit game
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }

}

using UnityEngine;

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

    //go to bonus selection scene
    public void GoToBonusSelection()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("bonusSelect");

    }

    //quit game
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }

}

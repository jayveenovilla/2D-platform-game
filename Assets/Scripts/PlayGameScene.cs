using UnityEngine;
using UnityEngine.UI;

//scene is initially disabled until character is created. currently outputs a JSON of player abilities into a selectable input textfield
public class PlayGameScene : MonoBehaviour
{
    public InputField jsonOutput;
    public void Start()
    {
        //destroy gamebobject GameMusicPlayer to stop current music singleton playing
        GameObject go = GameObject.Find("GameMusicPlayer");
        if (go)
        {
            Destroy(go.gameObject);
            Debug.Log("GameMusicPlayer has been destroyed.");
        }
        string _player = JsonUtility.ToJson(GameManagerSingleton.Instance.player, true);
        jsonOutput.text = _player;
    }
}

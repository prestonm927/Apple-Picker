using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void StartNewGame()
    {
        SceneManager.LoadScene("_Scene_0");
    }
}

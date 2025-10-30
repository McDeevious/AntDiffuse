using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void MainMenuButton()
    {
        SceneManager.LoadScene("Start");
    }   
}

using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinManager : MonoBehaviour
{  

    public void MainMenuButton()
    {
        SceneManager.LoadScene("Start");
    }
}

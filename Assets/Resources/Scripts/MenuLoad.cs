using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoad : MonoBehaviour
{
    public void LoadInitialScene()
    {
        SceneManager.LoadScene("InitialScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}

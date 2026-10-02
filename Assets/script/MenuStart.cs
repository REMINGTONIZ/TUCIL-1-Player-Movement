using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay"); // ganti sesuai nama scene game-mu
    }

    public void QuitGame()
    {
        Debug.Log("Keluar dari game");
        Application.Quit();
    }
}
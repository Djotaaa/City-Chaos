using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    void Update()
    {
        MainMenuInputReader();
    }

    void MainMenuInputReader()
    {
        int mainLevelSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(mainLevelSceneIndex);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
    }
}

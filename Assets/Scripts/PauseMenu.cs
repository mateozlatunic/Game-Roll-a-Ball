using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public Text pauseText;
    public GameObject panel;
    public GameObject resumeButton;
    public GameObject playAgainButton; // Dodano za gumb "Play again"
    public GameObject quitButton;

    private void Start()
    {
        pauseText.text = "";
        panel.SetActive(false);
        resumeButton.SetActive(false);
        playAgainButton.SetActive(false);
        quitButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
        pauseText.text = "";
        panel.SetActive(false);
        resumeButton.SetActive(false);
        playAgainButton.SetActive(false);
        quitButton.SetActive(false);
    }

    void Pause()
    {
        GameIsPaused = true;
        Time.timeScale = 0f;
        pauseText.text = "PAUSE";
        panel.SetActive(true);
        resumeButton.SetActive(true);
        playAgainButton.SetActive(true);
        quitButton.SetActive(true);
    }

    public void resetGame()
    {
        Resume();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex, LoadSceneMode.Single);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene(2);
    }
}

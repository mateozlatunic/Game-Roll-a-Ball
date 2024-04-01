using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject startButton; // Dodano za gumb "Play again"
    public GameObject quitButton;

    private void Start()
    {
        startButton.SetActive(false); // Inicijalno sakrijemo gumb "Play again"
        quitButton.SetActive(false);
    }

    void Update()
    {
        if (true)
        {
            startButton.SetActive(true);     // Prikažemo gumb "Start"
            quitButton.SetActive(true);      // Prikažemo gumb "Quit"

        }
    }

    public void startGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}

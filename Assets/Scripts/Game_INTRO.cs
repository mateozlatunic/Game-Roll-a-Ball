using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_INTRO : MonoBehaviour
{
    public float wait_time = 5f;

    void Start()
    {
        StartCoroutine(WaitForIntro());
    }

    IEnumerator WaitForIntro()
    {
        yield return new WaitForSeconds(wait_time);
        SceneManager.LoadScene(1);
    }
}

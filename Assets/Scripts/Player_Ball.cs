using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player_Ball : MonoBehaviour
{
    public float speed;
    /*
    public AudioClip clip;
    public AudioClip clip2;
    public AudioSource source;
    */
    public Text countText;
    public Text winText;
    public GameObject panel;
    public GameObject playAgainButton; // Dodano za gumb "Play again"
    public GameObject quitButton;

    private Rigidbody rb;
    private int count;
    private bool textInitialized = false;

    void Start()
    {
        // source = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        count = 0;
        InitializeText(); // Dodajemo funkciju za inicijalizaciju teksta
        winText.text = "";
        playAgainButton.SetActive(false); // Inicijalno sakrijemo gumb "Play again"
        quitButton.SetActive(false);
        panel.SetActive(false);
    }

    // Metoda za inicijalizaciju teksta
    void InitializeText()
    {
        if (countText != null)
        {
            textInitialized = true;
            SetCountText();
        }
        else
        {
            Debug.LogError("CountText nije postavljen u Unity sučelju!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        FindObjectOfType<AudioMenager>().Play("PlayerBall");
        var moveH = Input.GetAxis("Horizontal");
        var moveV = Input.GetAxis("Vertical");
        // source.PlayOneShot(clip);
        rb.AddForce(new Vector3(moveV, 0, moveH) * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            other.gameObject.SetActive(false);
            count++;
            FindObjectOfType<AudioMenager>().Play("PointCollect");
            // source.PlayOneShot(clip2);
            if (textInitialized) // Provjera je li tekst inicijaliziran prije nego što ga ažuriramo
            {
                SetCountText();

                if (count == 11)
                {
                    winText.text = "YOU WON :)";
                    panel.SetActive(true);
                    playAgainButton.SetActive(true); // Prikažemo gumb "Play again"
                    quitButton.SetActive(true);      // Prikažemo gumb "Quit"
                }
            }
        }
    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
    }
}

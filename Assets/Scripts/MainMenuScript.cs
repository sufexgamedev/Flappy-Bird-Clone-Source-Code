using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject[] ScoreUI;
    public AudioSource audioSource;
    public AudioClip StartSound;

    public bool FadeIn = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (MainMenu.activeInHierarchy == true)
        {
            Time.timeScale = 0;
            ScoreUI[0].SetActive(false);
            ScoreUI[1].SetActive(false);
            ScoreUI[2].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (MainMenu.activeInHierarchy == true && Input.GetMouseButtonDown(0))
        {
            MainMenu.SetActive(false);
            Time.timeScale = 1;
            ScoreUI[0].SetActive(true);
            GameStartSound();
        }
    }

    // Sound
    private void GameStartSound()
    {
        audioSource.PlayOneShot(StartSound);
    }
}

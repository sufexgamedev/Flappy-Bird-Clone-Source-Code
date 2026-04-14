using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject GameOverScreen;
    public AudioSource audioSource;
    public AudioClip GameOverSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Replay Game
        if (GameOverScreen.activeInHierarchy == true && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Replay());
        }
    }

    private void FixedUpdate()
    {
        // Bird Out of the Screen Logic
        if (transform.position.y >= 4.8)
        {
            BirdDieSound();
            StartCoroutine(GameOver());
        }
    }

    // Game Over Logic
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            BirdDieSound();
            StartCoroutine(GameOver());
        }
    }


    private IEnumerator GameOver()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1.142f);
        ShowGameOverScreen();
    }

    private void ShowGameOverScreen()
    {
        GameOverScreen.SetActive(true);
    }

    // Restart Game
    IEnumerator Replay()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        yield return null;
    }

    // Sounds
    private void BirdDieSound()
    {
        audioSource.PlayOneShot(GameOverSound);
    }
}

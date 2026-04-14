using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public BirdController birdScript;
    public CreditsManagerScript creditsManagerScript;

    public Sprite[] ScoreSprites;
    public Image OnesDigitScore;
    public Image TensDigitScore;
    public Image HundredsDigitScore;
    public AudioSource audioSource;
    public AudioClip[] ScoreSFX;

    private int Score = 0;

    public GameObject[] ObjectsToDestroy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OnesDigitScore.sprite = ScoreSprites[Score];
    }

    // Updating Score
    private void UpdateScore(int _score)
    {
        if(_score < 10)
        {
            // 0 To 9
            TensDigitScore.gameObject.SetActive(false);
            HundredsDigitScore.gameObject.SetActive(false);
            OnesDigitScore.sprite = ScoreSprites[_score];
        }
        if(_score >= 10 && _score < 100)
        {
            // 10 To 99
            TensDigitScore.gameObject.SetActive(true);

            int tensdigit = _score / 10;
            int onesdigit = _score % 10;

            OnesDigitScore.sprite = ScoreSprites[onesdigit];
            TensDigitScore.sprite = ScoreSprites[tensdigit];

            // Setting Positions
            float xOffset = 50f;
            float yOffset = OnesDigitScore.rectTransform.anchoredPosition.y;

            OnesDigitScore.rectTransform.anchoredPosition = new Vector3(xOffset, yOffset, 0);
            TensDigitScore.rectTransform.anchoredPosition = new Vector3(-xOffset, yOffset, 0);
        }
        // 100
        if(_score == 100)
        {
            HundredsDigitScore.gameObject.SetActive(true);

            OnesDigitScore.sprite = ScoreSprites[0];
            TensDigitScore.sprite = ScoreSprites[0];

            // Setting Positions
            float xOffset = 100f;
            float yOffset = OnesDigitScore.rectTransform.anchoredPosition.y;

            OnesDigitScore.rectTransform.anchoredPosition = new Vector3(xOffset, yOffset, 0);
            TensDigitScore.rectTransform.anchoredPosition = new Vector3(0, yOffset, 0);
            HundredsDigitScore.rectTransform.anchoredPosition = new Vector3(-xOffset, yOffset, 0);
        }
    }

    // Detecting Score
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Score < 100 && collision.gameObject.CompareTag("ScoreDetector"))
        {
            Score++;
            UpdateScore(Score);
            ScoreSound();
        }

        // Game Ending Logic
        if (Score == 20 && collision.gameObject.CompareTag("ScoreDetector"))
        {
            GameEnding();
        }
    }

    private void GameEnding()
    {
        // Bird move to conter
        birdScript.BirdLastMove();

        // Destroying Objects
        foreach (GameObject Obj in ObjectsToDestroy)
        {
            Destroy(Obj);
        }

        GameObject[] Pipeclones = GameObject.FindGameObjectsWithTag("Finish");
        foreach (GameObject clones in Pipeclones)
        {
            Destroy(clones);
        }
        GameObject[] scoreDetectorClones = GameObject.FindGameObjectsWithTag("ScoreDetector");
        foreach(GameObject clones in scoreDetectorClones)
        {
            Destroy(clones);
        }

        // Credit Music
        CreditsMusic();

        // Show Credits Text
        creditsManagerScript.ShowCreditText();
    }

    // Sounds
    private void ScoreSound()
    {
        audioSource.PlayOneShot(ScoreSFX[0]);
    }

    private void CreditsMusic()
    {
        audioSource.PlayOneShot(ScoreSFX[1]);
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManagerScript : MonoBehaviour
{
    public GameObject CreditText;
    public Animator CreditAnimator;
    public GameObject FadeOutPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreditText.SetActive(false);
        FadeOutPanel.SetActive(false);
    }

    // Credits Text Scrolling
    public void ShowCreditText()
    {
        CreditText.SetActive(true);
        StartCoroutine(ShowCreditScrolling());
        StartCoroutine(FadeOut());
    }

    private IEnumerator ShowCreditScrolling()
    {
        yield return null;

        CreditAnimator.SetTrigger("ScrollText");
    }

    // Fade Out
    private IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(15);

        FadeOutPanel.SetActive(true);
        StartCoroutine(ReturnToMainMenu());
    }

    // Restart Game
    private IEnumerator ReturnToMainMenu()
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

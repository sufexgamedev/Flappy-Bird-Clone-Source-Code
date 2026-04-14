using System.Collections;
using UnityEngine;
public class BirdController : MonoBehaviour
{

    // Variables
    public Rigidbody2D rb;
    public float JumpForce;
    public Animator birdAnimator;
    public bool DontMove = false;
    public Transform CenterPoint;

    public AudioSource audioSource;
    public AudioClip[] BirdSFX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Tap to jump mechanics + Fly Animation Controller
        if (Time.timeScale == 1 && !DontMove && Input.GetMouseButtonDown(0))
        {
            rb.linearVelocity = new Vector2(0f, JumpForce);
            JumpSound();
            birdAnimator.SetBool("CanFly", true);
        }
        if (!DontMove && rb.linearVelocityY < rb.position.y)
        {
            birdAnimator.SetBool("CanFly", false);
        }
    }

    public void BirdLastMove()
    {
        // rb.bodyType = RigidbodyType2D.Static;
        StartCoroutine(BirdSmoothMove(CenterPoint.position, 1f));
        DontMove = true;
        birdAnimator.SetBool("CanFly", true);
        rb.gravityScale = 0;
        rb.linearVelocity = new Vector3(0, 0, 0);
    }

    // Bird Smoothly Move To Center at the Ending
    private IEnumerator BirdSmoothMove(Vector3 target, float duration)
    {
        Vector3 start = transform.position;
        float elapased = 0;

        while(elapased < duration)
        {
            transform.position = Vector3.Lerp(start, target, elapased / duration);
            elapased += Time.deltaTime;
            yield return null;
        }

        transform.position = target;
    }

    // Sounds
    public void JumpSound()
    {
        audioSource.PlayOneShot(BirdSFX[0]);
    }
}

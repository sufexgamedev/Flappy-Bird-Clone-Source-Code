using UnityEngine;

public class PipeMoveLeft : MonoBehaviour
{
    public float PipeSpeed;

    private void FixedUpdate()
    {
        transform.position += PipeSpeed * Time.deltaTime * Vector3.left;

        if (transform.position.x <= -3.5)
        {
            Destroy(gameObject);
        }
    }
}

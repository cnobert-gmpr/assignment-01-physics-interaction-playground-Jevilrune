using UnityEngine;
using System.Collections; 

public class FreezeEffect : MonoBehaviour
{
    private Rigidbody2D rb;
    private float originalGravityScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            originalGravityScale = rb.gravityScale; 
        }
    }

    public void ApplyFreeze(float duration)
    {
        if (rb != null)
        {
            StartCoroutine(FreezeRoutine(duration));
        }
    }

    private IEnumerator FreezeRoutine(float duration)
    {
 
        rb.bodyType = RigidbodyType2D.Kinematic; 
        rb.linearVelocity = Vector2.zero; 
        rb.gravityScale = 0f; 

 
        yield return new WaitForSeconds(duration);

 
        rb.bodyType = RigidbodyType2D.Static; 
        rb.gravityScale = originalGravityScale; 
    }
}

using UnityEngine;

public class BumperAction : MonoBehaviour
{
 private float bumperForce = 10f;

    [System.Obsolete]
    void OnCollisionEnter2D(Collision2D col) {
        
        ContactPoint2D[] otherObjects = col.contacts;
        foreach(ContactPoint2D contact in otherObjects) 
        {
            var norm = contact.normal;
            col.rigidbody.velocity = Vector2.zero;
            contact.rigidbody.AddForce( -1 * norm * bumperForce,  ForceMode2D.Impulse);
        }  
    }
}
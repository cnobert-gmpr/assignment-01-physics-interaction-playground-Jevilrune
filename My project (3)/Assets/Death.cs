using System.Collections;
using UnityEngine;

namespace Deathzonehome
{
    public class DeathZone : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private float _respawnDelay = 2f;
        private float _seconds = 0f;
        private int _deathCount = 0;

        void OnTriggerEnter2D(Collider2D collider)
        {
            Debug.Log($"'{collider.gameObject.name}' has entered the Death Zone");
            Rigidbody2D rb = collider.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.gravityScale = 0f;
                Destroy(rb);
            }
            _deathCount++;
            Debug.Log($"Total Deaths so far: {_deathCount}");

            if (collider.CompareTag("Ball"))
            {
                GameObject ballCollider = collider.gameObject;
                Debug.Log($"'{ballCollider.name}' has entered the Death Zone");

                StartCoroutine(RespawnBall(ballCollider));
            }
        }


    private IEnumerator RespawnBall(GameObject ball)
        {

            yield return new WaitForSeconds(_respawnDelay);

            Rigidbody2D ballRB = ball.GetComponent<Rigidbody2D>();
            if (ballRB != null)
            {
                ballRB.linearVelocity = Vector2.zero;
                ballRB.angularVelocity = 0f;
            }
            else
            {
                Debug.Log($"'{ball.name}' is missing a Rigidbody2D component");
            }
            ball.transform.position = _spawnPoint.position;
            Debug.Log($"'{ball.name}' has respawned at the spawn point");
        }
    }
}


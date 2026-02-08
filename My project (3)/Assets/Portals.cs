using UnityEngine;
using System.Collections.Generic;

public class PortalScript : MonoBehaviour
{
    [SerializeField] private Transform destinationPortal;
    private HashSet<GameObject> teleportableObjects = new HashSet<GameObject>(); 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball")) 
        {
            if (!teleportableObjects.Contains(other.gameObject))
            {
                destinationPortal.GetComponent<PortalScript>().teleportableObjects.Add(other.gameObject);
                other.transform.position = destinationPortal.transform.position;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (teleportableObjects.Contains(other.gameObject))
        {
            teleportableObjects.Remove(other.gameObject);
        }
    }
}
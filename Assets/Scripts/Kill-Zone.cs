using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Death!");
            collision.GetComponent<Checkpoint>().Respawn();
        }
    }
}

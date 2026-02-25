using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Vector2 respawnPoint;
    void Start()
    {
        respawnPoint = transform.position;
    }

    public void Respawn()
    {
        transform.position = respawnPoint;
    }    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "checkpoint")
        {
            respawnPoint = collision.transform.position;
        }
    }
}

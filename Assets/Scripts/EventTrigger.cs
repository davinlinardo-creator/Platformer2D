using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;


public enum TypeTag
{
    Player,
    Type,
    Checkpoint,
    Finish,
    Trigger
}
public class EventTrigger : MonoBehaviour
{
    public TypeTag targetTag;
    public UnityEvent<GameObject> trigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == targetTag.ToString());
        {
            Debug.Log(collision.gameObject.name + " Is colliding with " + gameObject.name);
            trigger.Invoke(collision.gameObject);
        }
    }
}

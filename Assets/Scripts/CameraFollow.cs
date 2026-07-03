using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector2 offset = new Vector2(0, 0);
    private Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 newPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);
            transform.position = newPosition;
        }
    }

}

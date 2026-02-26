using UnityEngine;

public class asd : MonoBehaviour
{
    static float t = 0;
    public float distance;
    public float speed;
    public float originalPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        t += Time.deltaTime * speed;
        var x = originalPos + Mathf.Sin(t) * distance; 
        transform.position = new Vector2 (x, transform.position.y);
    }
}

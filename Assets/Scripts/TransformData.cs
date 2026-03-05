using UnityEngine;

[CreateAssetMenu(fileName = "TransformData", menuName = "Scriptable Objects/TransformData")]
public class TransformData : ScriptableObject
{
    public Vector2 position;

    public void ResetData()
    {
        position = new Vector2(6, 2);
    }
}

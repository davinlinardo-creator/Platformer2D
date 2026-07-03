using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    public TransformData playerpositiondata;
    Vector2 CurrentPosition;
    Vector2 CheckpointPosition;

    private void Start()
    {
        CheckpointPosition = new Vector2(-8f, 2f);
    }
    public void OnCheckpoint(GameObject col)
    {
        if (col.gameObject.tag == "checkpoint")
        {
            Debug.Log("Position Saved!");
            Vector2 newCheckpoint = col.transform.position;
            CheckpointPosition = newCheckpoint;
            SavePosition(CheckpointPosition);
        }
    }

    private void SavePosition (Vector2 newPostition)
    {
        playerpositiondata.position = newPostition;
    }

    public void OnEnemy(GameObject col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("Player teleported to the last checkpoint.");
            ResetPosition(CheckpointPosition);
        }
    }

    public void OnDeath (GameObject col)
    {
        if (col.gameObject.tag == "Kill")
        {
            Debug.Log("Player teleported to the last checkpoint.");
            ResetPosition(CheckpointPosition);
        }
    }

    private void ResetPosition (Vector2 Position)
    { 
        transform.position = Position;
    }

    public void OnFinish()
    {
        GameManager.instance.ChangeLevel(0);
        GameManager.instance.ChangeLevel(1);
    }

}

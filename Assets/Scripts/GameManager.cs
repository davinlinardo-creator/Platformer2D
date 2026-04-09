using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region GameManager
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameManagerCheck()
    {
        Debug.Log("Game manager is working!");
    }

    #endregion


    #region GameManagement
    public bool isPaused;
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void unPause()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }

    #endregion

    #region level manager
    levelData levelData;
    public int levelCurrent;

    public void CheckSaveFile()
    {
        if (File.Exists(Application.dataPath + "/level.json")) Loadlevel();
        else Savelevel();
    }

    private void Savelevel()
    {
        levelData = new levelData();
        levelData.level = levelCurrent;
        string json = JsonUtility.ToJson(levelData, true);
        File.WriteAllText(Application.dataPath + "/Level.json", json);
    }

    private void Loadlevel()
    {
        string json;
        json = File.ReadAllText(Application.dataPath + "/Level.json");
        levelData levelData = JsonUtility.FromJson<levelData>(json);
        levelCurrent = levelData.level;
    }

    private void CheckLevel()
    {
        Loadlevel();
        levelCurrent = levelData.level;
    }

    public void ChangeLevel(int newLevelUnlocked)
    {
        levelCurrent = newLevelUnlocked;
        Savelevel();
    }

    public void ResetLevel()
    {
        levelCurrent = 0;
        Savelevel();
    }

    #endregion

    #region Panel Management Data
    public bool isStart;
    #endregion

}

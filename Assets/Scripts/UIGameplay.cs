using UnityEngine;
using UnityEngine.UI;

public class UIGameplay : MonoBehaviour
{
    public int sceneIndex;
    public Button buttonResume;
    public Button buttonPause;
    public Button buttonMenu;

    private void Start()
    {
       buttonMenu.onClick.AddListener(() => GameManager.instance.ChangeScene(0));
        buttonPause.onClick.AddListener(HandleButtonClick);
        buttonResume.onClick.AddListener(HandleButtonClick);
    }

    private void HandleButtonClick()
    {
        if (GameManager.instance.isPaused)
        {
            GameManager.instance.unPause();
            buttonPause.gameObject.SetActive(true);
            buttonResume.gameObject.SetActive(false);
        }
        else
        {
            GameManager.instance.Pause();
            buttonPause.gameObject.SetActive(false);
            buttonResume.gameObject.SetActive(true);
        }
    }
}

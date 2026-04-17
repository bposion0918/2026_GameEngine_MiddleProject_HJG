using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManage : MonoBehaviour
{
    public GameObject GuidePanel;
    public GameObject OptionPanel;

    public void ButtonLog()
    {
        Debug.Log("BUTTON CLICKED!");
    }

    public void GameStart()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void OpenGuide()
    {
        GuidePanel.SetActive(true);
    }
    public void CloseGuide()
    {
        GuidePanel.SetActive(false);
    }

    public void OpenOption()
    {
        OptionPanel.SetActive(true);
    }
    public void CloseOption()
    {
        OptionPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("게임 종료");
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OptionPanel.SetActive(!OptionPanel.activeSelf);
        }
    }
}
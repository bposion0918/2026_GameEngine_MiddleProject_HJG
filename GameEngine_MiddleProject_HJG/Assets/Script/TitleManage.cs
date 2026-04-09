using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManage : MonoBehaviour
{
    public GameObject GidePanel;
    public GameObject OptionPanel;

    public void ButtonLog()
    {
        Debug.Log("BUTTON CLICKED!");
    }

    public void GameStart()
    {
        SceneManager.LoadScene("PlayScene_Tutorial");
    }

    public void OpenGide()
    {
        GidePanel.SetActive(true);
    }
    public void CloseGide()
    {
        GidePanel.SetActive(false);
    }

    public void OpenOption()
    {
        OptionPanel.SetActive(true);
    }
    public void CloseOption()
    {
        OptionPanel.SetActive(false);
    }

}

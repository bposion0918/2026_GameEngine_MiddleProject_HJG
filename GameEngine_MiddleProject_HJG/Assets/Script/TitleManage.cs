using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMage : MonoBehaviour
{
    public GameObject GidePanel;

    public void ButtonLog()
    {
        Debug.Log("BUTTON CLICKED!");
    }

    public void Gamestart()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

}

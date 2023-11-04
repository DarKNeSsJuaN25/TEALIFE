using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonText : MonoBehaviour
{
    public void StartBtn()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

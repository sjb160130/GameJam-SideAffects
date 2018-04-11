using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("Main");
    }
}
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScene1 : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("Start");
    }
}
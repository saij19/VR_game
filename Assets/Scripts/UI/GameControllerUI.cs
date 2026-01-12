using UnityEngine.SceneManagement;
using UnityEngine;

public class GameControlUI : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

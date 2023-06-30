using UnityEngine;
using UnityEngine.SceneManagement;


public class NextLevel : MonoBehaviour
{
    [SerializeField] private string levelName;
    public void Load()
    {
        if (levelName == "")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            SceneManager.LoadScene(levelName);
        }
    }
}


using UnityEngine;


public class PauseMenu : MonoBehaviour
{
    public void Enable()
    {
        Time.timeScale = 0;
    }
    public void Disable()
    {
        Time.timeScale = 1;
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }
    public void LoadScene(string name)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(name);
    }

    public const string player_x = "Player_x", player_y = "Player_y", player_z = "Player_z",
        player_rotation = "Player_rotation", current_scene = "Current_scene";
    public void Save()
    {
        print("save");
        var player = FindObjectOfType<PlayerMove>();
        if (player)
        {
            PlayerPrefs.SetFloat(player_x, player.transform.position.x);
            PlayerPrefs.SetFloat(player_y, player.transform.position.y);
            PlayerPrefs.SetFloat(player_z, player.transform.position.z);
            PlayerPrefs.SetFloat(player_rotation, player.transform.rotation.y);
            print(SceneManager.GetActiveScene().name);
            PlayerPrefs.SetString(current_scene, SceneManager.GetActiveScene().name);
            print(PlayerPrefs.GetString(current_scene));
        }
    }
    public void Load()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString(current_scene));
    }
    public void DropSave()
    {
        PlayerPrefs.DeleteAll();
    }
}

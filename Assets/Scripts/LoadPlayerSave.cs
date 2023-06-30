using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayerSave : MonoBehaviour
{
    private void Awake()
    {
        transform.SetPositionAndRotation(
            new Vector3(PlayerPrefs.GetFloat(GameManager.player_x), PlayerPrefs.GetFloat(GameManager.player_y),
                        PlayerPrefs.GetFloat(GameManager.player_z)),
            Quaternion.Euler(0, PlayerPrefs.GetFloat(GameManager.player_rotation), 0));
    }
}

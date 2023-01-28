using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlayer : MonoBehaviour
{
    private void Start()
    {
        int IndexPlayer = PlayerPrefs.GetInt("IndexPlayer");
        Instantiate(GameManager.Instance.players[IndexPlayer].playablePlayer, transform.position, Quaternion.identity);
    }
}

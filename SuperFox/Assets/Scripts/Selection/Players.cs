using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayer", menuName = "Player")]

public class Players :  ScriptableObject
{

    public GameObject playablePlayer;

    public Sprite image;

    public string name;

}

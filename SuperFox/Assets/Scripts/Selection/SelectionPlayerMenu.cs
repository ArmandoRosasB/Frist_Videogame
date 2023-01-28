using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SelectionPlayerMenu : MonoBehaviour
{
    private int index;

    [SerializeField] private Image image;
    [SerializeField] private  TextMeshProUGUI name;

    private GameManager gameManager;

    private void Start() {
        gameManager = GameManager.Instance;

        index = PlayerPrefs.GetInt("IndexPlayer");

        if (index > gameManager.players.Count - 1){
            index = 0;
        }

        ChangeScreen();
    }

    private void ChangeScreen(){
        PlayerPrefs.SetInt("IndexPlayer", index);
        image.sprite = gameManager.players[index].image;
        name.text = gameManager.players[index].name;
    }

    public void Next(){
        if (index == gameManager.players.Count - 1){
            index = 0;
        }
        else{
            index++;
        }
    
        ChangeScreen();
    }

     public void Prev(){
        if (index == 0){
            index =  gameManager.players.Count - 1;
        }
        else{
            index--;
        }
    
        ChangeScreen();
    }

    public void StartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}

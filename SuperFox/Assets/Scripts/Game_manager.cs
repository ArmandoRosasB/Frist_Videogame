using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_manager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject gameOverMenu;


    public float velocity = 2;
    public GameObject col;
    public GameObject slime;
    public GameObject vulture;
    public Renderer fondo;
    public bool gameOver = false;
    public bool start = false;

    public List<GameObject> cols;
    public List<GameObject> enemies;
    // Start is called before the first frame update
    void Start()
    {
        // Create map
        for(int i = 0; i < 20; i++){
            cols.Add(Instantiate(col, new Vector2(-10 + i,-3), Quaternion.identity));
        }

        //Create enemies
        enemies.Add(Instantiate(slime, new Vector2(12, -2.7f), Quaternion.identity));
        enemies.Add(Instantiate(vulture, new Vector2(18, 3), Quaternion.identity));

    }

    // Update is called once per frame
    void Update()
    {
        if (!start){
            if (Input.GetKeyDown(KeyCode.X)){
                start = true;
            }
        }

        if (start && gameOver){
            gameOverMenu.SetActive(true); 
            if (Input.GetKeyDown(KeyCode.X)){
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }


        if (start && !gameOver){

            mainMenu.SetActive(false); 

            fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.02f, 0) * Time.deltaTime;

            // Move map
            for(int i = 0; i < cols.Count; i++){
                if (cols[i].transform.position.x <= -10){
                    cols[i].transform.position = new Vector3(10,-3,0);
                }
                cols[i].transform.position = cols[i].transform.position + new Vector3(-1,0,0) * Time.deltaTime * velocity;
            }

            //Move enemies
            for(int i = 0; i < enemies.Count; i++){
                if (enemies[i].transform.position.x <= -10){
                    float random_enemies = Random.Range(11, 18);
                    if (i == 0){
                        enemies[i].transform.position  = new Vector3(random_enemies, -2.7f, 0);
                    }

                    if (i == 1){
                        float random_height = Random.Range(-1, 4);
                        enemies[i].transform.position  = new Vector3(random_enemies, random_height, 0);
                    }

                }
                enemies[i].transform.position = enemies[i].transform.position + new Vector3(-1,0,0) * Time.deltaTime * velocity;
            }

        }

    }
}

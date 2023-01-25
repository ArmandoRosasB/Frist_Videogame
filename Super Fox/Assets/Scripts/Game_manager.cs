using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_manager : MonoBehaviour
{
    public float velocity = 2;
    public GameObject col;
    public Renderer fondo;

    public List<GameObject> cols;
    // Start is called before the first frame update
    void Start()
    {
        // Create map
        for(int i = 0; i < 20; i++){
            cols.Add(Instantiate(col, new Vector2(-10 + i,-3), Quaternion.identity));
        }
    }

    // Update is called once per frame
    void Update()
    {
        fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.02f, 0) * Time.deltaTime;

        // Move map
        for(int i = 0; i < cols.Count; i++){
            if (cols[i].transform.position.x <= -10){
                cols[i].transform.position = new Vector3(10,-3,0);
            }
            cols[i].transform.position = cols[i].transform.position + new Vector3(-1,0,0) * Time.deltaTime * velocity;
        }
    }
}

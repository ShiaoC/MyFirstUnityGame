using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class VisableRoad : MonoBehaviour
{
    public Tilemap map;

    void Start()
    {
        map = GetComponent<Tilemap>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.name == "Player"){
            map.color = new Color(0,0,0,0.3f);
        }
    }

    void OnTriggerStay2D(Collider2D other){
        if (other.name == "Player"){
            map.color = new Color(0.5f,0.5f,0.5f,0.3f);
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.name == "Player"){
            map.color = new Color(1,1,1,1);

        }
    }
}

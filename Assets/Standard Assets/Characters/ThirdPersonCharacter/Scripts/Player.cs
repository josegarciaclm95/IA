using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public int speed;
    public int id;
    public string nombre;
    public GameObject objeto;
    private Vector3 position;

    void Start()
    {
        this.objeto = GetComponent<GameObject>();
        Debug.Log(this.name + " is created");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void setPosition(Vector3 p)
    {
        this.position = p;
    }
    public Vector3 getPosition()
    {
        return this.position;
    }
}

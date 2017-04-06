using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour {

    // Use this for initialization
    Team teamA;
    Team teamB;
	int players;
    public GameObject prefab;
    public GameObject prefab2;
    public Material style2;
    void Start () {
		this.players = 5;
        this.teamA = new Team(0,"Computasio");
        this.teamA.attack();
        this.teamB = new Team(1, "IS");
        this.teamB.defend();
		this.createPlayers (this.teamA, this.prefab);
		this.createPlayers (this.teamB, this.prefab2);
	}
	
	// Update is called once per frame
	void Update () {
        this.teamA.updateStrategies();
        this.teamB.updateStrategies();
    }

	void createPlayers (Team team, GameObject obj){
		for (int i = 0; i < this.players; i++) {
            GameObject p = Instantiate(obj);
            Player j = p.GetComponent<Player>();
           
            j.id = i;
            j.nombre = "Player" + i;
            Debug.Log("Creo jugador-> "+j.id);        
            
            team.addPlayer(j);
		}
	}
}

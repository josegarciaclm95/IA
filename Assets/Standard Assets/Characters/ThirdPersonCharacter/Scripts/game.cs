using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour {

    // Use this for initialization
    Team teamA;
    Team teamB;
	int players;
    public GameObject prefab;
	void Start () {
		this.players = 5;
        this.teamA = new Team(0,"Computasio");
        this.teamA.attack();
        this.teamB = new Team(1, "IS");
        this.teamB.defend();
		this.createPlayers (this.teamA, new Color(0,0,1));
		this.createPlayers (this.teamB, new Color(0, 1, 0));
	}
	
	// Update is called once per frame
	void Update () {
        this.teamA.updateStrategies();
        this.teamB.updateStrategies();
    }

	void createPlayers (Team team, Color color){
		for (int i = 0; i < this.players; i++) {
            GameObject p = Instantiate(prefab);
            Player j = p.GetComponent<Player>();
            j.id = i;
            j.nombre = "Player" + i;
            Debug.Log("Creo jugador-> "+j.id);
            // p.GetComponent<Renderer>().sharedMaterial.color = color;
            team.addPlayer(j);
		}
	}
}

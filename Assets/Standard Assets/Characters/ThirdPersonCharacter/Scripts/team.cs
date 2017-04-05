using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team {

    int id;
    string nombre;
    List<Player> players;
    Strategy strategy;
    List<Vector3> playersTarget;
    Vector3 target;
    public Team(int id, string name)
    {
        this.id = id;
        this.nombre = name;
        this.players = new List<Player>();
        this.strategy = new Strategy();
        this.target = new Vector3(-12, 0, -11);
    }

    public void addPlayer(Player p){
        this.players.Add(p);
    }
    public void attack()
    {
        this.playersTarget = this.strategy.Attack(this.target);
    }
    public void defend()
    {
        this.playersTarget = this.strategy.Defend(this.target);
    }
    public void updateStrategies()
    {
        foreach(var p in this.players)
        {
            p.setPosition(this.playersTarget[p.id]);
        }
    }
}

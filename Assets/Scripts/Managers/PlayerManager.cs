using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public List<Player> players = new List<Player>();
     

    internal void AssignTurn(int currentPlayerTurn)
    {
        foreach(Player player in players){
            player.myTurn = player.ID == currentPlayerTurn;
            if (player.myTurn) player.mana=5;
        }
        UIManager.instance.UpdateManaValues(players[0].mana, players[1].mana);
        
    }

    public void DamagePlayer(int ID, int damage)
    {
        Player player = FindPlayerByID(ID);
        player.health -= damage;
        UIManager.instance.UpdateHealthValues(players[0].health,players[1].health);


        if(player.health <= 0)
        {
            PlayerLost(ID);
        }
    }

    private void PlayerLost(int ID)
    {
        UIManager.instance.GameFinished(ID==0?FindPlayerByID(1):FindPlayerByID(0));
    }

    private void Awake() {
        instance = this;  
    }

    private void Start() {
        UIManager.instance.UpdateValues(players[0], players[1]);
    }

    public Player FindPlayerByID(int ID){
        Player foundPlayer = null;
        foundPlayer= players[ID];
        
        return foundPlayer;
    }

    internal void SpendMana(int ownerID, int manaCost)
    {
        FindPlayerByID(ownerID).mana -= manaCost;
        UIManager.instance.UpdateManaValues(players[0].mana,players[1].mana);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BoardSpaces : MonoBehaviour
{
    public int power;
    public int colour;
    public int value;
    public MeshRenderer mr;
    public TextMeshPro PowerGUI;
    public bool HasPlayer = false;
    public PlayerGameMovement PlayerOn;

    // Start is called before the first frame update
    void Start()
    {
        UpdateSpace();
    }

    public void UpdateSpace()
    {
        if (power > 0 && colour != 1 && colour != 6 && colour != 7)
        {
            PowerGUI.text = "+" + power;
        }

        switch (colour)
        {
            case 8:
                mr.material.color = new Color(0.8f, 0.2f, 0.8f, 1f); ; 
                break;
            case 7:
                mr.material.color = Color.grey;
                SpawnPlayer2();
                power = 0;
                break;
            case 6:
                mr.material.color = Color.grey;
                SpawnPlayer();
                power = 0;
                break;
            case 5:
                mr.material.color = Color.blue;
                break;
            case 4:
                mr.material.color = Color.yellow;
                break;
            case 3:
                mr.material.color = Color.green;
                break;
            case 2:
                mr.material.color = Color.red;
                break;
            case 1:
                mr.material.color = Color.white;
                break;
            case 0:
                mr.enabled = false;
                break;
        }


    }


    void SpawnPlayer()
    {
        List<PlayerGameMovement> Players = TheGame.instance.playersTeam1;

        if (power < Players.Count )
        {
            PlayerGameMovement player = Instantiate(Players[power], transform.position, transform.rotation).GetComponent<PlayerGameMovement>();
            player.gameObject.layer = 8;
            player.transform.name = "Player"+ transform.name;
            player.SP = this;
            player.GM = GameBord.instance;
            TheGame.instance.ActiveTeam1.Add(player);
            HasPlayer = true;
            PlayerOn = player;
            player.PlayerTeam = 1;
        }
    }
    void SpawnPlayer2()
    {
        List<PlayerGameMovement> Players2 = TheGame.instance.playersTeam2;

        if (power < Players2.Count)
        {
            PlayerGameMovement player = Instantiate(Players2[power], transform.position, transform.rotation).GetComponent<PlayerGameMovement>();
            player.gameObject.layer = 11;
            player.transform.name = "Player" + transform.name;
            player.SP = this;
            player.GM = GameBord.instance;
            TheGame.instance.ActiveTeam2.Add(player);
            HasPlayer = true;
            PlayerOn = player;
            player.PlayerTeam = 2;
        }
    }
}

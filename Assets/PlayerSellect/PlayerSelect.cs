using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelect : MonoBehaviour
{

    public static PlayerSelect instance;

    public List<PlayerGameMovement> Player = new List<PlayerGameMovement>();

    public PlayerGameMovement currentPlayer;

    public Transform playerPoint;

    public AddToTeam SelectButton;

    public PlayerGameMovement currentPlayerTeam2;

    public Transform playerPointTeam2;

    public AddToTeam SelectButtonTeam2;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    public void PickPlayers(int playerNumber)
    {
        if (SelectButton.buttonsActive == SelectButton.CurrentPlayerButtons.Count)
        {
            if (playerPoint.childCount > 0)
            {
                Destroy(playerPoint.GetChild(0).gameObject);
            }

            GameObject PlayerModle = Instantiate(Player[playerNumber], playerPoint.position, playerPoint.rotation, playerPoint).gameObject;
            PlayerModle.transform.localScale = new Vector3(60, 69, 60);

            currentPlayer = Player[playerNumber];
        }
        else
        {

            if (playerPoint.childCount > 0)
            {
                Destroy(playerPoint.GetChild(0).gameObject);
            }

            GameObject PlayerModle = Instantiate(Player[playerNumber], playerPoint.position, playerPoint.rotation, playerPoint).gameObject;
            PlayerModle.transform.localScale = new Vector3(60, 69, 60);

            currentPlayer = Player[playerNumber];

            SelectButton.ChangeSellectedPlayer();


        }
     
    }



    public void PickPlayersTeam2(int playerNumber)
    {
        if (SelectButtonTeam2.buttonsActive == SelectButtonTeam2.CurrentPlayerButtons.Count)
        {
            if (playerPointTeam2.childCount > 0)
            {
                Destroy(playerPointTeam2.GetChild(0).gameObject);
            }

            GameObject PlayerModle = Instantiate(Player[playerNumber], playerPointTeam2.position, playerPointTeam2.rotation, playerPointTeam2).gameObject;
            PlayerModle.transform.localScale = new Vector3(60, 69, 60);

            currentPlayerTeam2 = Player[playerNumber];
        }
        else
        {

            if (playerPointTeam2.childCount > 0)
            {
                Destroy(playerPointTeam2.GetChild(0).gameObject);
            }

            GameObject PlayerModle = Instantiate(Player[playerNumber], playerPointTeam2.position, playerPointTeam2.rotation, playerPointTeam2).gameObject;
            PlayerModle.transform.localScale = new Vector3(60, 69, 60);

            currentPlayerTeam2 = Player[playerNumber];

            SelectButtonTeam2.ChangeSellectedPlayerTeam2();


        }

    }
}

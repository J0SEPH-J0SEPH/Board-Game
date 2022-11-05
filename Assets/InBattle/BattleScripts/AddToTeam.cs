using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToTeam : MonoBehaviour
{

    public List<TeamSelect> CurrentPlayerButtons = new List<TeamSelect>();
    public GameObject CurrenPlayerButton;
    public Transform TeamButton;
    public int buttonsActive;

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void AddPlayerTeam1()
    {
        if (PlayerSelect.instance.currentPlayer != null)
        {
           
            if(CurrentPlayerButtons.Count < 5)
            {
                buttonsActive += 1;

                TheGame.instance.playersTeam1.Add(PlayerSelect.instance.currentPlayer);



                Transform Button = Instantiate(CurrenPlayerButton, TeamButton.position, TeamButton.rotation, TeamButton).transform;
                TeamSelect TS = Button.GetComponent<TeamSelect>();
                TS.Pm = PlayerSelect.instance.currentPlayer;

                TS.UpdateTitle();

                TS.Placement = CurrentPlayerButtons.Count;

                CurrentPlayerButtons.Add(TS);
            }
            else
            {
                TheGame.instance.playersTeam1[4] = PlayerSelect.instance.currentPlayer;
            }
        }

    }

    public void AddPlayerTeam2()
    {
        if (PlayerSelect.instance.currentPlayerTeam2 != null)
        {

            if (CurrentPlayerButtons.Count < 5)
            {

                buttonsActive += 1;

                TheGame.instance.playersTeam2.Add(PlayerSelect.instance.currentPlayerTeam2);

                Transform Button = Instantiate(CurrenPlayerButton, TeamButton.position, TeamButton.rotation, TeamButton).transform;
                TeamSelect TS = Button.GetComponent<TeamSelect>();
                TS.Pm = PlayerSelect.instance.currentPlayerTeam2;


                TS.UpdateTitle2();

                TS.Placement = CurrentPlayerButtons.Count;

                CurrentPlayerButtons.Add(TS);
            }
            else
            {
                TheGame.instance.playersTeam2[4] = PlayerSelect.instance.currentPlayerTeam2;
            }
        }

    }




    public void ChangeSellectedPlayer()
    {
        CurrentPlayerButtons[buttonsActive].Pm = PlayerSelect.instance.currentPlayer;
        TheGame.instance.playersTeam1[buttonsActive] = PlayerSelect.instance.currentPlayer;

        CurrentPlayerButtons[buttonsActive].UpdateTitle();
    }
    public void ChangeSellectedPlayerTeam2()
    {
        CurrentPlayerButtons[buttonsActive].Pm = PlayerSelect.instance.currentPlayerTeam2;
        TheGame.instance.playersTeam2[buttonsActive] = PlayerSelect.instance.currentPlayerTeam2;

        CurrentPlayerButtons[buttonsActive].UpdateTitle2();
    }

}

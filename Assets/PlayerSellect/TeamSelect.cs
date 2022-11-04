using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamSelect : MonoBehaviour
{
    public PlayerGameMovement Pm;
    public int Placement;
    public Text Name;
    // Update is called once per frame
    public void ButtonPreesed()
    {
        if (PlayerSelect.instance.playerPoint.childCount > 0)
        {
            Destroy(PlayerSelect.instance.playerPoint.GetChild(0).gameObject);
        }

        GameObject PlayerModle = Instantiate(Pm, PlayerSelect.instance.playerPoint.position, PlayerSelect.instance.playerPoint.rotation, PlayerSelect.instance.playerPoint).gameObject;
        PlayerModle.transform.localScale = new Vector3(60, 69, 60);

        PlayerSelect.instance.SelectButton.buttonsActive = Placement;
    }

    public void ButtonPreesedTeam2()
    {
        if (PlayerSelect.instance.playerPointTeam2.childCount > 0)
        {
            Destroy(PlayerSelect.instance.playerPointTeam2.GetChild(0).gameObject);
        }

        GameObject PlayerModle = Instantiate(Pm, PlayerSelect.instance.playerPointTeam2.position, PlayerSelect.instance.playerPointTeam2.rotation, PlayerSelect.instance.playerPointTeam2).gameObject;
        PlayerModle.transform.localScale = new Vector3(60, 69, 60);

        PlayerSelect.instance.SelectButtonTeam2.buttonsActive = Placement;
    }

    public void UpdateTitle()
    {
        Name.text = PlayerSelect.instance.currentPlayer.Name;
    }

    public void UpdateTitle2()
    {
        Name.text = PlayerSelect.instance.currentPlayerTeam2.Name;
    }
}

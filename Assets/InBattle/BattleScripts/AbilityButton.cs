using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityButton : MonoBehaviour
{

    // Update is called once per frame
   public void OpenAbilityMenu(){
        TheGame.instance.UIBarHolder.gameObject.SetActive(true);
        TheGame.instance.SetPlayerInfo(TheGame.instance.CurrentSelectedPlayer);
        Destroy(gameObject);
    }

    public void MoveOnMenu(){
        TheGame.instance.CurrentSelectedPlayer.FindmoveableSpace(0);
        Destroy(gameObject);
    }
}

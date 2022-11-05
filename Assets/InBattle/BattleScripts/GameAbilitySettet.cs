using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAbilitySettet : MonoBehaviour
{

    public Abilities AbilityInfo;
    public TheGame GM;
    public int AmountofMoves;

    public void CheckAbillityToUse(Abilities AbilityInfo,Transform spaceSelected)
    {
        switch (AbilityInfo.MoveType)
        {
            case Abilities.Abilitys.move:
                if (AbilityInfo.SubMoveType == Abilities.Move.TakeMultipalMoves)
                {
                    //Unfinished
                }
                if (AbilityInfo.SubMoveType == Abilities.Move.JumpToSpace)
                {
                    BoardSpaces SelectedSpace = spaceSelected.transform.GetComponent<ClickToMove>().Space;
                    GM.CurrentSelectedPlayer.transform.position = spaceSelected.transform.position;
                    GM.CurrentSelectedPlayer.SP.HasPlayer = false;
                    GM.CurrentSelectedPlayer.SP.PlayerOn = null;
                    GM.CurrentSelectedPlayer.SP = SelectedSpace;
                    SelectedSpace.HasPlayer = true;
                    SelectedSpace.PlayerOn = GM.CurrentSelectedPlayer;
                    SelectedSpace.HasPlayer = true;

                    if (SelectedSpace.colour == 8)
                    {
                        GM.CurrentSelectedPlayer.Health -= (SelectedSpace.power + 1);
                    }
                }
                break;
            case Abilities.Abilitys.Melee:
                if (AbilityInfo.SubAttackType == Abilities.Melee.AttackRound){
                    BoardSpaces SelectedSpace = spaceSelected.transform.GetComponent<ClickToMove>().Space;

                    if (SelectedSpace.HasPlayer){
                        SelectedSpace.PlayerOn.Health -= AbilityInfo.Damage;

                        if (SelectedSpace.PlayerOn.Health <= 0)
                        {
                            PlayerGameMovement PG = SelectedSpace.PlayerOn;

                            if (SelectedSpace.PlayerOn.PlayerTeam == 1) {
                                SelectedSpace.HasPlayer = false;
                                GM.ActiveTeam1.Remove(PG);
                            }
                            else{
                                SelectedSpace.HasPlayer = false;
                                GM.ActiveTeam2.Remove(PG);
                                SelectedSpace.PlayerOn = null;
                            }
                            Destroy(PG.gameObject);
                        }
                    }
                }

                if (AbilityInfo.SubAttackType == Abilities.Melee.AttackwithSpacePower)
                {
                    BoardSpaces SelectedSpace = spaceSelected.transform.GetComponent<ClickToMove>().Space;

                    if (SelectedSpace.HasPlayer){
                        SelectedSpace.PlayerOn.Health -= (AbilityInfo.Damage + SelectedSpace.power);

                        if (SelectedSpace.PlayerOn.Health <= 0){
                            PlayerGameMovement PG = SelectedSpace.PlayerOn;

                            if (SelectedSpace.PlayerOn.PlayerTeam == 1){
                                SelectedSpace.HasPlayer = false;
                                GM.ActiveTeam1.Remove(PG);
                            }
                            else{
                                SelectedSpace.HasPlayer = false;
                                GM.ActiveTeam2.Remove(PG);
                                SelectedSpace.PlayerOn = null;
                            }
                            ///////Possibly bad Optimization
                            Destroy(PG.gameObject);
                        }
                    }
                }
                break;

            case Abilities.Abilitys.Placement:
                if (AbilityInfo.SubPlacementType == Abilities.Place.Bomb){
                    //Incomplete
                }

                if (AbilityInfo.SubPlacementType == Abilities.Place.SpaceUpgrade){
                    BoardSpaces SelectedSpace = spaceSelected.transform.GetComponent<ClickToMove>().Space;
                    SelectedSpace.power += AbilityInfo.movePower;
                    SelectedSpace.UpdateSpace();
                }

                if (AbilityInfo.SubPlacementType == Abilities.Place.Poison){
                    BoardSpaces SelectedSpace = spaceSelected.transform.GetComponent<ClickToMove>().Space;
                    SelectedSpace.colour = 8;
                    SelectedSpace.UpdateSpace();
                    if (SelectedSpace.HasPlayer){
                        SelectedSpace.PlayerOn.Health -= (SelectedSpace.power +1);
                        if (SelectedSpace.PlayerOn.Health <= 0){
                            PlayerGameMovement PG = SelectedSpace.PlayerOn;

                            if (SelectedSpace.PlayerOn.PlayerTeam == 1){
                                SelectedSpace.HasPlayer = false;
                                GM.ActiveTeam1.Remove(PG);
                            }
                            else{
                                SelectedSpace.HasPlayer = false;
                                GM.ActiveTeam2.Remove(PG);
                                SelectedSpace.PlayerOn = null;
                            }
                            Destroy(PG.gameObject);
                        }
                    }
                }
                break;
        }
        TheGame.instance.ClearMoveSpaces();
        TheGame.instance.Moves -= 1;
    }
}

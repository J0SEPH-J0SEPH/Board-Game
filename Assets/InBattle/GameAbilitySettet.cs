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
                   

                }
                if (AbilityInfo.SubMoveType == Abilities.Move.JumpToSpace)
                {
                    Spaces SelectedSpace = spaceSelected.transform.GetComponent<ClickToMove>().Space;
                    GM.CurrentSelectedPlayer.transform.position = spaceSelected.transform.position;
                    GM.CurrentSelectedPlayer.SP.HasPlayer = false;
                    GM.CurrentSelectedPlayer.SP.pLayerOn = null;
                    GM.CurrentSelectedPlayer.SP = SelectedSpace;
                    SelectedSpace.HasPlayer = true;
                    SelectedSpace.pLayerOn = GM.CurrentSelectedPlayer;

                    SelectedSpace.HasPlayer = true;

                    if (SelectedSpace.colour == 8)
                    {
                        GM.CurrentSelectedPlayer.Health -= (SelectedSpace.power + 1);
                    }


                }
                break;
            case Abilities.Abilitys.Melee:
                if (AbilityInfo.SubAttackType == Abilities.Melee.AttackRound)
                {
                    Spaces SelectedSpace = spaceSelected.transform.GetComponent<ClickToMove>().Space;


                    if (SelectedSpace.HasPlayer)
                    {
                        SelectedSpace.pLayerOn.Health -= AbilityInfo.Damage;

                        if (SelectedSpace.pLayerOn.Health <= 0)
                        {
                            PlayerGameMovement PG = SelectedSpace.pLayerOn;


                            if (SelectedSpace.pLayerOn.PlayerTeam == 1) {
                                SelectedSpace.HasPlayer = false;

                                GM.ActiveTeam1.Remove(PG);
                               
                            }
                            else
                            {
                                SelectedSpace.HasPlayer = false;
                                GM.ActiveTeam2.Remove(PG);
                                SelectedSpace.pLayerOn = null;

                            }


                            Destroy(PG.gameObject);

                        }
                    }
                }

                if (AbilityInfo.SubAttackType == Abilities.Melee.AttackwithSpacePower)
                {
                    Spaces SelectedSpace = spaceSelected.transform.GetComponent<ClickToMove>().Space;


                    if (SelectedSpace.HasPlayer)
                    {
                        SelectedSpace.pLayerOn.Health -= (AbilityInfo.Damage + SelectedSpace.power);

                        if (SelectedSpace.pLayerOn.Health <= 0)
                        {
                            PlayerGameMovement PG = SelectedSpace.pLayerOn;


                            if (SelectedSpace.pLayerOn.PlayerTeam == 1)
                            {
                                SelectedSpace.HasPlayer = false;

                                GM.ActiveTeam1.Remove(PG);

                            }
                            else
                            {
                                SelectedSpace.HasPlayer = false;
                                GM.ActiveTeam2.Remove(PG);
                                SelectedSpace.pLayerOn = null;

                            }


                            Destroy(PG.gameObject);

                        }
                    }
                }
                break;

            case Abilities.Abilitys.Placement:
                if (AbilityInfo.SubPlacementType == Abilities.Place.Bomb)
                {

                }

                if (AbilityInfo.SubPlacementType == Abilities.Place.SpaceUpgrade)
                {
                    Spaces SelectedSpace = spaceSelected.transform.GetComponent<ClickToMove>().Space;
                    SelectedSpace.power += AbilityInfo.movePower;
                    SelectedSpace.UpdateSpace();
                }

                if (AbilityInfo.SubPlacementType == Abilities.Place.Poison)
                {
                    Spaces SelectedSpace = spaceSelected.transform.GetComponent<ClickToMove>().Space;

                    SelectedSpace.colour = 8;
                    SelectedSpace.UpdateSpace();

                    if (SelectedSpace.HasPlayer)
                    {
                        SelectedSpace.pLayerOn.Health -= (SelectedSpace.power +1);

                        if (SelectedSpace.pLayerOn.Health <= 0)
                        {
                            PlayerGameMovement PG = SelectedSpace.pLayerOn;


                            if (SelectedSpace.pLayerOn.PlayerTeam == 1)
                            {
                                SelectedSpace.HasPlayer = false;

                                GM.ActiveTeam1.Remove(PG);

                            }
                            else
                            {
                                SelectedSpace.HasPlayer = false;
                                GM.ActiveTeam2.Remove(PG);
                                SelectedSpace.pLayerOn = null;

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

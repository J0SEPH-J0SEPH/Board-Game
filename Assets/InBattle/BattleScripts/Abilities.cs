using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ability - 1", menuName = "Abilitys/Moves", order = 1)]
public class Abilities : ScriptableObject
{


    public enum Abilitys{
        Melee,
        Placement,
        Effect,
        Heal,
        move
    };


    public enum Melee{
        AttackRound,
        AttackDiagnals,
        AttackwithSpacePower
    };



    public enum Move{
        TakeMultipalMoves,
        JumpToSpace
    };

    public enum Place{
        Poison,
        Bomb,
        Tower,
        SpaceUpgrade
    };


    public enum AttackAria{
        Around,
        Out2,
        Out3,
        Self,
        AroundAnd2Out,
        AroundAnd2OutAnd3Out,
        Diagonal,
        Horizontal
    };


    [System.Serializable]
    public class Magic{
        public int Red;
        public int Blue;
        public int Green;
        public int Yellow;
        public int Dark;
        public int Light;
     }



    [Header("Ability Info")]
    public string AbilityName;
    public Abilitys MoveType;
    public Melee SubAttackType;
    public Move SubMoveType;
    public Place SubPlacementType;
    [Header("Ability Effect Aria")]
    public AttackAria AriaOfEffect;
    public bool EnimeAttack;

    [Header("Ability Cost")]
    public Magic Magicneeded;
    // Start is called before the first frame update

    [Header("movemultipalSpacesPower")]
    public int movePower = 2;

    [Header("AbilityPower")]
    public int Damage = 5;

    public GameObject Placement;
}

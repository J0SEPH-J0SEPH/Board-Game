using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;

public class AbilityPanel : MonoBehaviour
{
    public Button button;


    public TextMeshProUGUI TitleName;

    public int AbilityType = 0;

    public Abilities AbilityInfo;

    public List<int> spacesTomove = new List<int>();

    // Start is called before the first frame update
    public void SetAbility()
    {
        TitleName.text = AbilityInfo.AbilityName;
        button.onClick.AddListener(CustomButton_onClick);
        
    }

    public void Awake() {



    }

    void CustomButton_onClick()
    {

        FindSpacesOfEffect();
        TheGame.instance.Ability = AbilityInfo;
        TheGame.instance.UIBarHolder.gameObject.SetActive(false);

    }


    public void MoveNumberOfSpaces(int SpacesToMove)
    {
        TheGame.instance.CurrentSelectedPlayer.FindmoveableSpace(SpacesToMove);
        TheGame.instance.UIBarHolder.gameObject.SetActive(false);
    }

    public void FindSpacesOfEffect() {

       

        switch (AbilityInfo.AriaOfEffect)
        {
            case Abilities.AttackAria.Around:
                spacesTomove.Clear();
                FindAgaisentPoints();
                break;
            case Abilities.AttackAria.Out2:
                spacesTomove.Clear();
                FindOut2Points();
                break;

            case Abilities.AttackAria.Out3:
                spacesTomove.Clear();
                FindOut3Points();
                break;
            case Abilities.AttackAria.Self:
                spacesTomove.Clear();
                SelfSpace();
                break;

        }


    }

    public void SelfSpace()
    {
        string[] splitString = TheGame.instance.CurrentSelectedPlayer.SP.name.Split('-');
        int count = int.Parse(splitString[1]) + int.Parse(splitString[0]) * GameBord.instance.height;
        spacesTomove.Add(count);
       TheGame.instance.CurrentSelectedPlayer.CheckifCanmove(spacesTomove, true, false);
    }

    public void FindAgaisentPoints()
    {

        

       
        GameBord GM = GameBord.instance;

        string[] splitString = TheGame.instance.CurrentSelectedPlayer.SP.name.Split('-');

        int count = int.Parse(splitString[1]) + int.Parse(splitString[0]) * GM.height;



        if (int.Parse(splitString[1]) % 2 == 0)
        {

            spacesTomove.Add(int.Parse(splitString[1]) + int.Parse(splitString[0]) * GM.height + GM.height);

            int RightValue = int.Parse(splitString[1]) + int.Parse(splitString[0]) * GM.height - GM.height;

            spacesTomove.Add(RightValue);


            if (int.Parse(splitString[1]) < GM.height - 1)
            {
                spacesTomove.Add(count + 1);

                spacesTomove.Add(RightValue + 1);
            }

            if (int.Parse(splitString[1]) != 0)
            {
                spacesTomove.Add(count - 1);

                spacesTomove.Add(RightValue - 1);

            }




        }
        else
        {
            spacesTomove.Add(int.Parse(splitString[1]) + int.Parse(splitString[0]) * GM.height - GM.height);

            int RightValue = int.Parse(splitString[1]) + int.Parse(splitString[0]) * GM.height + GM.height;

            spacesTomove.Add(RightValue);

            if (int.Parse(splitString[1]) < GM.height - 1)
            {
                spacesTomove.Add(count + 1);



                spacesTomove.Add(RightValue + 1);
            }
            if (int.Parse(splitString[1]) != 0)
            {
                spacesTomove.Add(count - 1);
                spacesTomove.Add(RightValue - 1);
            }
        }

        TheGame.instance.CurrentSelectedPlayer.CheckifCanmove(spacesTomove,true ,!AbilityInfo.EnimeAttack);

    }




    public void FindOut2Points()
    {
        PlayerGameMovement player = TheGame.instance.CurrentSelectedPlayer;

        

        string[] splitString = player.SP.name.Split('-');

        int count = int.Parse(splitString[1]) + int.Parse(splitString[0]) * player.GM.height;



        if (int.Parse(splitString[1]) % 2 == 0)
        {
            calculatespacestojumptoo1(count, splitString);
        }
        else
        {
            calculatespacestojumptoo2(count, splitString);
        }
    }

    void calculatespacestojumptoo1(int count, string[] splitString)
    {
        GameBord GM = GameBord.instance;

       

        spacesTomove.Add(int.Parse(splitString[1]) + int.Parse(splitString[0]) * GM.height + GM.height*2);

        int smallLeft = (int.Parse(splitString[1]) + int.Parse(splitString[0]) * GM.height + GM.height);

        int BigRightValue = int.Parse(splitString[1]) + int.Parse(splitString[0]) * GM.height - GM.height*2;

        int RightValue = int.Parse(splitString[1]) + int.Parse(splitString[0]) * GM.height - GM.height;

        int LeftValue = int.Parse(splitString[1]) + int.Parse(splitString[0]) * GM.height + GM.height;

        spacesTomove.Add(BigRightValue);


        if (int.Parse(splitString[1]) < GM.height - 2)
        {
            spacesTomove.Add(count + 2);

            spacesTomove.Add(RightValue + 2);

            spacesTomove.Add(LeftValue + 2);
        }

        if (int.Parse(splitString[1]) >= 2)
        {
            spacesTomove.Add(count - 2);

            spacesTomove.Add(RightValue - 2);

            spacesTomove.Add(LeftValue - 2);

            
        }

        if (int.Parse(splitString[1]) < GM.height - 1)
        {
            spacesTomove.Add(BigRightValue + 1);

            spacesTomove.Add(LeftValue + 1);
        }
        if (int.Parse(splitString[1]) >= 1)
        {
            spacesTomove.Add(BigRightValue - 1);

            spacesTomove.Add(LeftValue - 1);

        }
        TheGame.instance.CurrentSelectedPlayer.CheckifCanmove(spacesTomove, true, !AbilityInfo.EnimeAttack);
    }

    void calculatespacestojumptoo2(int count, string[] splitString)
    {
        GameBord GM = GameBord.instance;

      


        spacesTomove.Add(int.Parse(splitString[1]) + int.Parse(splitString[0]) * GM.height - GM.height*2);

        int RightValue = int.Parse(splitString[1]) + int.Parse(splitString[0]) * GM.height + GM.height*2;

        int LeftValue = int.Parse(splitString[1]) + int.Parse(splitString[0]) * GM.height - GM.height;

        spacesTomove.Add(RightValue);

        if (int.Parse(splitString[1]) < GM.height - 2)
        {
            spacesTomove.Add(count + 2);

            spacesTomove.Add(count + 2 + GM.height);

            spacesTomove.Add(count + 2 - GM.height);

            
        }
        if (int.Parse(splitString[1]) >= 2)
        {
            spacesTomove.Add(count - 2);

            spacesTomove.Add(count - 2 + GM.height);

            spacesTomove.Add(count - 2 - GM.height);
        }

        if (int.Parse(splitString[1]) < GM.height - 1)
        {
            spacesTomove.Add(RightValue + 1);

            spacesTomove.Add(LeftValue + 1);
        }
        if (int.Parse(splitString[1]) >= 1)
        {
            spacesTomove.Add(RightValue - 1);

            spacesTomove.Add(LeftValue - 1);

        }


        TheGame.instance.CurrentSelectedPlayer.CheckifCanmove(spacesTomove, true, !AbilityInfo.EnimeAttack);
    }




    public void FindOut3Points()
    {
        PlayerGameMovement player = TheGame.instance.CurrentSelectedPlayer;



        string[] splitString = player.SP.name.Split('-');

        int count = int.Parse(splitString[1]) + int.Parse(splitString[0]) * player.GM.height;



        if (int.Parse(splitString[1]) % 2 == 0)
        {
            calculatespacestojumpthree1(count, splitString);
        }
        else
        {
            calculatespacestojumpthree2(count, splitString);
        }
    }

    void calculatespacestojumpthree1(int count, string[] splitString)
    {
        GameBord GM = GameBord.instance;



        spacesTomove.Add(int.Parse(splitString[1]) + int.Parse(splitString[0]) * GM.height + GM.height * 3);

        int smallLeft = (int.Parse(splitString[1]) + int.Parse(splitString[0]) * GM.height + GM.height);

        int BigRightValue = int.Parse(splitString[1]) + int.Parse(splitString[0]) * GM.height - GM.height * 3;

        int RightValue = int.Parse(splitString[1]) + int.Parse(splitString[0]) * GM.height - GM.height;

        int LeftValue = int.Parse(splitString[1]) + int.Parse(splitString[0]) * GM.height + GM.height;

        spacesTomove.Add(BigRightValue);


        if (int.Parse(splitString[1]) < GM.height - 2)
        {
            spacesTomove.Add(count + 3);

            spacesTomove.Add(RightValue + 3);

            spacesTomove.Add(LeftValue + 3);
        }

        if (int.Parse(splitString[1]) >= 3)
        {
            spacesTomove.Add(count - 3);

            spacesTomove.Add(RightValue - 3);

            spacesTomove.Add(LeftValue - 3);


        }

        if (int.Parse(splitString[1]) < GM.height - 2)
        {
            spacesTomove.Add(BigRightValue + 2);

            spacesTomove.Add(LeftValue + 2);
        }
        if (int.Parse(splitString[1]) >= 2)
        {
            spacesTomove.Add(BigRightValue - 2);

            spacesTomove.Add(LeftValue - 2);

        }
        TheGame.instance.CurrentSelectedPlayer.CheckifCanmove(spacesTomove, true, !AbilityInfo.EnimeAttack);
    }


    void calculatespacestojumpthree2(int count, string[] splitString)
    {
        GameBord GM = GameBord.instance;




        spacesTomove.Add(int.Parse(splitString[1]) + int.Parse(splitString[0]) * GM.height - GM.height * 3);

        

       




        int RightValue = int.Parse(splitString[1]) + int.Parse(splitString[0]) * GM.height + GM.height * 3;


        int LeftValue = int.Parse(splitString[1]) + int.Parse(splitString[0]) * GM.height - GM.height;

        spacesTomove.Add(RightValue);

        if (int.Parse(splitString[1]) < GM.height - 3)
        {
            spacesTomove.Add(count + 3);

            spacesTomove.Add(count + 3 + GM.height);

            spacesTomove.Add(count + 3 - GM.height);

            spacesTomove.Add(count + 3 + GM.height*2);
        }
        if (int.Parse(splitString[1]) >= 3)
        {
            spacesTomove.Add(count - 3);

            spacesTomove.Add(count - 3 + GM.height);

            spacesTomove.Add(count - 3 - GM.height);

            spacesTomove.Add(count - 3 + GM.height*2);
        }

        if (int.Parse(splitString[1]) < GM.height - 1)
        {
            spacesTomove.Add(RightValue + 1);

            spacesTomove.Add(int.Parse(splitString[1]) + int.Parse(splitString[0]) * GM.height - GM.height * 2 + 1);
        }
        if (int.Parse(splitString[1]) >= 1)
        {
            spacesTomove.Add(RightValue - 1);

            spacesTomove.Add(int.Parse(splitString[1]) + int.Parse(splitString[0]) * GM.height - GM.height * 2 - 1);

        }


        if (int.Parse(splitString[1]) < GM.height - 2)
        {
            spacesTomove.Add(RightValue - GM.height + 2);

            spacesTomove.Add(int.Parse(splitString[1]) + int.Parse(splitString[0]) * GM.height - GM.height * 2 + 2);
        }
        if (int.Parse(splitString[1]) >= 2)
        {
            spacesTomove.Add(RightValue - GM.height - 2);

            spacesTomove.Add(int.Parse(splitString[1]) + int.Parse(splitString[0]) * GM.height - GM.height * 2 - 2);

        }




        TheGame.instance.CurrentSelectedPlayer.CheckifCanmove(spacesTomove, true, !AbilityInfo.EnimeAttack);
    }






}

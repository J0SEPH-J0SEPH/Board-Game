using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameMovement : MonoBehaviour
{
    public string Name = "Monster";
    public GameBord GM;
    public Spaces SP;

    public float Health = 10;

    public List<Abilities> PlayerAbilitys;

    public int PlayerTeam = 0;

    public bool ToxicImunity = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      

        if (Input.GetKeyDown("k"))
        {
            FindmoveableSpace(0);
            Debug.Log("D done");
        }
    }

  
    public void FindmoveableSpace(int partOfAbility)
    {

        List<int> spacesTomove = new List<int>();

        string[] splitString = SP.name.Split('-');

        int count = int.Parse(splitString[1]) + int.Parse(splitString[0])*GM.height;

        

        if(int.Parse(splitString[1]) % 2 == 0)
        {

            spacesTomove.Add(int.Parse(splitString[1]) + int.Parse(splitString[0]) * GM.height + GM.height);

            int RightValue = int.Parse(splitString[1]) + int.Parse(splitString[0]) * GM.height - GM.height;

            spacesTomove.Add(RightValue);


            if (int.Parse(splitString[1]) < GM.height-1)
            {
                spacesTomove.Add(count + 1);

                spacesTomove.Add(RightValue + 1);
            }

            if(int.Parse(splitString[1]) != 0)
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

            if (int.Parse(splitString[1]) < GM.height-1)
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

        
        CheckifCanmove(spacesTomove,false,true);
    }

   public void CheckifCanmove(List <int> PositionsToMove,bool partOfAbility, bool NoPlayerSpcaes)
    {
        foreach(int Point in PositionsToMove)
        {

            if (Point >= 0 && Point < GM.spaces.Count)
            {

                if (GM.spaces[Point].colour > 0)
                {
                    if (NoPlayerSpcaes)
                    {
                        if (!GM.spaces[Point].HasPlayer)
                        {
                            ClickToMove SpaceTomove = Instantiate(GM.MoveToPoint, GM.spaces[Point].transform.position, GM.transform.rotation, GM.PointsTomoveToHolder);
                            SpaceTomove.Space = GM.spaces[Point];
                            TheGame.instance.MoveToSpaces.Add(SpaceTomove);
                            TheGame.instance.UsingAbility = partOfAbility;
                            
                        }

                    }
                    else
                    {
                        

                        ClickToMove SpaceTomove = Instantiate(GM.MoveToPoint, GM.spaces[Point].transform.position, GM.transform.rotation, GM.PointsTomoveToHolder);
                        SpaceTomove.Space = GM.spaces[Point];
                        TheGame.instance.MoveToSpaces.Add(SpaceTomove);
                        TheGame.instance.UsingAbility = partOfAbility;
                    }

                    
                   
                }
            }

        }

       
    }

    


  


}

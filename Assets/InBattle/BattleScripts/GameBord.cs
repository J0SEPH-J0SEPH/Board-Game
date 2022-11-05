using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBord : MonoBehaviour
{

    public static GameBord instance;
    public List<BoardSpaces> spaces = new List<BoardSpaces>();
    public GameObject spaceTile;
    public int width;
    public int height;
    public Gamebordfiles GFile;
    public Transform PointsTomoveToHolder;
    public ClickToMove MoveToPoint;

    // Start is called before the first frame update
    void Start(){
        instance = this;
    }

   public void CreatBord(){
        width = GFile.width;
        height = GFile.height;
        for (int i = 0; i < width; i++){
            for (int j = 0; j < height; j++)
            {
                BoardSpaces currentSpace;

                if (j % 2 == 0){
                    currentSpace = Instantiate(spaceTile, transform.position + Vector3.left * j + Vector3.forward * i , transform.rotation, transform).GetComponent<BoardSpaces>(); 
                }
                else{
                    currentSpace = Instantiate(spaceTile, transform.position + Vector3.left * j  + Vector3.forward * (i+0.5f) , transform.rotation, transform).GetComponent<BoardSpaces>();
                }
                currentSpace.colour = GFile.TileColourList[i * (height) + j];
                currentSpace.power = GFile.TilePowerList[i * (height) + j];
                currentSpace.name = i + "-" + j;
                spaces.Add(currentSpace);

                if (i == 1 && j == 3)
                {
                    string[] splitString = currentSpace.name.Split('-');
                    Debug.Log(splitString[1]);
                }
            }
        }
        TheGame.instance.Moves = 1;
        TheGame.instance.state = BattleState.PLAYER1TURN;
    }
}

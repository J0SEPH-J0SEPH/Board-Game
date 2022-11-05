using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class GameBordMaker : EditorWindow
{

    public string bordname;

    public int colour;

    public int width = 5;

    public int height = 5;

    public int Power;

    public Texture Hexagon;
   
    public GUISkin gs;

    public List<int> TileColourList;

    public List<int> TilePowerList;

    public GameBord gm;

    [MenuItem("Window/Bord Maker")]

    public static void ShowWindow()
    {
        GetWindow<GameBordMaker>("Bord Maker");
    }

    // Start is called before the first frame update
    void OnGUI()
    {

        //Window Code
        GUILayout.Label("Level Maker", EditorStyles.boldLabel);

        GUILayout.BeginHorizontal("box");

        GUILayout.Label("Title: ");
        bordname = GUILayout.TextArea(bordname);

        GUILayout.EndHorizontal();

       

        GUILayout.BeginHorizontal("box");

        GUILayout.Label("Width: ");
        width = EditorGUILayout.IntField(width);
        GUILayout.Label("Height: ");
        height = EditorGUILayout.IntField(height);

        if (GUILayout.Button("    SetSize    "))
        {
            List<int> ListAdder = new List<int>();
            List<int> ListAddertwo = new List<int>();

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    ListAdder.Add(0);
                    ListAddertwo.Add(0);
                }
            }
            TilePowerList = ListAddertwo;

            TileColourList = ListAdder;
        }


        GUILayout.EndHorizontal();

      

        

        GUILayout.BeginHorizontal("box");
     
        GUILayout.Label("Power: ");
        Power = EditorGUILayout.IntField(Power);
        GUILayout.EndHorizontal();


        GUILayout.BeginHorizontal("box");

        GUI.color = Color.white;

        if (GUILayout.Button("Null"))
        {
            
            colour = 0;

        }



        GUI.color = Color.white;

        if (GUILayout.Button("White"))
        {
         
            colour = 1;

        }

        GUI.color = Color.red;

        if (GUILayout.Button("Red"))
        {
          
            colour = 2;

        }

        GUI.color = Color.green;

        if (GUILayout.Button("Green"))
        {
         
            colour = 3;

        }

        GUI.color = Color.yellow;

        if (GUILayout.Button("Yellow"))
        {
         
            colour = 4;

        }

        GUI.color = Color.blue;

        if (GUILayout.Button("Blue"))
        {
           
            colour = 5;

        }

        GUI.color = Color.grey;

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal("box");

        if (GUILayout.Button("SpawnPoint"))
        {
          
            colour = 6;

        }
        GUI.color = Color.grey;

        if (GUILayout.Button("SpawnPoint2"))
        {

            colour = 7;

        }
        GUI.color = Color.white;

        GUILayout.EndHorizontal();



        if (GUILayout.Button("Generate"))
        {
            Create(bordname,width,height,TileColourList, TilePowerList);
        }


        

        GUI.skin = gs;


        if (TileColourList.Count == width * height)
        {

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    int PowerValue = TilePowerList[i * (height) + j];
                    string PowerValueString = "" + PowerValue;


                    switch (TileColourList[i * (height) + j])
                    {
                        case 7:
                            GUI.color = new Color(0.2f, 0.2f, 0.2f, 1f);
                            break;
                        case 6:
                            GUI.color = Color.grey;
                            break;
                        case 5:
                            GUI.color = Color.blue;
                            break;
                        case 4:
                            GUI.color = Color.yellow;
                            break;
                        case 3:
                            GUI.color = Color.green;
                            break;
                        case 2:
                            GUI.color = Color.red;
                            break;
                        case 1:
                            GUI.color = Color.white;
                            break;
                        case 0:
                            GUI.color = new Color(1f, 1f, 1f, 0.3f);
                            break;
                    }

                    
                  
                    //GUI.Box(new Rect(i * 50, j * 50, Screen.width * 0.1f, Screen.height * 0.1f));
                    if (j % 2 == 0)
                    {

                        

                        if (GUI.Button(new Rect(i * 50+5, j * 50+200, Screen.width * 0.1f, Screen.width * 0.1f), PowerValueString))
                        {

                            TilePowerList[i * (height) + j] = Power;

                            if (TileColourList[i * (height) + j] != colour)
                            {
                                TileColourList[i * (height) + j] = colour;
                            }
                            else {
                                TileColourList[i * (height) + j] = 0;
                            }
                        }
                        
                        

                    }
                    else
                    {
                      


                        if (GUI.Button(new Rect(i * 50 + 30, j * 50+200, Screen.width * 0.1f, Screen.width * 0.1f), PowerValueString))
                        {
                            TilePowerList[i * (height) + j] = Power;

                            if (TileColourList[i * (height) + j] != colour)
                            {
                                TileColourList[i * (height) + j] = colour;
                            }
                            else {
                                TileColourList[i * (height) + j] = 0;
                            }
                        }

                    }

                }

            }

        }

    }

 
    [MenuItem("Assets/InBattle/gamebord/levels/level")]
    public static Gamebordfiles Create(string name,int width,int height, List<int> tileColourList, List<int> tilePowerList)
    {
        Gamebordfiles asset = ScriptableObject.CreateInstance<Gamebordfiles>();

        asset.width = width;
        asset.height = height;
        asset.TileColourList = tileColourList;
        asset.TilePowerList = tilePowerList;
        asset.bordName = name;

        AssetDatabase.CreateAsset(asset, "Assets/InBattle/gamebord/levels/"+name+".asset");
        AssetDatabase.SaveAssets();
        return asset;
    }


}

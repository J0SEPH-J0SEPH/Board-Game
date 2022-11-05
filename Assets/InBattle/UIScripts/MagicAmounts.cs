using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MagicAmounts : MonoBehaviour
{
    public static MagicAmounts instance;

    [Header("Team 1 Mama")]
    public int Team1RedMana;
    public int Team1YellowMana;
    public int Team1GreenMana;
    public int Team1BlueMana;

    [Header("Team 2 Mama")]
    public int Team2RedMana;
    public int Team2YellowMana;
    public int Team2GreenMana;
    public int Team2BlueMana;

    [Header("UI")]

    public Text RedMana;
    public Text YellowMana;
    public Text GreenMana;
    public Text BlueMana;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
   public void UpdateUIPlayer1()
    {
        RedMana.text = "Red: " + Team1RedMana;
        YellowMana.text = "Yellow: " + Team1YellowMana;
        GreenMana.text = "Green: " + Team1GreenMana;
        BlueMana.text = "Blue: " + Team1BlueMana;
    }

    public void UpdateUIPlayer2()
    {
        RedMana.text = "Red: " + Team2RedMana;
        YellowMana.text = "Yellow: " + Team2YellowMana;
        GreenMana.text = "Green: " + Team2GreenMana;
        BlueMana.text = "Blue: " + Team2BlueMana;
    }
}

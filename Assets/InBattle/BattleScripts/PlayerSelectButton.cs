using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelectButton : MonoBehaviour
{

    public Text Name;
    public int PlayerNumber;
    public PlayerGameMovement Pm;
    // Start is called before the first frame update
    void Start()
    {
        Pm = PlayerSelect.instance.Player[PlayerNumber];
        Name.text = Pm.Name;
    }

    // Update is called once per frame
   
}

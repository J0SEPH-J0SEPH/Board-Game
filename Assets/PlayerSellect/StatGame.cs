using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatGame : MonoBehaviour
{
    public Transform CharacterSelectUI;
    public Transform CharacterSelectIconUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void StartGame()
    {
        CharacterSelectUI.gameObject.SetActive(false);
        CharacterSelectIconUI.gameObject.SetActive(false);

        TheGame.instance.SetUpBattle();

    }
}

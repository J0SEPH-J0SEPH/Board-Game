using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START, FIRSTTURN, PLAYER1TURN, PLAYER1COLLECTPOINTS, PLAYER2TURN, PLAYER2COLLECTPOINTS,PLAYER1PLACEMENTS,PLAYER2PLACEMENTS, WON, LOST }

public class TheGame : MonoBehaviour
{
    public static TheGame instance;
    [Header("Game State")]
    public BattleState state;
    public int Moves = 1;

    [Header("Game Info")]
    public GameBord gameBord;
    public GameAbilitySettet AbilitySet;
    public List<PlayerGameMovement> playersTeam1 = new List<PlayerGameMovement>();
    public List<PlayerGameMovement> playersTeam2 = new List<PlayerGameMovement>();
    public List<PlayerGameMovement> ActiveTeam1 = new List<PlayerGameMovement>();
    public List<PlayerGameMovement> ActiveTeam2 = new List<PlayerGameMovement>();

    public LayerMask PlayerLayerTeam1;
    public LayerMask PlayerLayerTeam2;
    public List<ClickToMove> MoveToSpaces;
    public PlayerGameMovement CurrentSelectedPlayer;

    [Header("Camera")]
    public Cam GameCamera;

    [Header("UI Info")]
    public MagicAmounts ManaUI;
    public GameObject AbilityUIBar;
    public Transform UIBarHolder;
    public Transform UIPlayerActionHolder;
    public GameObject PlayerActions;
    public ClickToAttack Attackpoint;

    [Header("Ability Info")]
    public bool UsingAbility = false;
    public Abilities Ability;

   // [Header("Bord Info")]
   // public List<Spaces> DamageDealers = new List<Spaces>()
    // Start is called before the first frame update
    void Awake(){
        instance = this;
    }

    public void SetUpBattle(){
        state = BattleState.FIRSTTURN;
        ManaUI.gameObject.SetActive(true);
        gameBord.CreatBord();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == BattleState.PLAYER1TURN)
        {
            if (Moves <= 0){
                state = BattleState.PLAYER1COLLECTPOINTS;
            }
            else{
                CheckForPlayerSelect();
            }
        }


        if (state == BattleState.PLAYER2TURN)
        {
            if (Moves <= 0) { 
                state = BattleState.PLAYER2COLLECTPOINTS;
            }
            else{
                CheckForPlayerSelectTeam2();
            }
        }
        //////////////////////////////////////////
        if (state == BattleState.PLAYER1PLACEMENTS){
            Player1CollectPoints();
        }

        if (state == BattleState.PLAYER2PLACEMENTS){
            Player2CollectPoints();
        }
        ///////////////////////////////////////
        if (state == BattleState.PLAYER1COLLECTPOINTS){
            Player1CollectPoints();
        }

        if (state == BattleState.PLAYER2COLLECTPOINTS){
            Player2CollectPoints();
        }
    }

    void Player1CollectPoints()
    {
        foreach(PlayerGameMovement Player in ActiveTeam1)
        {
            switch (Player.SP.colour){
                case 8:
                    if (!Player.ToxicImunity){
                        Player.Health -= (Player.SP.power + 1);
                    }
                    break;
                case 7:        
                    break;
                case 6: 
                    break;
                case 5:
                    ManaUI.Team1BlueMana += Player.SP.power + 1;
                    break;
                case 4:
                    ManaUI.Team1YellowMana += Player.SP.power + 1;
                    break;
                case 3:
                    ManaUI.Team1GreenMana += Player.SP.power + 1;
                    break;
                case 2:
                    ManaUI.Team1RedMana += Player.SP.power + 1;
                    break;
                case 1:
                    break;
                case 0:
                    break;
            }
            ManaUI.UpdateUIPlayer1();
        }
        StartPlayer2sTurn();
        ManaUI.UpdateUIPlayer2();
    }

    void Player2CollectPoints()
    {
        foreach (PlayerGameMovement Player in ActiveTeam2){
            switch (Player.SP.colour){
                case 8:
                    if (!Player.ToxicImunity)
                    {
                        Player.Health -= (Player.SP.power + 1);
                    }
                    break;
                case 7:
                    break;
                case 6:
                    break;
                case 5:
                    ManaUI.Team2BlueMana += Player.SP.power+1;
                    break;
                case 4:
                    ManaUI.Team2YellowMana += Player.SP.power + 1;
                    break;
                case 3:
                    ManaUI.Team2GreenMana += Player.SP.power + 1;
                    break;
                case 2:
                    ManaUI.Team2RedMana += Player.SP.power + 1;
                    break;
                case 1:
                    break;
                case 0:
                    break;
            }
            ManaUI.UpdateUIPlayer2();
        }
        StartPlayer1sTurn();
        ManaUI.UpdateUIPlayer1();
    }


    void StartPlayer1sTurn()
    {

        if (ActiveTeam1.Count <= 0){
            state = BattleState.LOST;
        }
        else{
            Moves = 2;
            state = BattleState.PLAYER1TURN;
        }
    }

    void StartPlayer2sTurn()
    {
        if (ActiveTeam2.Count <= 0){
            state = BattleState.WON;
        }
        else{
            Moves = 2;
            state = BattleState.PLAYER2TURN;
        }

       
       
        
    }


    void CheckForPlayerSelect()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 30, PlayerLayerTeam1))
            {
                if (!hit.transform.CompareTag("3DUI"))
                {
                    if (hit.transform.CompareTag("Player"))
                    {
                        ClearMoveSpaces();
                        foreach (PlayerGameMovement Player in ActiveTeam1)
                        {
                            if (Player.name == hit.transform.name)
                            {
                                SelectPlayer(Player);
                                CurrentSelectedPlayer = Player;
                            }
                        }
                    }

                    if (hit.transform.CompareTag("MoveToTile"))
                    {
                        if (UsingAbility){
                            AbilitySet.CheckAbillityToUse(Ability, hit.transform);
                        }
                        else{
                            BoardSpaces SelectedSpace = hit.transform.GetComponent<ClickToMove>().Space;
                            CurrentSelectedPlayer.transform.position = hit.transform.position;
                            CurrentSelectedPlayer.SP.HasPlayer = false;
                            CurrentSelectedPlayer.SP.PlayerOn = null;
                            CurrentSelectedPlayer.SP = SelectedSpace;
                            SelectedSpace.HasPlayer = true;
                            SelectedSpace.PlayerOn = CurrentSelectedPlayer;

                            SelectedSpace.HasPlayer = true;
                            if (CurrentSelectedPlayer.SP.colour == 8 && !CurrentSelectedPlayer.ToxicImunity){
                                CurrentSelectedPlayer.Health -= (CurrentSelectedPlayer.SP.power + 1);
                            }

                            foreach (ClickToMove SpaceSquare in MoveToSpaces){
                                Destroy(SpaceSquare.gameObject);
                            }
                            MoveToSpaces.Clear();
                            Moves -= 1;
                        }
                    }
                }

            }
        }
    }

    void CheckForPlayerSelectTeam2()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 30 , PlayerLayerTeam2)){
                if (!hit.transform.CompareTag("3DUI")){

                    if (hit.transform.CompareTag("Player")){
                        ClearMoveSpaces();
                        foreach (PlayerGameMovement Player in ActiveTeam2){
                            if (Player.name == hit.transform.name){
                                SelectPlayer(Player);
                                CurrentSelectedPlayer = Player;
                            }
                        }
                    }
                    if (hit.transform.CompareTag("MoveToTile")){
                        if (UsingAbility){
                            AbilitySet.CheckAbillityToUse(Ability, hit.transform);
                        }
                        else{
                            BoardSpaces SelectedSpace = hit.transform.GetComponent<ClickToMove>().Space;
                            CurrentSelectedPlayer.transform.position = hit.transform.position;
                            CurrentSelectedPlayer.SP.HasPlayer = false;
                            CurrentSelectedPlayer.SP.PlayerOn = null;
                            CurrentSelectedPlayer.SP = SelectedSpace;
                            SelectedSpace.HasPlayer = true;
                            SelectedSpace.PlayerOn = CurrentSelectedPlayer;

                            SelectedSpace.HasPlayer = true;
                            if (CurrentSelectedPlayer.SP.colour == 8 && !CurrentSelectedPlayer.ToxicImunity){
                                CurrentSelectedPlayer.Health -= (CurrentSelectedPlayer.SP.power + 1);
                            }

                            foreach (ClickToMove SpaceSquare in MoveToSpaces){
                                Destroy(SpaceSquare.gameObject);
                            }
                            MoveToSpaces.Clear();
                            Moves -= 1;
                        }
                    }
                }
            }
        }
    }

    public void ClearMoveSpaces(){
        foreach (ClickToMove SpaceSquare in MoveToSpaces){
            Destroy(SpaceSquare.gameObject);
        }
        MoveToSpaces.Clear();
    }

    void SelectPlayer(PlayerGameMovement Player){
        if (UIPlayerActionHolder.childCount > 0){
            Destroy(UIPlayerActionHolder.GetChild(0).gameObject);
        }
        GameCamera.Target = Player.transform;

        //Possibly bad code needs to get looked at
        Instantiate(PlayerActions, Player.transform.position, GameCamera.CameraPos.transform.rotation, UIPlayerActionHolder);
    }

    public void SetPlayerInfo(PlayerGameMovement Player){
        foreach (Transform child in UIBarHolder){
            //Possibly bad code needs to get looked at
            Destroy(child.gameObject);
        }

        foreach(Abilities Ability in Player.PlayerAbilities){
            AbilityPanel abilityPanel = Instantiate(AbilityUIBar, UIBarHolder.position, UIBarHolder.rotation, UIBarHolder).GetComponent<AbilityPanel>();
            abilityPanel.AbilityInfo = Ability;
            abilityPanel.SetAbility();
        }
    }
}

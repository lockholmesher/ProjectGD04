using UnityEngine;
public class UIDirector : Singleton<UIDirector>
{
    [Header("Main UI")]
    [SerializeField] GameMenu menu;
    [SerializeField] GamePlay play;
    [SerializeField] GameVictory victory;
    [SerializeField] GameOver gameOver;
    [SerializeField] float delayToResult;

    public static GameMenu MenuState{ get{ return UIDirector.Instance.menu; }} 
    public static GamePlay PlayState{ get{ return UIDirector.Instance.play; }}
    public static GameVictory VictoryState{ get{ return UIDirector.Instance.victory; }}
    public static GameOver GameOverState{ get{ return UIDirector.Instance.gameOver; }}

    BaseState currentStates = null;

    public static void ChangeState(BaseState state)
    {
        UIDirector director = UIDirector.Instance;
        director.currentStates?.Hide();
        director.currentStates = state;
        director.currentStates.Show();

        if(state == director.menu)
        {

        }
        else if(state == director.play)
        {

        }
        else if(state == director.victory)
        {

        }
        else if(state == director.gameOver)
        {

        }
    }

    public void ChangeStateByEvent(BaseState state) => ChangeState(state);

    void Start()
    {
        victory.Hide();
        gameOver.Hide();
        menu.Hide();
        play.Hide();
        currentStates = null;

        ChangeState(UIDirector.MenuState);
    }

    public void Victory()
    {
        Game game = Game.Instance;
        if(game.state != GameState.VICTORY)
        {
            //Back
            game.Victory();
            //Front
            SoundManager.Stop();
		    SoundManager.PlaySound(Sound.ULTIMATE);
            Invoke("ShowVictory", delayToResult);
        }
    }
    public void ShowVictory()
    {
        if(Game.Instance.state != GameState.VICTORY)return;
        ChangeState(victory);
    }

    public void GameOver()
    {
        Game game = Game.Instance;
        if(game.state == GameState.PLAYING)
        {
            //Back
            game.Defeat();
            //Front
            SoundManager.Stop();
            SoundManager.PlaySound(Sound.GAME_OVER);
            Invoke("ShowGameOver", delayToResult);
        }
    }
    public void ShowGameOver()
    {
        if(Game.Instance.state != GameState.DEFEAT)return;
        ChangeState(gameOver);
    }

    public void Continue()
    {
        Game.Instance.Continue();
        ChangeState(play);
    }
}
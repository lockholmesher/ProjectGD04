using UnityEngine.UI;
using UnityEngine;
public class GameMenu : BaseState
{
    [SerializeField] GameSetting settingState;

    public override void Show()
    {
        base.Show();
        Game.Instance.Menu();

        SoundManager.Stop();
        SoundManager.PlayMusic(Music.MAIN_MENU);
        settingState.Hide();

    }

    public override void Hide()
    {
        base.Hide();
        settingState.Hide();
    }

    public void GamePlay()
    {
        Game game = Game.Instance;
        if(game.state == GameState.WELCOM || game.state == GameState.DEFEAT || game.state == GameState.VICTORY)
        {
            Game.Instance.Play();

            settingState.Hide();
            UIDirector.ChangeState(UIDirector.PlayState);
        }       
    }

    public void StartGameFromMainMenu()
    {
        GamePlay();
    }   

    public void GoSetting()
    {
        settingState.Show();
    }
}
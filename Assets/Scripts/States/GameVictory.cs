using UnityEngine;
using UnityEngine.UI;

public class GameVictory : BaseState
{
	public RectTransform coinReBar = null;
    public Text coinReceived = null;
    public Text levelText = null;
    public ParticleSystem congrualation;

    public void Update()
    {
    }

    public override void Show()
    {
        Game.Instance.Victory();

        base.Show();
        coinReceived.text = Game.Instance.coinPerLevel.ToString();
        levelText.text = LevelManager.Instance.LevelDisplay.ToString();
        
        Effect();
    }

    public void NextLevel()
    {
        ShowNext();      
    }

    public void ShowNext()
    {
        UIDirector.MenuState.GamePlay();       
    }

    public override void Hide()
    {
        base.Hide();
        congrualation?.Stop();
    }

    public void Effect() => congrualation?.Play(true);
}

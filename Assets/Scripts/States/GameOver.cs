using UnityEngine;
using UnityEngine.UI;

public class GameOver : BaseState
{
    public Text coinReceived = null;
    public Text levelText = null;
    public GameObject continueBtn = null;
    public GameObject noThanks = null;
    public GameObject replayTxt = null;
    public GameObject replayBtn = null;
    
    public float noThanksDelay = 1.5f;

    public override void Show()
    {
        Game.Instance.Defeat();
        
        base.Show();

        continueBtn.SetActive(true);
        noThanks.SetActive(false);
        replayTxt.SetActive(false);
        replayBtn.SetActive(false);

        coinReceived.text = Game.Instance.coinPerLevel.ToString();
        levelText.text = LevelManager.Instance.LevelDisplay.ToString();

        LayoutRebuilder.ForceRebuildLayoutImmediate(coinReceived.transform.parent as RectTransform);
		LayoutRebuilder.ForceRebuildLayoutImmediate(levelText.transform.parent as RectTransform);

        Invoke("ShowNoThanks", noThanksDelay);
    }

    public void ShowNoThanks()
    {
        noThanks.SetActive(true);
    }

    public void NoThanks()
    {
		UIDirector.ChangeState(UIDirector.MenuState);
    }

    public void Continue()
    {
        UIDirector.Instance.Continue();
    }
}

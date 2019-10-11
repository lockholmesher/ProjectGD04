using UnityEngine;
public class GamePlay : BaseState
{
    public override void Show()
    {
        base.Show();
        SoundManager.Stop();
        SoundManager.PlayMusic(Music.GAMEPLAY);
    }

    public override void Hide()
    {
        base.Hide();
    }
}
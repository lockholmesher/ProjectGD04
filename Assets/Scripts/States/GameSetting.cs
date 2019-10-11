using UnityEngine;
using UnityEngine.UI;

public class GameSetting : BaseState
{
    [SerializeField] Toggle soundToggle;

    public override void Show()
    {
        base.Show();
        if(soundToggle.isOn != SoundManager.IsEnable)
            soundToggle.isOn = SoundManager.IsEnable;
    }

    public override void Hide()
    {
        base.Hide();
    }
    
    public void SetSound()
    {
        SoundManager.OnOff(soundToggle.isOn);
    }
}
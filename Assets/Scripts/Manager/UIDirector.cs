using UnityEngine;
public class UIDirector : MonoBehaviour
{
    void Awake()
    {
        Events.ON_MENU += Menu;
        Events.ON_PLAY += Play;
        Events.ON_DEFEAT += Defeat;
    }

    void Menu()
    {

    }

    void Play()
    {

    }

    void Defeat()
    {

    }
}
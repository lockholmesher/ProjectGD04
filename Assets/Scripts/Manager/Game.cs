using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : Singleton<Game>
{
    [SerializeField] Vector2 gravity;
    [SerializeField] float gravityScale = 1;

    public static Vector2 Gravity{ get{return Game.Instance.gravityScale * Game.Instance.gravity; }}


    [HideInInspector] public GameStatus status;

    protected override void Awake()
    {
        base.Awake();
        Events.ON_MENU += Menu;
        Events.ON_PLAY += Play;
        Events.ON_DEFEAT += Defeat;
    }

    void Start()
    {
        Events.ON_PLAY();
    }

    void Menu()
    {
        status = GameStatus.WELCOM;
    }

    void Play()
    {
        status = GameStatus.PLAYING;
    }

    void Defeat()
    {
        status = GameStatus.DEFEAT;
    }
}

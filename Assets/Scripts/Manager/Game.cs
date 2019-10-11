using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : Singleton<Game>
{
    [SerializeField] Vector2 gravity;
    [SerializeField] float gravityScale = 1;

    public static Vector2 Gravity{ get{return Game.Instance.gravityScale * Game.Instance.gravity; }}


    [HideInInspector] public GameState state;
    public int coinPerLevel{get; private set;}

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        coinPerLevel = 0;
    }

    public void Menu()
    {
        state = GameState.WELCOM;
    }

    public void Play()
    {
        state = GameState.PLAYING;
        ObstacleSpawner.Instance.StartSpawn(true);
    }

    public void Defeat()
    {
        state = GameState.DEFEAT;
    }

    public void Victory()
    {
        state = GameState.VICTORY;
    }

    public void Continue()
    {
        
    }
}

using Project.Scripts.Game;
using Project.Scripts.Game.Base.Config;
using Project.Scripts.Game.Base.View;
using UnityEngine;

public class Entry : MonoBehaviour
{
    [SerializeField] private GameConfig _config;
    [SerializeField] private GameView _view;
    
    private Game _game;
    
    private void Start()
    {
        _game = new Game(_config, _view);
    }

    private void OnDestroy()
    {
        _game.Dispose();
    }
}

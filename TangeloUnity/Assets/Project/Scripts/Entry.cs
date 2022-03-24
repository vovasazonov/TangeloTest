using Project.Scripts.Core.Coroutine;
using Project.Scripts.Game;
using Project.Scripts.Game.Base.View;
using UnityEngine;

public class Entry : MonoBehaviour
{
    [SerializeField] private GameView _view;
    
    private Game _game;
    
    private void Start()
    {
        var coroutineFactory = new CoroutineFactory(this);
        _game = new Game(_view, coroutineFactory);
    }

    private void OnDestroy()
    {
        _game.Dispose();
    }
}

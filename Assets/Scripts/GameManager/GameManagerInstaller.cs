using System;
using UnityEngine;

namespace ShootEmUp
{
    [RequireComponent(typeof(GameManager))]
    public class GameManagerInstaller : MonoBehaviour
    {
        private GameManager gameManager;

        private void Awake()
        {
            gameManager = GetComponent<GameManager>();

            var listeners = GetComponentsInChildren<Listeners.IGameListener>();

            gameManager.AddGameListeners(listeners);
            gameManager.HandleStart();
        }
    }
}
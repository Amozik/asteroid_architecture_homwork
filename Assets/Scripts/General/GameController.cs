﻿using System;
using General.Controllers;
using UnityEngine;


namespace General
{
    public class GameController : MonoBehaviour, IDisposable
    {
        [SerializeField] 
        private GameConfig _gameConfig;

        private ControllersHandler _controllersHandler;

        private void Awake()
        {
            _controllersHandler = new ControllersHandler();

            var gameInitialization = new GameInitialization(_controllersHandler, _gameConfig);
        }

        private void Start()
        {
            _controllersHandler.Initialization();
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _controllersHandler.Execute(deltaTime);
        }
        
        private void LateUpdate()
        {
            var deltaTime = Time.deltaTime;
            _controllersHandler.LateExecute(deltaTime);
        }
        
        public void Dispose()
        {
            _controllersHandler.Cleanup();
        }
    }
}
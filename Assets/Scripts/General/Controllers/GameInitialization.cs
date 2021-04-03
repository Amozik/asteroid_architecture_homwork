using General.Controllers.UI;
using General.Enemies;
using General.Interfaces;
using General.Managers;
using General.Pool;
using General.UI;

namespace General.Controllers
{
    internal sealed class GameInitialization
    {
        public GameInitialization(ControllersHandler controllersHandler, GameConfig data)
        {
            ServiceLocator.SetService<IViewService>(new ViewViewService());
            
            var inputInitialization = new InputInitialization();
            
            var playerInitialization = new PlayerInitialization(data.playerConfig);
            
            var uiInitialization = new UiInitialization(data.uiConfig);
            
            var enemyInitialization = new EnemyInitialization(data.enemiesConfig, new DisplayDestroyedEnemies(uiInitialization.DestroyedEnemies));

            controllersHandler.Add(inputInitialization);
            controllersHandler.Add(playerInitialization);
            controllersHandler.Add(enemyInitialization);
            controllersHandler.Add(new InputController(inputInitialization.GetInput(), inputInitialization.GetFire()));
            controllersHandler.Add(new MoveController(inputInitialization.GetInput(), playerInitialization.Move));
            controllersHandler.Add(new EnemyMoveController(enemyInitialization.GetMoveEnemies()));
            controllersHandler.Add(new HealthController(playerInitialization.Player, data.playerConfig.playerHP));
            controllersHandler.Add(new WeaponController(inputInitialization.GetFire(), playerInitialization.Player, playerInitialization.Weapon, data.playerConfig.weaponCooldown));
            controllersHandler.Add(new SpawnerInitialization(enemyInitialization.GetEnemies()));
            controllersHandler.Add(new ScoreController(uiInitialization.Score));
        }
    }
}
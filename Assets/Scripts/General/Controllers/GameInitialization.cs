namespace General.Controllers
{
    internal sealed class GameInitialization
    {
        public GameInitialization(ControllersHandler controllersHandler, GameConfig data)
        {
            var inputInitialization = new InputInitialization();
            
            var playerInitialization = new PlayerInitialization(data.playerConfig);
         
            controllersHandler.Add(inputInitialization);
            controllersHandler.Add(playerInitialization);
            controllersHandler.Add(new InputController(inputInitialization.GetInput(), inputInitialization.GetFire()));
            controllersHandler.Add(new MoveController(inputInitialization.GetInput(), playerInitialization.Move));
            controllersHandler.Add(new HealthController(playerInitialization.Player));
            controllersHandler.Add(new WeaponController(inputInitialization.GetFire(), playerInitialization.Weapon));
        }
    }
}
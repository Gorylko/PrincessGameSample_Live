using PrincessGame.DLL.Helpers;
using PrincessGame.DLL.PlayingField;
using PrincessGame.DLL.PlayingField.Interfaces;
using PrincessGame.DLL.PlayingField.Members;

namespace PrincessGame.DLL
{
    public class PrincessGameLauncher
    {
        private readonly ActionPerformer _actionPerformer;
        private readonly FieldFiller _fieldFiller;

        public PrincessGameLauncher()
        {
            _actionPerformer = new ActionPerformer();
            _fieldFiller = new FieldFiller();
        }

        public GameData GetStartData(
            Position startPlayerPosition,
            Position princessPosition,
            int maxPlayerHp,
            int gameFieldHeight,
            int gameFiledWidth)
        {
            var player = new Player()
            {
                Position = startPlayerPosition,
                HealthPoints = maxPlayerHp
            };

            var gameField = new GameField(gameFieldHeight, gameFiledWidth);

            _fieldFiller.SpawnWalls(gameField);
            _fieldFiller.SpawnPlayer(gameField, player);
            _fieldFiller.SpawnPrincess(gameField, new Princess(), princessPosition);

            return new GameData()
            {
                Player = player,
                GameField = gameField
            };
        }

        public void PerformGameAction(ActionType actionType, GameField gameField, IPlayer player)
        {
            _actionPerformer.Perform(actionType, gameField, player);
        }
    }
}

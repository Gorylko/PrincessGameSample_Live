using PrincessGame.DLL.PlayingField;
using PrincessGame.DLL.PlayingField.Interfaces;

namespace PrincessGame.DLL.Helpers
{
    public class ActionPerformer
    {
        public void Perform(ActionType actionType, GameField gameField, IPlayer player)
        {
            var stepPosition = GetPositionAfterAction(actionType, player.Position);

            if (player.Place(gameField, stepPosition))
            {
                player.Position = stepPosition;
            }
        }

        private Position GetPositionAfterAction(ActionType actionType, Position positionBeforeAction)
        {
            switch (actionType)
            {
                case ActionType.MoveUp:
                    positionBeforeAction.Y++;
                    break;
                case ActionType.MoveRight:
                    positionBeforeAction.X++;
                    break;
                case ActionType.MoveDown:
                    positionBeforeAction.Y--;
                    break;
                case ActionType.MoveLeft:
                    positionBeforeAction.X--;
                    break;
                default:
                    break;
            }

            return positionBeforeAction;
        }
    }
}

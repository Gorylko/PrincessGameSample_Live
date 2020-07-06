﻿using System;
using System.Linq;
using PrincessGame.DLL.Exceptions;
using PrincessGame.DLL.PlayingField;
using PrincessGame.DLL.PlayingField.Interfaces;
using PrincessGame.DLL.PlayingField.Members;

namespace PrincessGame.DLL.Helpers
{
    public class FieldFiller
    {
        public void SpawnWalls(GameField gameField)
        {
            _ = gameField ?? throw new ArgumentNullException(nameof(gameField));

            gameField.Cells
                .Where(cell => 
                    cell.Position.X == 0
                    || cell.Position.Y == 0
                    || cell.Position.X == gameField.Width - 1
                    || cell.Position.Y == gameField.Height - 1)
                .ToList()
                .ForEach(cell => new Wall().Place(gameField, cell.Position));
        }

        public void SpawnPlayer(GameField gameField, IPlayer player)
        {
            if (!player.Place(gameField, player.Position))
            {
                throw new CanNotBePlacedException(player.Position.ToString());
            }
        }

        public void SpawnPrincess(GameField gameField, Princess princess, Position position)
        {
            if (!princess.Place(gameField, position))
            {
                throw new CanNotBePlacedException(position.ToString());
            }
        }
    }
}

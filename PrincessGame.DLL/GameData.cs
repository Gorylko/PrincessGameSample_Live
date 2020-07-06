using System;
using System.Collections.Generic;
using System.Text;
using PrincessGame.DLL.PlayingField;
using PrincessGame.DLL.PlayingField.Interfaces;

namespace PrincessGame.DLL
{
    public class GameData
    {
        public GameField GameField { get; set; }

        public IPlayer Player { get; set; }
    }
}

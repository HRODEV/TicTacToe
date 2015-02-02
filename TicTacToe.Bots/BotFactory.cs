using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TicTacToe.Bots
{
    public class BotFactory
    {
        private List<Type> listBotTypes;
    
        public BotFactory()
        {
            var ass = Assembly.GetAssembly(typeof(TicTacToe.Bots.AbstactBot));

            listBotTypes = ass.GetTypes().Where(x => !x.IsAbstract && x.IsSubclassOf(typeof(TicTacToe.Bots.AbstactBot))).ToList();
        }

        public IEnumerable<string> BotTypeNames
        {
            get
            {
                return listBotTypes.Select(bt => bt.Name);
            }
        }

        public AbstactBot CreatBot(string nameBotType, Logic.Board board, Logic.Player player)
        {
            if (board == null) throw new ArgumentNullException("board");
            if (player == null) throw new ArgumentNullException("player");

            if (listBotTypes.Exists(bt => bt.Name == nameBotType))
                return (TicTacToe.Bots.AbstactBot)Activator.CreateInstance(listBotTypes.First(bt => bt.Name == nameBotType), new object[] { null, null });
            else
                throw new ArgumentException("can't find bot of type " + nameBotType, "nameBotType");
        }
    }
}

using System;
using Rocket.Unturned.Player;
using SDG.Unturned;
using UnityEngine;
using Rocket.API;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Rocket.Unturned.Chat;
using SDG.Framework.Utilities;
using UnityEngine.UI;
using Object = System.Object;

namespace TextEffect
{
    public class experience : IRocketCommand
    {
        public AllowedCaller AllowedCaller
        {
            get { return AllowedCaller.Player; }
        }
        public string Name
        {
            get { return "exp"; }
        }
        public string Help
        {
            get { return "test"; }
        }
        public string Syntax
        {
            get { return "/exp"; }
        }
        public List<string> Aliases
        {
            get { return new List<string>(); }
        }
        public List<string> Permissions
        {
            get
            {
                return new List<string>();
            }
        }
        
        public void Execute(IRocketPlayer caller, params string[] command)
        {
            
            UnturnedPlayer player = (UnturnedPlayer) caller;
            
            if (command.Length != 1)
            {
                UnturnedChat.Say(caller,"Syntaxe : /exp [amount:int]",Color.magenta);
                return;
            }

            if (!uint.TryParse(command[0], out uint value))
            {
                UnturnedChat.Say(caller,"Syntaxe : /exp [amount:int]",Color.magenta); 
                return;
            }
            
            UnturnedChat.Say(caller,string.Format("Vous avez gagné {0} experiences",value.ToString()),Color.magenta); 
            player.Experience += value;
                
        }
    }
}
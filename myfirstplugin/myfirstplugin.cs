﻿using System;
using System.Collections.Generic;
using Exiled.API.Features;
using PlayerH = Exiled.API.Features.Player;
using server = Exiled.API.Features.Server;

namespace myfirstplugin
{
    public class myfirstplugin : Plugin<Config>
    {
        private EventHandler EventHandler;

        public override string Author { get; } = "jirka086";
        public override string Name { get; } = "MyFirstPlugin";
        public override string Prefix { get; } = "MyFirstPlugin";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(8, 0, 0);

        public static myfirstplugin stuff;
        public Dictionary<Player, int> Killcount = new Dictionary<Player, int>();

        public override void OnEnabled()
        {
            EventHandler = new EventHandler();
            stuff = this;

            PlayerH.Verified += EventHandler.OnVerified;
            PlayerH.Hurting += EventHandler.OnHurting;
            PlayerH.Dying += EventHandler.Ondeath;
            Server.RoundEnded += EventHandler.OnRoundEnd;

            base.OnEnabled();
        }

        public override void OnDisabled() 
        {

            PlayerH.Verified -= EventHandler.OnVerified;
            PlayerH.Hurting -= EventHandler.OnHurting;
            PlayerH.Dying -= EventHandler.Ondeath;
            Server.RoundEnded -= EventHandler.OnRoundEnd;

            stuff = null;
            EventHandler = null;
            base.OnDisabled();
        }

    }
}
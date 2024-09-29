using Exiled.API.Features;
using myfirstplugin;
using System;
using Player = Exiled.Events.Handlers.Player;

namespace sniper
{
    public class FlashbangGun : Plugin<Config>
    {
        public override string Name => "FlashbangGun";
        public override string Author => "thecroshel";
        public override string Prefix => "flashgun";
        public override Version Version => new Version(1, 2, 0);
        public override Version RequiredExiledVersion => new Version(8, 9, 11);

        private EventHandlers _eventHandlers;

        public override void OnEnabled()
        {
            if (!Config.IsEnabled) return;


            base.OnEnabled();
        }

        public override void OnDisabled()
        {

            _eventHandlers = null;
            base.OnDisabled();
        }

        private class EventHandlers
        {
        }
    }
}



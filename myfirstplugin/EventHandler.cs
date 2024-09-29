using System;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;

namespace myfirstplugin
{
    public class EventHandler
    {
        public void OnVerified(VerifiedEventArgs ev)
        {
            if (ev.Player.DoNotTrack) 
            {
                Log.Debug(ev.Player.UserId + "has DNT, will not be tracked");
                ev.Player.ShowHint("Thanks For Joinig this awsome server", 8);

            } else if (!ev.Player.DoNotTrack && !myfirstplugin.stuff.Killcount.ContainsKey(ev.Player))
            {
                myfirstplugin.stuff.Killcount.Add(ev.Player, 0);
                Log.Debug(ev.Player.UserId + "added killcount");
                ev.Player.ShowHint("Thanks For Joinig this awsome server", 8);
            }
        }

        public void OnHurting(HurtingEventArgs ev)
        {
            if (ev.Attacker == null || ev.Player == null) 
                return;
            if (!ev.IsAllowed || ev.Amount < 0 || ev.Attacker == ev.Player)
                return;
            
            ev.Attacker.ShowHint(ev.Player.Nickname + "as" + ev.Player.Role.ToString() + "damage" + Math.Round(ev.Amount).ToString());
            ev.Player.ShowHint(ev.Attacker.Nickname + "as" + ev.Attacker.Role.ToString() + "damage" + Math.Round(ev.Amount).ToString());

        }
        public void Ondeath(DyingEventArgs ev)
        {
            if (ev.Attacker == null);
                return;
            if (ev.Player == null) 
                return;
            if (ev.Attacker == ev.Player)
                return;
            
            if (myfirstplugin.stuff.Killcount.ContainsKey(ev.Attacker))
                myfirstplugin.stuff.Killcount[ev.Attacker]++;
            ev.Attacker.ShowHint(ev.Player.Nickname + ev.Player.Role + "killed" + myfirstplugin.stuff.Killcount[ev.Attacker].ToString());



        }

        public void OnRoundEnd(RoundEndedEventArgs ev)
        {
            myfirstplugin.stuff.Killcount.Clear();
        }


        public void OnUsingRadioBattery(UsingRadioBatteryEventArgs ev)
        {
            if (ev.Drain > 0)
            {
                ev.IsAllowed = false;
            }
        }
    }
}

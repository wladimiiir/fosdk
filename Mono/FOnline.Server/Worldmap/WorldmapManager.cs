using System;
using FOnline.Worldmap.Event;
using FOnline.Worldmap.Entity;

namespace FOnline.Worldmap
{
    public class WorldmapManager
    {
        /// <summary>
        /// Invoked when critter is transfered to worldmap.
        /// </summary>
        public event EventHandler<Event.PreparedEventArgs> Prepared;
        /// <summary>
        /// Invoked when critter starts first move on worldmap after transfer to worldmap.
        /// </summary>
        public event EventHandler<Event.StartedEventArgs> Started;
        /// <summary>
        /// Invoked when critters travel destination changes.
        /// </summary>
        public event EventHandler<Event.DestinationChangedEventArgs> DestinationChanged;
        /// <summary>
        /// Invoked when critter is on move on worldmap.
        /// </summary>
        public event EventHandler<Event.OnMoveEventArgs> OnMove;
        /// <summary>
        /// Invoked when critter stops travel on map.
        /// </summary>
        public event EventHandler<Event.StoppedEventArgs> Stopped;
        /// <summary>
        /// Invoked when critter tries to enter location under.
        /// </summary>
        public event EventHandler<Event.OnEnterEventArgs> OnEnter;
        /// <summary>
        /// Invoked when critter is kicked from travel group.
        /// </summary>
        public event EventHandler<Event.OnKickEventArgs> OnKick;
        /// <summary>
        /// Invoked when Npc is idle on worldmap.
        /// </summary>
        public event EventHandler<Event.NpcIdleEventArgs> NpcIdle;

        private readonly EncounterPool encounterPool = new EncounterPool ();
        private readonly Entity.Worldmap worldmap;

        public WorldmapManager (IWorldmapLoader loader)
        {
            this.worldmap = loader.LoadWorldmap ();
        }

        /// <summary>
        /// Loads worldmap definition and start worldmap processing:
        /// 1. handle encounter group spawning
        /// 2. move encounter groups on WM
        /// 3. invite encounter groups to encounters
        /// 4. invite players to encounters
        /// </summary>
        public void Start ()
        {
            Main.GlobalProcess += GlobalProcess;
            Main.GlobalInvite += GlobalInvite;

            //starting global event for processing
            Global.CreateTimeEvent (Global.FullSecond, ProcessWorldmap, false);
        }

        /// <summary>
        /// Factory method for creating WorldmapLeader wrapper from Critter
        /// </summary>
        /// <returns>
        /// The worldmap leader.
        /// </returns>
        /// <param name='leader'>
        /// Critter to wrap.
        /// </param>
        protected WorldmapLeader CreateWorldmapLeader (Critter leader)
        {
            return new WorldmapLeader (leader);
        }

        /// <summary>
        /// Factory method for creating Transport wrapper for Item
        /// </summary>
        /// <returns>
        /// The transport.
        /// </returns>
        /// <param name='transport'>
        /// Item to wrap.
        /// </param>
        protected Transport CreateTransport (Item transport)
        {
            return new Transport (transport);
        }

        /// <summary>
        /// Factory method for creating Worldmap group
        /// </summary>
        /// <returns>The worldmap group.</returns>
        /// <param name="critter">Critter.</param>
        /// <param name="transport">Transport.</param>
        protected PlayerWorldmapGroup CreateWorldmapGroup (Critter critter, Item transport)
        {
            return new PlayerWorldmapGroup (CreateWorldmapLeader (critter), new Transport (transport));
        }

        private void GlobalProcess (object sender, GlobalProcessEventArgs e)
        {
            switch (e.Type) {
            case GlobalProcessType.StartFast:
                if (Prepared != null) {
                    var eventArgs = new PreparedEventArgs (CreateWorldmapGroup (e.Cr, e.Car), e.X, e.Y);
                    Prepared (sender, eventArgs);
                }
                break;
            case GlobalProcessType.Start:
                if (Started != null) {
                    var eventArgs = new StartedEventArgs (CreateWorldmapGroup (e.Cr, e.Car), e.X, e.Y, e.ToX, e.ToY);
                    Started (sender, eventArgs);
                    if (eventArgs.Cancelled) {
                        e.ToX = e.X;
                        e.ToY = e.Y;
                    }
                }
                break;
            case GlobalProcessType.SetMove:
                if (DestinationChanged != null) {
                    var eventArgs = new DestinationChangedEventArgs (CreateWorldmapGroup (e.Cr, e.Car), e.X, e.Y, e.ToX, e.ToY);
                    DestinationChanged (sender, eventArgs);
                }
                break;
            case GlobalProcessType.Move:
                if (OnMove != null) {
                    var eventArgs = new OnMoveEventArgs (CreateWorldmapGroup (e.Cr, e.Car), e.X, e.Y, e.ToX, e.ToY, e.Speed);
                    OnMove (sender, eventArgs);
                    if (eventArgs.Stopped) {
                        e.ToX = e.X;
                        e.ToY = e.Y;
                    }
                    if (eventArgs.Encounter != null) {
                        encounterPool.AddEncounter (eventArgs.Encounter);
                    }
                }
                break;
            case GlobalProcessType.Stopped:
                if (Stopped != null) {
                    var eventArgs = new StoppedEventArgs (CreateWorldmapGroup (e.Cr, e.Car), e.X, e.Y, e.ToX, e.ToY);
                    Stopped (sender, eventArgs);
                }
                break;
            case GlobalProcessType.Enter:
                if (OnEnter != null) {
                    var eventArgs = new OnEnterEventArgs (CreateWorldmapGroup (e.Cr, e.Car), e.X, e.Y);
                    OnEnter (sender, eventArgs);
                }
                break;
            case GlobalProcessType.Kick:
                if (OnKick != null) {
                    var eventArgs = new OnKickEventArgs (CreateWorldmapGroup (e.Cr.GetFollowLeader (), e.Car), new WorldmapCritter (e.Cr), e.X, e.Y);
                    OnKick (sender, eventArgs);
                    if (eventArgs.Cancelled) {
                        break;
                    }
                }
                e.Cr.LeaveGlobalGroup ();

                break;
            case GlobalProcessType.NpcIdle:
                if (NpcIdle != null) {
                    var eventArgs = new NpcIdleEventArgs (CreateWorldmapGroup (e.Cr, e.Car), e.X, e.Y);
                    NpcIdle (sender, eventArgs);
                }
                break;
            default:
                break;
            }
        }

        private void GlobalInvite (object sender, GlobalInviteEventArgs e)
        {

        }

        private static uint ProcessWorldmap (IntPtr ptr)
        {
            //TODO process world change
            return Configuration.WorldmapProcessInterval;
        }
    }
}


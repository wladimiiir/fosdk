using System;
using FOnline.Worldmap.Entity;

namespace FOnline.Worldmap.Event
{
    public class PreparedEventArgs : EventArgs
    {
        public PlayerWorldmapGroup Group { get; private set; }

        public float CurrentX{ get; private set; }

        public float CurrentY{ get; private set; }

        public PreparedEventArgs (PlayerWorldmapGroup group, float currentX, float currentY)
        {
            this.Group = group;
            this.CurrentX = currentX;
            this.CurrentY = currentY;
        }
    }

    public class StartedEventArgs : EventArgs
    {
        public PlayerWorldmapGroup Group { get; private set; }

        public float CurrentX{ get; private set; }

        public float CurrentY{ get; private set; }

        public float DestinationX{ get; private set; }

        public float DestinationY{ get; private set; }

        public bool Cancelled{ get; private set; }

        public StartedEventArgs (PlayerWorldmapGroup group, float currentX, float currentY, float destinationX, float destinationY)
        {
            this.Group = group;
            this.CurrentX = currentX;
            this.CurrentY = currentY;
            this.DestinationX = destinationX;
            this.DestinationY = destinationY;
        }

        public void ChangeDestination (float x, float y)
        {
            DestinationX = x;
            DestinationY = y;
        }

        public void Cancel ()
        {
            Cancelled = true;
        }
    }

    public class DestinationChangedEventArgs : EventArgs
    {
        public PlayerWorldmapGroup Group { get; private set; }

        public float CurrentX{ get; private set; }

        public float CurrentY{ get; private set; }

        public float DestinationX{ get; private set; }

        public float DestinationY{ get; private set; }

        public float Speed{ get; set; }

        public DestinationChangedEventArgs (PlayerWorldmapGroup group, float currentX, float currentY, float destinationX, float destinationY)
        {
            this.Group = group;
            this.CurrentX = currentX;
            this.CurrentY = currentY;
            this.DestinationX = destinationX;
            this.DestinationY = destinationY;
            this.Speed = group.Transport.Speed;
        }

        public void ChangeDestination (float x, float y)
        {
            DestinationX = x;
            DestinationY = y;
        }
    }

    public class OnMoveEventArgs : EventArgs
    {
        public PlayerWorldmapGroup Group { get; private set; }

        public float CurrentX{ get; private set; }

        public float CurrentY{ get; private set; }

        public float DestinationX{ get; private set; }

        public float DestinationY{ get; private set; }

        public float Speed{ get; set; }

        public bool Stopped{ get; private set; }

        public Encounter Encounter{ get; set; }

        public OnMoveEventArgs (PlayerWorldmapGroup group, float currentX, float currentY, float destinationX, float destinationY, float speed)
        {
            this.Group = group;
            this.CurrentX = currentX;
            this.CurrentY = currentY;
            this.DestinationX = destinationX;
            this.DestinationY = destinationY;
            this.Speed = speed;
            this.Stopped = false;
        }

        public void Stop ()
        {
            Stopped = true;
        }

        public void ChangeDestination (float x, float y)
        {
            DestinationX = x;
            DestinationY = y;
        }
    }

    public class StoppedEventArgs : EventArgs
    {
        public PlayerWorldmapGroup Group { get; private set; }

        public float CurrentX{ get; private set; }

        public float CurrentY{ get; private set; }

        public float DestinationX{ get; private set; }

        public float DestinationY{ get; private set; }

        public StoppedEventArgs (PlayerWorldmapGroup group, float currentX, float currentY, float destinationX, float destinationY)
        {
            this.Group = group;
            this.CurrentX = currentX;
            this.CurrentY = currentY;
            this.DestinationX = destinationX;
            this.DestinationY = destinationY;
        }

        public void ChangeDestination (float x, float y)
        {
            DestinationX = x;
            DestinationY = y;
        }
    }

    public class OnEnterEventArgs : EventArgs
    {
        public PlayerWorldmapGroup Group { get; private set; }

        public float CurrentX{ get; private set; }

        public float CurrentY{ get; private set; }

        public Encounter Encounter { get; set; }

        public OnEnterEventArgs (PlayerWorldmapGroup group, float currentX, float currentY)
        {
            this.Group = group;
            this.CurrentX = currentX;
            this.CurrentY = currentY;
        }
    }

    public class OnKickEventArgs : EventArgs
    {
        public PlayerWorldmapGroup Group { get; private set; }

        public WorldmapCritter ToKick { get; private set; }

        public float CurrentX{ get; private set; }

        public float CurrentY{ get; private set; }

        public bool Cancelled { get; private set; }

        public OnKickEventArgs (PlayerWorldmapGroup group, WorldmapCritter toKick, float currentX, float currentY)
        {
            this.Group = group;
            this.ToKick = toKick;
            this.CurrentX = currentX;
            this.CurrentY = currentY;
            this.Cancelled = false;
        }

        public void Cancel ()
        {
            Cancelled = true;
        }
    }

    public class NpcIdleEventArgs : EventArgs
    {
        public PlayerWorldmapGroup Group { get; private set; }

        public float CurrentX{ get; private set; }

        public float CurrentY{ get; private set; }

        public Encounter Encounter { get; set; }

        public NpcIdleEventArgs (PlayerWorldmapGroup group, float currentX, float currentY)
        {
            this.Group = group;
            this.CurrentX = currentX;
            this.CurrentY = currentY;
        }
    }
}


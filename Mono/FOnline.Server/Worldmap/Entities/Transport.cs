using System;

namespace FOnline.Worldmap.Entity
{
    public class Transport : GameType
    {
        private readonly Item item;

        public float Speed { get; set; }

        public float Capacity { get; set; }

        public Transport (Item item)
        {
            this.item = item;
            this.Speed = item == null ? Configuration.WorldmapBaseMapSpeed : item.Proto.Car_Speed;
            this.Capacity = item == null ? 0 : item.Proto.Car_CrittersCapacity;

            InitEvents ();
        }

        private void InitEvents ()
        {
            if (item == null)
                return;

            item.UseOnMe += (sender, e) => {
                HandleGameType<WorldmapCritter> (item, wmCritter => {
                    wmCritter.createGroup (this).GoToEncounter ();
                });
            };
        }
    }
}


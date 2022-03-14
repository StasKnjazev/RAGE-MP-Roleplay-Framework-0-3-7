using System;

namespace Faction_Life
{
    class DoorState
    {
        public DoorState DoorFrontLeft
        {
            get => PlayerVehicle.DoorFrontLeft;
            set => PlayerVehicle.DoorFrontLeft = value;
        }

        public DoorState DoorFrontRight
        {
            get => PlayerVehicle.DoorFrontRight;
            set => PlayerVehicle.DoorFrontRight = value;
        }

        public DoorState DoorRearLeft
        {
            get => PlayerVehicle.DoorRearLeft;
            set => PlayerVehicle.DoorRearLeft = value;
        }

        public DoorState DoorRearRight
        {
            get => PlayerVehicle.DoorRearRight;
            set => PlayerVehicle.DoorRearRight = value;
        }

        public DoorState DoorHood
        {
            get => PlayerVehicle.DoorHood;
            set => PlayerVehicle.DoorHood = value;
        }

        public DoorState DoorTrunk
        {
            get => PlayerVehicle.DoorTrunk;
            set => PlayerVehicle.DoorTrunk = value;
        }

        public static explicit operator int(DoorState v)
        {
            throw new NotImplementedException();
        }
    }
}
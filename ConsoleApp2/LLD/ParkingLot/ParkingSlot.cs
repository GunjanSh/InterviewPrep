using System;
using System.Linq.Expressions;

namespace ConsoleApp2.LLD.ParkingLot
{
    internal class ParkingSlot
    {
        public int ParkingSlotId { get; set; }

        public ParkingSlotType ParkingSlotType;

        public bool IsAvailable = true;

        public Vehicle ParkedVehicle;

        public double GetBaseAmount()
        {
            switch (this.ParkingSlotType) {
                case ParkingSlotType.FourWheelerCompact:
                    return 80;
                case ParkingSlotType.FourWheelerMedium:
                    return 100;
                case ParkingSlotType.FourWheelerLarge:
                    return 120;
                case ParkingSlotType.BigVehicle:
                    return 200;
                case ParkingSlotType.ElectricVehicle:
                    return 150;
                case ParkingSlotType.TwoWheeler:
                default:
                        return 50;
            }
        }

        public void BookParkingSlot(Vehicle vehicle)
        {
            this.IsAvailable = false;
            this.ParkingSlotType = vehicle.VehicleType;
            this.ParkedVehicle = vehicle;
        }

        public void ReleaseParkingSlot()
        {
            this.IsAvailable = true;
            this.ParkedVehicle = null;
        }
    }
}
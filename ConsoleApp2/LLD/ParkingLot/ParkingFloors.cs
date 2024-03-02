using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace ConsoleApp2.LLD.ParkingLot
{
    internal class ParkingFloors
    {
        public int ParkingFloorId;

        public Dictionary<ParkingSlotType, List<ParkingSlot>> Slots;

        public ParkingSlot GetParkingSlot(Vehicle vehicle)
        {               
            var availableSlots = this.Slots.Where(x => x.Key == vehicle.VehicleType).SelectMany(x => x.Value);

            ParkingSlot parkingSlot = availableSlots.FirstOrDefault(x => x.IsAvailable);

            return parkingSlot;
        }
    }
}
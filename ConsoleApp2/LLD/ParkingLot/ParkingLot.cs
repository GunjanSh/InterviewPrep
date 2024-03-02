using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.LLD.ParkingLot
{
    internal class ParkingLot
    {
        public string Name;

        public Address Address;

        public List<ParkingFloors> ParkingFloors;

        public ParkingLot(string name, Address address, List<ParkingFloors> parkingFloors)
        {
            Name = name;
            Address = address;
            ParkingFloors = parkingFloors;
        }

        public Ticket AssignParkingTicket(Vehicle vehicle)
        {
            var slot = this.FindParkingSlot(vehicle);
            if (slot == null)
            {
                return null;
            }

            this.BookParkingSlot(slot, vehicle);
            return new Ticket().GenerateTicket(slot, vehicle);
        }

        public void PayAndExit(Ticket ticket)
        {
            var exitTime = (DateTime.UtcNow - ticket.CheckInTime).TotalMinutes;
            var baseRate = ticket.ParkedAtSlot.GetBaseAmount();
            var amountToPay = baseRate * exitTime;

            Console.WriteLine("Amount to pay for vehicle type : {0} is {1}", ticket.ParkedVehicle.VehicleType.ToString(), amountToPay);

            this.ReleaseParkingSlot(ticket.ParkedAtSlot);
        }

        public void AddFloor(int floorId, ParkingSlotType parkingSlotType, List<ParkingSlot> slots)
        {
            var parkingSlots = new Dictionary<ParkingSlotType, List<ParkingSlot>>
            {
                { parkingSlotType, slots }
            };

            var floor = new ParkingFloors
            {
                ParkingFloorId = floorId,
                Slots = parkingSlots,
            };

            var list = this.ParkingFloors.FirstOrDefault(x => x.ParkingFloorId == floorId);

            if (list != null)
            {
                list.Slots.Add(parkingSlotType, slots);
            }
            else
            {
                this.ParkingFloors.Add(floor);
            }
        }

        public void RemoveFloor(int floorId)
        {
            var floor = this.ParkingFloors.FirstOrDefault(x => x.ParkingFloorId == floorId);
            this.ParkingFloors.Remove(floor);
        }

        ParkingSlot FindParkingSlot(Vehicle vehicle)
        {
            ParkingSlot slot = null;

            foreach (ParkingFloors floor in this.ParkingFloors)
            {
                var availableSlot = floor.GetParkingSlot(vehicle);

                if (availableSlot != null)
                {
                    return availableSlot;
                }
            }

            return slot;
        }

        void BookParkingSlot(ParkingSlot parkingSlot, Vehicle vehicle)
        {
            parkingSlot.BookParkingSlot(vehicle);
        }

        void ReleaseParkingSlot(ParkingSlot parkingSlot)
        {
            parkingSlot.ReleaseParkingSlot();
        }
    }
}

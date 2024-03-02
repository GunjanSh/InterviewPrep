using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.LLD.ParkingLot
{
    internal class Ticket
    {
        public string TicketNumber { get; set; }

        public Vehicle ParkedVehicle { get; set; }

        public ParkingSlot ParkedAtSlot { get; set; }

        public DateTime CheckInTime { get; set; }

        public Ticket GenerateTicket(ParkingSlot parkingSlot,  Vehicle vehicle)
        {
            var time = DateTime.UtcNow;

            return new Ticket()
            {
                ParkedVehicle = vehicle,
                ParkedAtSlot = parkingSlot,
                CheckInTime = time,
                TicketNumber = vehicle.VehicleNumber + time.TimeOfDay.TotalMilliseconds
            };
        }
    }
}

using System;

namespace ConsoleApp2.LLD.ParkingLot
{
    public class Address
    {
        public string City;

        public string State;

        public int PinCode;

        public Address(string city, string state, int pinCode) {
            this.City = city;
            this.State = state;
            this.PinCode = pinCode;
        }
    }
}
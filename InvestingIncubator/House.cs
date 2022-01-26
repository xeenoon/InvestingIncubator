using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestingIncubator
{
    public class House
    {
        public List<Room> rooms = new List<Room>();

        public House(List<Room> rooms)
        {
            this.rooms = rooms;
        }
        public static House Random()
        {
            List<Room> rooms = new List<Room>();

            Random r = new Random();
            int rating = r.Next(1,6);
            rooms.Add(new Room(r.Next(rating-2,rating+2), Room.RoomType.Kitchen));
            rooms.Add(new Room(r.Next(rating-2,rating+2), Room.RoomType.Bathroom));
            rooms.Add(new Room(r.Next(rating-2,rating+2), Room.RoomType.Bedroom));

            int roomcount = r.Next(2, 8);
            for (int i = 0; i < roomcount; ++i)
            {
                Array values = Enum.GetValues(typeof(Room.RoomType));
                Room.RoomType randomRoom = (Room.RoomType)values.GetValue(r.Next(values.Length));

                rooms.Add(new Room(r.Next(rating - 2, rating + 2), randomRoom));
            }
            return new House(rooms);
        }
    }
    public class Room
    {
        public enum RoomType
        {
            Kitchen,
            Dining,
            Lounge,
            Bathroom,
            Bedroom,
            Garage
        }
        public RoomType roomType;
        public List<RoomObject> roomObjects = new List<RoomObject>();

        public Room(int stars, RoomType roomType)
        {
            this.roomType = roomType;
            PopulateRoom(stars-1, stars+2);
        }

        public void PopulateRoom()
        {
            Random r = new Random();
            switch (roomType)
            {
                case RoomType.Kitchen:
                    roomObjects.Add(new RoomObject(r.Next(1, 6), RoomObject.ApplianceType.Oven));
                    roomObjects.Add(new RoomObject(r.Next(1, 6), RoomObject.ApplianceType.Sink));
                    roomObjects.Add(new RoomObject(r.Next(1, 6), RoomObject.ApplianceType.Dishwasher));
                    roomObjects.Add(new RoomObject(r.Next(1, 6), RoomObject.ApplianceType.Cupboard));
                    roomObjects.Add(new RoomObject(r.Next(1, 6), RoomObject.ApplianceType.Fridge));
                    roomObjects.Add(new RoomObject(r.Next(1, 6), RoomObject.ApplianceType.Bench));
                    break;
                case RoomType.Bathroom:
                    roomObjects.Add(new RoomObject(r.Next(1, 6), RoomObject.ApplianceType.Toilet));
                    roomObjects.Add(new RoomObject(r.Next(1, 6), RoomObject.ApplianceType.Tap));
                    roomObjects.Add(new RoomObject(r.Next(1, 6), RoomObject.ApplianceType.Shower));
                    roomObjects.Add(new RoomObject(r.Next(1, 6), RoomObject.ApplianceType.Bath));
                    break;
                default:
                    roomObjects.Add(new RoomObject(r.Next(1, 6), RoomObject.ApplianceType.Wall));
                    roomObjects.Add(new RoomObject(r.Next(1, 6), RoomObject.ApplianceType.Lights));
                    roomObjects.Add(new RoomObject(r.Next(1, 6), RoomObject.ApplianceType.Floor));
                    break;
            }
        }
        public void PopulateRoom(int value)
        {
            switch (roomType)
            {
                case RoomType.Kitchen:
                    roomObjects.Add(new RoomObject(value, RoomObject.ApplianceType.Oven));
                    roomObjects.Add(new RoomObject(value, RoomObject.ApplianceType.Sink));
                    roomObjects.Add(new RoomObject(value, RoomObject.ApplianceType.Dishwasher));
                    roomObjects.Add(new RoomObject(value, RoomObject.ApplianceType.Cupboard));
                    roomObjects.Add(new RoomObject(value, RoomObject.ApplianceType.Fridge));
                    roomObjects.Add(new RoomObject(value, RoomObject.ApplianceType.Bench));
                    break;
                case RoomType.Bathroom:
                    roomObjects.Add(new RoomObject(value, RoomObject.ApplianceType.Toilet));
                    roomObjects.Add(new RoomObject(value, RoomObject.ApplianceType.Tap));
                    roomObjects.Add(new RoomObject(value, RoomObject.ApplianceType.Shower));
                    roomObjects.Add(new RoomObject(value, RoomObject.ApplianceType.Bath));
                    break;
                default:
                    roomObjects.Add(new RoomObject(value, RoomObject.ApplianceType.Wall));
                    roomObjects.Add(new RoomObject(value, RoomObject.ApplianceType.Lights));
                    roomObjects.Add(new RoomObject(value, RoomObject.ApplianceType.Floor));
                    break;
            }
        }
        public void PopulateRoom(int min, int max)
        {
            Random r = new Random();
            switch (roomType)
            {
                case RoomType.Kitchen:
                    roomObjects.Add(new RoomObject(r.Next(min, max), RoomObject.ApplianceType.Oven));
                    roomObjects.Add(new RoomObject(r.Next(min, max), RoomObject.ApplianceType.Sink));
                    roomObjects.Add(new RoomObject(r.Next(min, max), RoomObject.ApplianceType.Dishwasher));
                    roomObjects.Add(new RoomObject(r.Next(min, max), RoomObject.ApplianceType.Cupboard));
                    roomObjects.Add(new RoomObject(r.Next(min, max), RoomObject.ApplianceType.Fridge));
                    roomObjects.Add(new RoomObject(r.Next(min, max), RoomObject.ApplianceType.Bench));
                    break;                              
                case RoomType.Bathroom:                 
                    roomObjects.Add(new RoomObject(r.Next(min, max), RoomObject.ApplianceType.Toilet));
                    roomObjects.Add(new RoomObject(r.Next(min, max), RoomObject.ApplianceType.Tap));
                    roomObjects.Add(new RoomObject(r.Next(min, max), RoomObject.ApplianceType.Shower));
                    roomObjects.Add(new RoomObject(r.Next(min, max), RoomObject.ApplianceType.Bath));
                    break;                              
                default:                                
                    roomObjects.Add(new RoomObject(r.Next(min, max), RoomObject.ApplianceType.Wall));
                    roomObjects.Add(new RoomObject(r.Next(min, max), RoomObject.ApplianceType.Lights));
                    roomObjects.Add(new RoomObject(r.Next(min, max), RoomObject.ApplianceType.Floor));
                    break;
            }
        }
    }
    public class RoomObject
    {
        public enum ApplianceType
        {
            //Any
            Wall,
            Lights,
            Floor,

            //Kitchen
            Oven,
            Sink,
            Dishwasher,
            Cupboard,
            Fridge,
            Bench,

            //Bathroom
            Toilet,
            Tap,
            Shower,
            Bath,
        }
        public float stars = 0f;
        public ApplianceType applianceType;
        

        public RoomObject(float stars, ApplianceType applianceType)
        {
            this.stars = stars;
            this.applianceType = applianceType;
        }
    }
}

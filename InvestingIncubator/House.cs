using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestingIncubator
{
    public class House
    {
        public Rooms rooms = new Rooms();

        public House(Rooms rooms)
        {
            this.rooms = rooms;
        }
        public static House Random()
        {
            Rectangle test1 = new Rectangle(0,0,100,100);
            Rectangle test2 = new Rectangle(25,25,50,50);
            if (test2.IntersectsWith(test1))
            {

            }


            Rooms rooms = new Rooms();

            Random r = new Random();
            int rating = r.Next(1,8);
            rooms.Add(new Room(r.Next(rating-2,rating+2), Room.RoomType.Kitchen));
            rooms.Add(new Room(r.Next(rating-2,rating+2), Room.RoomType.Bathroom));
            rooms.Add(new Room(r.Next(rating-2,rating+2), Room.RoomType.Bedroom));

            int roomcount = r.Next(2, 8);
            const int totalvals = 100;
            for (int i = 0; i < roomcount; ++i)
            {
                int value = r.Next(0,100);
                Room.RoomType randomroom = Room.RoomType.Bedroom;
                if (value < Room.KitchenWeight && rooms.Where(rm=>rm.roomType == Room.RoomType.Kitchen).Count() <= 1) //10 there can only be 2 kitchens
                {
                    randomroom = Room.RoomType.Kitchen;
                }
                if (value < Room.DiningWeight && rooms.Where(rm => rm.roomType == Room.RoomType.Dining).Count() <= 1) //10 there can only be 2 dining rooms
                {
                    randomroom = Room.RoomType.Dining;
                }
                else if (value < Room.LoungeWeight) //40
                {
                    randomroom = Room.RoomType.Lounge;
                }
                else if (value < Room.BathroomWeight)
                {
                    randomroom = Room.RoomType.Bathroom;
                }
                else
                {
                    randomroom = Room.RoomType.Bedroom;
                }
                rooms.Add(new Room(r.Next(rating - 2, rating + 2), randomroom));
            }
            Rectangle boundries = new Rectangle(0,0,r.Next(150,250), r.Next(250,350));
            

            const int hallwayWidth = 15;

            var publicrooms = rooms.Where(rm=>rm.IsPublic()).ToList();
            var privaterooms = rooms.Where(rm=>!rm.IsPublic()).ToList();
            rooms.Clear();

            Room firstPlacement = publicrooms[r.Next(0, publicrooms.Count)];
            firstPlacement.area = new Rectangle(0,0,r.Next(25,100),r.Next(25,100));
            firstPlacement.placed = true;
            rooms.Add(firstPlacement);
            publicrooms.Remove(firstPlacement);

            Room hallway = new Room(0, Room.RoomType.Hallway);
            rooms.Add(hallway);
            hallway.placed = true;
            hallway.area = new Rectangle(firstPlacement.area.Width, 0, hallwayWidth, (int)(boundries.Height*0.4f));

            foreach (var room in publicrooms)
            {
                room.area = new Rectangle(0,0,r.Next(25,100), r.Next(25,100));
            } //Generate random areas for all the rooms
            foreach (var room in privaterooms)
            {
                room.area = new Rectangle(0, 0, r.Next(20, 50), r.Next(20, 50));
            } //Generate random areas for all the rooms
            int times = 0;
            while (publicrooms.Count != 0 && !(times == 10000)) //Run until all rooms are placed
            {
                ++times;
                Room next = rooms[r.Next(0, rooms.Count)];
                Room placing = publicrooms[0];
                placing.placed = true;
                var availableSides = next.AvailableSides(rooms, placing, boundries);
                if (availableSides.Count == 0)
                {
                    placing.placed = false;
                    continue; //Exit if there are no sides to stop NullReferenceException
                }
                Room.Side randomSide = availableSides[r.Next(0,availableSides.Count)];
                placing.Place(next, randomSide);
                rooms.Add(placing);
                publicrooms.Remove(placing);
            }
            times = 0;

            while (privaterooms.Count != 0 && !(times == 10000)) //Run until all rooms are placed
            {
                ++times;
                List<Room> prooms = rooms.Where(rm => rm.IsPublic()).ToList();
                var next = prooms[r.Next(0, prooms.Count)];
                Room placing = privaterooms[0];
                placing.placed = true;
                var availableSides = next.AvailableSides(rooms, placing, boundries);
                if (availableSides.Count == 0)
                {
                    placing.placed = false;
                    continue; //Exit if there are no sides to stop NullReferenceException
                }
                Room.Side randomSide = availableSides[r.Next(0, availableSides.Count)];
                placing.Place(next, randomSide);
                rooms.Add(placing);
                privaterooms.Remove(placing);
            }
            const int CLOSESTDISTANCE = 5;
            //Adjust to remove small holes
            foreach (var room in rooms)
            {
                  var closestTop = rooms.Where(rm=>Math.Abs(rm.area.Bottom-room.area.Top) <= CLOSESTDISTANCE); //Are two sides near each other?
                  foreach (var rm in closestTop)
                  {
                      rm.area.Height = room.area.Y- rm.area.Y; //Reset its height to hit the top of this room
                  }
                  
                  var closestBottom = rooms.Where(rm => Math.Abs(room.area.Bottom - rm.area.Top) <= CLOSESTDISTANCE); //Are two sides near each other?
                  foreach (var rm in closestBottom)
                  {
                      if ((room.area.Bottom - rm.area.Top) == 0)
                      {
                          continue;
                      }
                    rm.area.Y = room.area.Y + room.area.Height; //Fit the sides together
                   rm.area.Height = rm.area.Height + (room.area.Bottom - rm.area.Top); //Adjust the height
                  }
              
                var closestRight = rooms.Where(rm => Math.Abs(rm.area.Left - room.area.Right) <= CLOSESTDISTANCE); //Are two sides near each other?
                foreach (var rm in closestRight)
                {
                    rm.area.Width = rm.area.Width + (rm.area.Left - room.area.Right); //Adjust the width
                    rm.area.X = room.area.X + room.area.Width; //Fit the sides together
                }
       
                var closestLeft = rooms.Where(rm => Math.Abs(room.area.Left - rm.area.Right) <= CLOSESTDISTANCE); //Are two sides near each other?
                foreach (var rm in closestLeft)
                {
                    rm.area.Width += (room.area.X - rm.area.Right); //Reset its height to hit the top of this room
                }
            }
            return new House(rooms);
        }
    }
    public class Room
    {
        public bool placed;
        public List<Side> AvailableSides(List<Room> otherRooms, Room placement, Rectangle boundries)
        {
            Room copy = placement.Copy();
            var result = new List<Side> { Side.Left, Side.Right, Side.Top, Side.Bottom };

            copy.Place(this, Side.Left);
            if (otherRooms.Where(r => r.area.IntersectsWith(copy.area)).Count() >= 1) //There will be one because prev is included
            {
                result.Remove(Side.Left);
            }
            copy.Place(this, Side.Right);
            if (otherRooms.Where(r => r.area.IntersectsWith(copy.area)).Count() >= 1) //There will be one because prev is included
            {
                result.Remove(Side.Right);
            }
            copy.Place(this, Side.Top);
            if (otherRooms.Where(r => r.area.IntersectsWith(copy.area)).Count() >= 1) //There will be one because prev is included
            {
                result.Remove(Side.Top);
            }
            copy.Place(this, Side.Bottom);
            //prev.area.Width = room.area.Width;
            if (otherRooms.Where(r => r.area.IntersectsWith(copy.area)).Count() >= 1) //There will be one because prev is included
            {
                result.Remove(Side.Bottom);
            }

            copy.Place(this, Side.Left);
            if (!boundries.Contains(copy.area))
            {
                result.Remove(Side.Left);
            }
            copy.Place(this, Side.Right);
            if (!boundries.Contains(copy.area))
            {
                result.Remove(Side.Right);
            }
            copy.Place(this, Side.Top);
            if (!boundries.Contains(copy.area))
            {
                result.Remove(Side.Top);
            }
            copy.Place(this, Side.Bottom);
            if (!boundries.Contains(copy.area))
            {
                result.Remove(Side.Bottom);
            }


            return result;
        }

        private Room Copy()
        {
            return new Room() {area = this.area, roomObjects = this.roomObjects, roomType = this.roomType};
        }
        private Room()
        {

        }

        public static bool SharesWall(Room a, Room b)
        {
            if ((a.area.Top == b.area.Bottom) || (b.area.Top == a.area.Bottom) ||
                (a.area.Left == b.area.Right) || (b.area.Left == a.area.Right))
            {
                return true;
            }
            return false;         
        }
        public static int SharedWalls(Room a, Room b)
        {
            int result = 0;
            if (a.area.Top == b.area.Bottom) { result++; }
            if (b.area.Top == a.area.Bottom) { result++; }
            if (a.area.Left == b.area.Right) { result++; }
            if (b.area.Left == a.area.Right) { result++; }
            return result;
        }

        public Rectangle area;
        public const int KitchenWeight = 10;
        public const int DiningWeight = 20;
        public const int LoungeWeight = 40;
        public const int BathroomWeight = 60;
        public const int BedroomWeight = 100;
        public enum RoomType
        {
            Kitchen,
            Dining,
            Lounge,
            Bathroom,
            Bedroom,
            Hallway
        }
        public enum Corner
        {
            TopLeft,
            TopRight,
            BottomLeft,
            BottomRight
        }
        public enum Orientation
        {
            FaceUp,
            FaceDown,
            FaceRight,
            FaceLeft
        }
        public enum Side
        {
            Top,
            Bottom,
            Left,
            Right,
        }
        public bool IsPublic()
        {
            switch (roomType)
            {
                case RoomType.Kitchen:
                case RoomType.Dining:
                case RoomType.Lounge:
                case RoomType.Hallway:
                    return true;
                default:
                    return false;
            }
        }
        public RoomType roomType;
        public List<RoomObject> roomObjects = new List<RoomObject>();

        public Room(int stars, RoomType roomType)
        {
            this.roomType = roomType;
            PopulateRoom(stars-1, stars+2);
        }
        public void MoveTo(Rectangle dest, Corner a, Orientation b)
        {
            Point finalLocation = new Point(0,0);
            switch (a)
            {
                case Corner.TopLeft:
                    finalLocation = dest.Location; 
                    break;
                case Corner.TopRight:
                    finalLocation = new Point(dest.Location.X + dest.Width, dest.Location.Y);
                    break;
                case Corner.BottomLeft:
                    finalLocation = new Point(dest.Location.X, dest.Location.Y + dest.Height);
                    break;
                case Corner.BottomRight:
                    finalLocation = new Point(dest.Location.X + dest.Width, dest.Location.Y + dest.Height);
                    break;
            }
            switch (b)
            {
                case Orientation.FaceUp:
                    finalLocation = new Point(finalLocation.X, finalLocation.Y - area.Height);
                    break;
                case Orientation.FaceDown:
                    //Default position is facing right down
                    break;
                case Orientation.FaceRight:
                    //Default position is facing right down
                    break;
                case Orientation.FaceLeft:
                    finalLocation = new Point(finalLocation.X - area.Width, finalLocation.Y);
                    break;
            }

            area.Location = finalLocation;
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
                case RoomType.Hallway:
                    break;
                default:                                
                    roomObjects.Add(new RoomObject(r.Next(min, max), RoomObject.ApplianceType.Wall));
                    roomObjects.Add(new RoomObject(r.Next(min, max), RoomObject.ApplianceType.Lights));
                    roomObjects.Add(new RoomObject(r.Next(min, max), RoomObject.ApplianceType.Floor));
                    break;
            }
        }

        internal void Place(Room next, Side randomSide)
        {
            switch (randomSide)
            {
                case Side.Top:
                    MoveTo(next.area, Corner.TopLeft, Orientation.FaceUp);
                    break;
                case Side.Bottom:
                    MoveTo(next.area, Corner.BottomLeft, Orientation.FaceDown);
                    break;
                case Side.Left:
                    MoveTo(next.area, Corner.TopLeft, Orientation.FaceLeft);
                    break;
                case Side.Right:
                    MoveTo(next.area, Corner.TopRight, Orientation.FaceRight);
                    break;
            }
        }
    }
    public class Rooms : List<Room>
    {
        public Room hallway;

        public Rooms(Room hallway, List<Room> rooms)
        {
            this.hallway = hallway;
            foreach (var r in rooms)
            {
                Add(r);
            }
        }
        public Rooms() { }
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

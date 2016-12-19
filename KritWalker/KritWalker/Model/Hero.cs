using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Animation;

namespace KritWalker.Model
{
    public class Hero
    {
        public List<Room> PassedRooms = new List<Room>();

        public List<Coordinates> journey = new List<Coordinates>();

        public Room Goal = new Room();
        
        public Hero(Room room)
        {
            Goal = room;
        }        

        public string MoveToNextRoom(Room newRoom)
        {            
            foreach (Room room in PassedRooms)
            {
                if (room.Equals(newRoom))
                {
                    journey.Remove(journey[journey.Count-1]);
                    return "Dead end";
                }
            }
            PassedRooms.Add(newRoom);
            journey.Add(new Coordinates { X = newRoom.XCoord, Y = newRoom.YCoord });

            if (Goal.Equals(newRoom))
            {                
                return "Finish";
            }

            foreach (Room room in newRoom.AdjacentRooms)
            {                
                if (MoveToNextRoom(room)=="Finish") return "Finish";
                journey.Add(new Coordinates { X = newRoom.XCoord, Y = newRoom.YCoord });
            }
            PassedRooms.Remove(newRoom);            
            return "Dead end";
        }

    }
}
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

namespace KritWalker.Model
{
    public class Room
    {
        public List<Room> AdjacentRooms = new List<Room>();

        public int XCoord;

        public int YCoord;

    }
}
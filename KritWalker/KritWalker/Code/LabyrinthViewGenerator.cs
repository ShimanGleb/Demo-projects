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
using KritWalker.Model;

namespace KritWalker.Code
{
    public static class LabyrinthViewGenerator
    {
        public static void Generate(Labyrinth labyrinth, GridLayout layout, Context context)
        {            
            foreach (Room room in labyrinth.Rooms)
            {
                ImageView cell = new ImageView(context);

                cell.SetImageResource(Resource.Drawable.Cell);

                if (room.AdjacentRooms.Count == 1)
                {
                    int direction = 0;

                    foreach (Room adjacent in room.AdjacentRooms)
                    {
                        if (adjacent.XCoord > room.XCoord) direction += 3;
                        if (adjacent.XCoord < room.XCoord) direction += 8;
                        if (adjacent.YCoord > room.YCoord) direction += 4;
                        if (adjacent.YCoord < room.YCoord) direction += 2;
                    }

                    if (direction == 3) cell.Rotation = -90;
                    if (direction == 8) cell.Rotation = 90;
                    if (direction == 4) cell.Rotation = 0;
                    if (direction == 2) cell.Rotation = 180;

                    cell.SetImageResource(Resource.Drawable.ThreeBound);
                }

                if (room.AdjacentRooms.Count == 2)
                {
                    int direction = 0;

                    foreach (Room adjacent in room.AdjacentRooms)
                    {
                        if (adjacent.XCoord > room.XCoord) direction += 3;
                        if (adjacent.XCoord < room.XCoord) direction += 8;
                        if (adjacent.YCoord > room.YCoord) direction += 4;
                        if (adjacent.YCoord < room.YCoord) direction += 2;
                    }

                    if (direction == 10) cell.Rotation = 90;
                    if (direction == 7 || direction == 11) cell.Rotation = -90;
                    if (direction == 5) cell.Rotation = 180;
                    if (direction == 12) cell.Rotation = 0;

                    if (room.AdjacentRooms[0].XCoord == room.AdjacentRooms[1].XCoord ||
                                room.AdjacentRooms[0].YCoord == room.AdjacentRooms[1].YCoord)
                    {
                        cell.SetImageResource(Resource.Drawable.TwoBoundPar);
                    }
                    else
                    {
                        cell.SetImageResource(Resource.Drawable.TwoBoundCor);
                    }
                }

                if (room.AdjacentRooms.Count == 3)
                {
                    int direction = 0;

                    foreach (Room adjacent in room.AdjacentRooms)
                    {                        
                        if (adjacent.XCoord > room.XCoord) direction += 3;
                        if (adjacent.XCoord < room.XCoord) direction += 8;
                        if (adjacent.YCoord > room.YCoord) direction += 4;
                        if (adjacent.YCoord < room.YCoord) direction += 2;
                    }
                                      
                    if (direction == 15) cell.Rotation = -90;
                    if (direction == 14) cell.Rotation = 0;
                    if (direction == 13) cell.Rotation = 90;
                    if (direction == 9) cell.Rotation = 180;

                    cell.SetImageResource(Resource.Drawable.OneBound);
                }
                if (room == labyrinth.Finish)
                {
                    cell.SetImageResource(Resource.Drawable.Cell);
                }

                cell.TranslationX = room.XCoord;
                cell.TranslationY = room.YCoord;

                layout.AddView(cell);
            }
        }
    }
}
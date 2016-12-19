using Android.Content;
using Android.Content.Res;
using KritWalker.Model;
using System;
using System.IO;

namespace KritWalker.Code
{
    public class LabyrinthGenerator
    {        
        public static Labyrinth GenerateLabyrinth(string labyrinthName, Context context)
        {
            Labyrinth labyrinth = new Labyrinth();

            AssetManager assets = context.Assets;

            string[] data = null;

            using (StreamReader sr = new StreamReader(assets.Open(labyrinthName)))
            {
                data = sr.ReadToEnd().Split('\n');
                for (int i=0; i< data.Length; i++)
                {
                    data[i] = data[i].Split('\r')[0];
                }
            }

            for (int i=1; i<data.Length; i++)
            {
                Room room = new Room { XCoord = Convert.ToInt32(data[i].Split(' ')[0]), YCoord = Convert.ToInt32(data[i].Split(' ')[1]) };
                labyrinth.Rooms.Add(room);
            }

            for (int i=1; i<data.Length; i++)
            {
                string[] adjacentRooms = data[i].Split(' ');

                for (int j = 2; j < adjacentRooms.Length; j++)
                {
                    labyrinth.Rooms[i - 1].AdjacentRooms.Add(labyrinth.Rooms[Convert.ToInt32(adjacentRooms[j])]);
                }                
            }

            labyrinth.Start = labyrinth.Rooms[Convert.ToInt32(data[0].Split(' ')[0])];
            labyrinth.Finish = labyrinth.Rooms[Convert.ToInt32(data[0].Split(' ')[1])];

            return labyrinth;
        }
    }
}
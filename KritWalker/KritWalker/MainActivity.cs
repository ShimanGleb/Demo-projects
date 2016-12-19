using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using KritWalker.Model;
using KritWalker.Code;
using Android.Animation;
using Android.Views.Animations;
using static Android.Views.ViewGroup;
using Java.Lang;
using System.Collections.Generic;

namespace KritWalker
{
    [Activity(Label = "KritWalker", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Labyrinth labyrinth = null;

        string labyrinthName = "Labyrinth1.txt";

        int iterator = 0;

        int time = 0;

        ImageView heroImage;

        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutInt("iterator", iterator);
            outState.PutInt("time", time);
            outState.PutFloat("HeroPositionX", heroImage.TranslationX);
            outState.PutFloat("HeroPositionY", heroImage.TranslationY);
            base.OnSaveInstanceState(outState);
        }

        protected override void OnCreate(Bundle bundle)
        {            
            base.OnCreate(bundle);

            labyrinth = LabyrinthGenerator.GenerateLabyrinth(labyrinthName, this);

            SetContentView(Resource.Layout.Main);

            GridLayout layout = FindViewById<GridLayout>(Resource.Id.gridLayout1);

            LabyrinthViewGenerator.Generate(labyrinth,layout,this);

            heroImage = FindViewById<ImageView>(Resource.Id.imageView1);

            if (bundle != null)
            {
                time = bundle.GetInt("time");
                iterator = bundle.GetInt("iterator");
                heroImage.TranslationX = bundle.GetFloat("HeroPositionX");

                var surfaceOrientation = WindowManager.DefaultDisplay.Rotation;
                if (surfaceOrientation == SurfaceOrientation.Rotation0 || surfaceOrientation == SurfaceOrientation.Rotation180)
                {
                    heroImage.TranslationX += 350;
                }
                else
                {
                    heroImage.TranslationX -= 350;
                }

                heroImage.TranslationY = bundle.GetFloat("HeroPositionY");
            }
            else
            {
                var surfaceOrientation = WindowManager.DefaultDisplay.Rotation;
                if (surfaceOrientation == SurfaceOrientation.Rotation0 || surfaceOrientation == SurfaceOrientation.Rotation180)
                {
                    heroImage.TranslationX = -460 + labyrinth.Start.XCoord * 150;
                }
                else
                {
                    heroImage.TranslationX = -810 + labyrinth.Start.XCoord * 150;
                }
                heroImage.TranslationY = labyrinth.Start.YCoord * 150 + 40;
            }
            Hero hero = new Hero(labyrinth.Finish);
            
            hero.MoveToNextRoom(labyrinth.Start);

            List<Coordinates> journey = hero.journey;

            ValueAnimator animator = ValueAnimator.OfInt(0, 10);

            animator.SetDuration(1000 * journey.Count);
          
            animator.Update += (object sender, ValueAnimator.AnimatorUpdateEventArgs e) =>
            {
                float shift = 15;

                if (iterator == journey.Count - 1)
                {                                 
                    return;                                            
                }
                
                if (journey[iterator].X < journey[iterator+1].X)
                {
                    heroImage.TranslationX += shift;
                }
                if (journey[iterator].X > journey[iterator + 1].X)
                {
                    heroImage.TranslationX -= shift;
                }
                if (journey[iterator].Y < journey[iterator + 1].Y)
                {
                    heroImage.TranslationY += shift;
                }
                if (journey[iterator].Y > journey[iterator + 1].Y)
                {
                    heroImage.TranslationY -= shift;
                }
                
                if (time++ > 8)
                {
                    iterator++;
                    time = 0;                                                      
                }
            };

            animator.Start();
        }
    }
}


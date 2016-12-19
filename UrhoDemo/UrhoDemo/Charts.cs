using System.Collections.Generic;
using System.Linq;

using Urho;
using Urho.Resources;

namespace UrhoDemo
{
    public class Charts : Application
    {
        bool movementsEnabled;
        Scene scene;
        Node plotNode;
        Camera camera;
        Octree octree;
        List<Bar> bars;
        List<DeltaBox> deltas;
        List<Cylinder> cylinders;
        List<float> barValues;
        public Bar SelectedBar { get; private set; }

        public IEnumerable<Bar> Bars => bars;

        public Charts(ApplicationOptions options = null) : base(new ApplicationOptions(assetsFolder: "Data") { Height = 1024, Width = 576, Orientation = ApplicationOptions.OrientationType.Portrait }) { }

        protected override void Start()
        {
            base.Start();
            CreateScene();
            SetupViewport();
        }

        void CreateScene()
        {
            Input.SubscribeToTouchEnd(OnTouched);
            var cache = ResourceCache;
            scene = new Scene();
            octree = scene.CreateComponent<Octree>();
            plotNode = scene.CreateChild();
            var cameraNode = scene.CreateChild("camera");
            camera = cameraNode.CreateComponent<Camera>();
            cameraNode.Position = new Vector3(20, 30, 20) / 1.75f;
            cameraNode.Rotation = new Quaternion(-0.121f, 0.878f, -0.305f, -0.35f);
            plotNode.Rotate(new Quaternion(2f, -90, 0), 0);
            Node lightNode = cameraNode.CreateChild(name: "light");
            var light = lightNode.CreateComponent<Light>();
            light.LightType = LightType.Point;
            light.Range = 100;
            light.Brightness = 0.7f;

            int size = 3;
            int values = 4;
            float maxY = 10;
            for (int i = 0; i < values; i++)
            {
                var sectionX = plotNode.CreateChild().CreateChild();
                var planeX = sectionX.CreateComponent<StaticModel>();
                planeX.Model = ResourceCache.GetModel("Models/Box.mdl");
                sectionX.Position = new Vector3(size * size * (-1) + size - 0.8f, (maxY / values) * i + (maxY / values / 2), 0);
                sectionX.Scale = new Vector3(maxY / values, 0.2f, 8);
                sectionX.Rotate(new Quaternion(0, 0, -90), 0);

                planeX.SetMaterial(cache.GetMaterial("Materials/Wall.xml").Clone(""));
            }
            var deltaColor = new Color(RandomHelper.NextRandom(), RandomHelper.NextRandom(), RandomHelper.NextRandom(), 1);
            deltas = new List<DeltaBox>();
            bars = new List<Bar>(size * size);
            cylinders = new List<Cylinder>(size * size);
            barValues = new List<float>();
            for (int i = 0; i < 9; i++)
            {
                float barValue = RandomHelper.NextRandom(1.0f, 5.0f);
                barValues.Add(barValue);
                var boxNode = plotNode.CreateChild();
                boxNode.Position = new Vector3(size / 2f - i * 1.5f + size * size * 0.5f, 0, size / 4f);
                boxNode.Rotate(new Quaternion(0, 180, 0), 0);
                var box = new Bar(new Color(RandomHelper.NextRandom(), RandomHelper.NextRandom(), RandomHelper.NextRandom(), 0.5f));
                boxNode.AddComponent(box);
                box.SetValueWithAnimation(barValue);
                bars.Add(box);
                var sectionY = plotNode.CreateChild().CreateChild();
                var planeY = sectionY.CreateComponent<StaticModel>();
                planeY.Model = ResourceCache.GetModel("Models/Box.mdl");

                planeY.SetMaterial(cache.GetMaterial("Materials/Wall.xml").Clone(""));

                sectionY.Position = new Vector3(boxNode.Position.X, 0, 0);
                sectionY.Scale = new Vector3(boxNode.Scale.X + 0.5f, 0.2f, 8);
                for (int j = 0; j < values; j++)
                {
                    var sectionZ = plotNode.CreateChild().CreateChild();
                    var planeZ = sectionZ.CreateComponent<StaticModel>();
                    planeZ.Model = ResourceCache.GetModel("Models/Box.mdl");
                    sectionZ.Position = new Vector3(boxNode.Position.X, (maxY / values) * j + (maxY / values) / 2, sectionY.Scale.Z / 2 + 0.1f);
                    sectionZ.Scale = new Vector3(sectionY.Scale.X, maxY / values, 0.2f);

                    planeZ.SetMaterial(cache.GetMaterial("Materials/Wall.xml").Clone(""));
                }
                if (i != 0)
                {
                    var valueNode = plotNode.CreateChild();
                    valueNode.Position = new Vector3(boxNode.Position.X + boxNode.Scale.X, 0, size);
                    valueNode.Scale = new Vector3(1.5f, 1, 1);
                    valueNode.Rotate(new Quaternion(0, 180, 0), 0);
                    var valueBox = new DeltaBar(deltaColor);
                    valueNode.AddComponent(valueBox);
                    var deltaNode = plotNode.CreateChild();
                    var deltaBox = new DeltaBox(deltaColor);

                    if (i == 1)
                    {
                        deltaBox.SetValues(barValues[i], barValues[i - 1]);
                    }
                    else
                    {
                        deltaBox.SetValues(barValues[i], deltas[i - 2].leftValue);
                    }

                    DeltaHelper.AdjustDelta (deltaNode, deltaBox, valueBox);

                    deltaBox.bar = valueBox;
                    deltas.Add(deltaBox);
                }

                var cylinderNode = plotNode.CreateChild();
                cylinderNode.Position = new Vector3(size / 2f - i * 1.5f + size * size * 0.5f, 0, size / 4f - 2);
                cylinderNode.Rotate(new Quaternion(0, 180, 0), 0);
                var cylinder = new Cylinder(new Color(RandomHelper.NextRandom(), RandomHelper.NextRandom(), RandomHelper.NextRandom(), 0.5f));
                cylinderNode.AddComponent(cylinder);
                cylinder.SetValueWithAnimation(barValue);
                cylinders.Add(cylinder);
                bars[bars.Count - 1].Cylinder = cylinder;
            }

            for (int i = 0; i < 9; i++) 
            {
                if (i > 0 && i < 8) 
                {
                    bars [i].SetDeltas (deltas [i], deltas [i - 1]);
                }
                if (i == 0) 
                {
                    bars [i].SetDeltas (deltas [i], null);
                }
                if (i == 8) 
                {
                    bars [i].SetDeltas (null, deltas [i-1]);
                }
            }

            SelectedBar = bars.First();
            SelectedBar.Select();
            movementsEnabled = true;
        }

        void OnTouched(TouchEndEventArgs e)
        {
            Ray cameraRay = camera.GetScreenRay((float)e.X / Graphics.Width, (float)e.Y / Graphics.Height);
            var results = octree.RaycastSingle(cameraRay, RayQueryLevel.Triangle, 100, DrawableFlags.Geometry);
            if (results != null && results.Any())
            {
                var bar = results[0].Node?.Parent?.GetComponent<Bar>();
                if (SelectedBar != bar)
                {
                    SelectedBar?.Deselect();
                    SelectedBar = bar;
                    SelectedBar?.Select();
                }
            }
        }

        protected override void OnUpdate(float timeStep)
        {
            if (Input.NumTouches >= 1 && movementsEnabled)
            {
                var touch = Input.GetTouch(0);
                plotNode.Rotate(new Quaternion(0, -touch.Delta.X, 0), TransformSpace.Local);
            }
            base.OnUpdate(timeStep);
        }

        public void Rotate(float toValue)
        {
            plotNode.Rotate(new Quaternion(0, toValue, 0), TransformSpace.Local);
        }

        void SetupViewport()
        {
            var renderer = Renderer;
            renderer.SetViewport(0, new Viewport(Context, scene, camera, null));
        }
    }    
}


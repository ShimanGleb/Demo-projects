using System;

using Urho;
using Urho.Actions;

namespace UrhoDemo
{

    public class DeltaBar : Component
    {
        public Node barNode;
        Color color;

        public DeltaBar(Color color)
        {
            this.color = color;
            ReceiveSceneUpdates = true;
        }
        public override void OnAttachedToNode(Node node)
        {
            barNode = node.CreateChild();
            barNode.Scale = new Vector3(0.5f, 0, 0.5f); //means zero height

            var cache = Application.ResourceCache;

            var model = barNode.CreateComponent<StaticModel>();

            model.Model = cache.GetModel("Models/Cube.mdl");
            model.SetMaterial(cache.GetMaterial("Materials/Triangle.xml").Clone(""));

            base.OnAttachedToNode(node);
        }

        public void SetValueWithAnimation(float value)
        {
            barNode.Scale = new Vector3(0.5f, value / 1.5f, 0.5f);
            barNode.Position = new Vector3(barNode.Position.X, barNode.Position.Y + barNode.Scale.Y, barNode.Position.Z);
        }

        protected override void OnUpdate(float timeStep)
        {
            var pos = barNode.Position;
            var scale = barNode.Scale;
            barNode.Position = new Vector3(pos.X, scale.Y / 2f, pos.Z);

            var newValue = (float)Math.Round(scale.Y, 1);

        }
        public void Deselect()
        {
            barNode.RemoveAllActions();
            barNode.RunActionsAsync(new EaseBackOut(new TintTo(1f, color.R, color.G, color.B)));
        }
        public void Select()
        {
            Selected?.Invoke(this);
            // "blinking" animation
            barNode.RunActionsAsync(new RepeatForever(new TintTo(0.3f, 1f, 1f, 1f), new TintTo(0.3f, color.R, color.G, color.B)));
        }
        public event Action<DeltaBar> Selected;
    }

    public class DeltaBox : Component
    {
        public Node deltaNode;

        public DeltaBar bar;

        public float leftValue;
        public float rightValue;
        public float valueDifference;

        string direction;

        public DeltaBox(Color color)
        {
            ReceiveSceneUpdates = true;
        }
        public void SetValues(float left, float right)
        {
            leftValue = left;
            rightValue = right;

            if (left > right)
            {
                valueDifference = left - right;
            }
            else
            {
                valueDifference = right - left;
            }
        }

        public void ChangeLeft (float value)
        {
            SetValues (value, rightValue);
            if (rightValue < leftValue && direction == "right") {
                deltaNode.Rotate (new Quaternion (0, 180, 0), 0);
                direction = "left";

            }
            if (rightValue > leftValue && direction == "left") {
                deltaNode.Rotate (new Quaternion (0, 180, 0), 0);
                direction = "right";

            }
            ScaleDelta ();
            DeltaHelper.ChangeDelta (this, bar);
        }

        public void ChangeRight (float value)
        {
            SetValues (leftValue, value);

            if (rightValue < leftValue && direction == "right")
            {
                deltaNode.Rotate (new Quaternion (0, 180, 0), 0);
                direction = "left";

            }
            if (rightValue > leftValue && direction == "left") 
            {
                deltaNode.Rotate (new Quaternion (0, 180, 0), 0);
                direction = "right";

            }
            
            ScaleDelta ();
            DeltaHelper.ChangeDelta (this, bar);
        }

        public void ScaleDelta ()
        {
            deltaNode.Scale = new Vector3 (0.5f, valueDifference / 2, 0.75f);
        }

        public override void OnAttachedToNode(Node node)
        {
            deltaNode = node.CreateChild();
            deltaNode.Scale = new Vector3(1, 0, 1);
            var cache = Application.ResourceCache;
            cache.SearchPackagesFirst = false;
            var model = deltaNode.CreateComponent<StaticModel>();

            model.Model = cache.GetModel("Models/Triangle.mdl");
            model.SetMaterial(cache.GetMaterial("Materials/Triangle.xml").Clone(""));
            model.CastShadows = false;

            if (leftValue > rightValue)
            {
                deltaNode.Rotate(new Quaternion(0, 90, 0), 0);
                direction = "left";
            }
            if (leftValue < rightValue)
            {
                deltaNode.Rotate(new Quaternion(0, -90, 0), 0);
                direction = "right";
            }
            deltaNode.Scale = new Vector3(0.5f, valueDifference / 2, 0.75f);

            base.OnAttachedToNode(node);
        }
        protected override void OnUpdate(float timeStep)
        {
            var pos = deltaNode.Position;
            var scale = deltaNode.Scale;
            deltaNode.Position = new Vector3(pos.X, scale.Y / 2f, pos.Z);
            var newValue = (float)Math.Round(scale.Y, 1);
        }
        public void SetValueWithAnimation(float value) => deltaNode.RunActionsAsync(new ScaleTo(3f, 1, value, 1));
    }
}

using System;

using Urho;
using Urho.Actions;

namespace UrhoDemo
{
    public class Cylinder : Component
    {
        Node cylinderNode;
        Color color;
        float lastUpdateValue;

        public float Value
        {
            get { return cylinderNode.Scale.Y; }
            set { cylinderNode.Scale = new Vector3(1, value < 0.3f ? 0.3f : value, 1); }
        }

        public void SetValueWithAnimation(float value) => cylinderNode.RunActionsAsync(new EaseBackOut(new ScaleTo(0, 1, value, 1)));

        public Cylinder(Color color)
        {
            this.color = new Color(0.34f, 0.32f, 0.80f);
            ReceiveSceneUpdates = true;
        }

        public override void OnAttachedToNode(Node node)
        {
            cylinderNode = node.CreateChild();
            cylinderNode.Scale = new Vector3(0.5f, 0, 0.5f); //means zero height

            var cache = Application.ResourceCache;

            var model = cylinderNode.CreateComponent<StaticModel>();

            model.Model = cache.GetModel("Models/Cylinder.mdl");
            model.SetMaterial(cache.GetMaterial("Materials/Cylinder.xml").Clone(""));

            base.OnAttachedToNode(node);
        }

        protected override void OnUpdate(float timeStep)
        {
            var pos = cylinderNode.Position;
            var scale = cylinderNode.Scale;
            cylinderNode.Position = new Vector3(pos.X, scale.Y / 2f, pos.Z);
            var newValue = (float)Math.Round(scale.Y, 1);
            lastUpdateValue = newValue;
        }

        public void Deselect()
        {
            cylinderNode.RemoveAllActions();
            cylinderNode.RunActionsAsync(new EaseBackOut(new TintTo(1f, color.R, color.G, color.B)));
        }

        public void Select()
        {
            Selected?.Invoke(this);
            // "blinking" animation
            cylinderNode.RunActionsAsync(new RepeatForever(new TintTo(0.3f, 1f, 1f, 1f), new TintTo(0.3f, color.R, color.G, color.B)));
        }

        public event Action<Cylinder> Selected;
    }
}

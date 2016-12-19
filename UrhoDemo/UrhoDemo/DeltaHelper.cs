using System;
using Urho;

namespace UrhoDemo
{
    public static class DeltaHelper
    {
        public static void AdjustDelta(Node deltaNode, DeltaBox deltaBox, DeltaBar valueBox)
        {
            var valueNode = valueBox.Node;

            if (deltaBox.leftValue > deltaBox.rightValue)
            {
                deltaNode.Position = new Vector3(valueNode.Position.X, deltaBox.rightValue - deltaNode.Scale.Y, valueNode.Position.Z);
                valueBox.SetValueWithAnimation(deltaBox.rightValue - deltaNode.Scale.Y / 4);
            }
            else
            {
                deltaNode.Position = new Vector3(valueNode.Position.X, deltaBox.leftValue - deltaNode.Scale.Y, valueNode.Position.Z);
                valueBox.SetValueWithAnimation(deltaBox.leftValue - deltaNode.Scale.Y / 4);
            }

            deltaNode.AddComponent(deltaBox);

            if (deltaBox.valueDifference < 1.0f)
            {
                var height = (1 - deltaBox.deltaNode.Scale.Y) / 3 * 2;

                if (deltaBox.valueDifference < 1 && deltaBox.valueDifference > 0.2f)
                    valueBox.SetValueWithAnimation(deltaBox.Node.Position.Y + 0.15f);
                if (deltaBox.valueDifference <= 0.5f)
                {
                    deltaNode.Position = new Vector3(deltaNode.Position.X, deltaNode.Position.Y + height, deltaNode.Position.Z);
                    valueBox.SetValueWithAnimation(deltaBox.Node.Position.Y + 0.02f);
                }
                valueBox.Node.Position = new Vector3(valueBox.Node.Position.X, valueBox.Node.Position.Y + 0.1f, valueBox.Node.Position.Z);
            }
            if (deltaBox.valueDifference > 1.0f)
            {
                var height = (deltaBox.deltaNode.Scale.Y - 1) / (-1);

                if (deltaBox.valueDifference <= 2f)
                {
                    height = (deltaBox.deltaNode.Scale.Y / 2);

                    valueBox.SetValueWithAnimation(deltaNode.Position.Y + height);
                }
                else
                {
                    if (deltaBox.valueDifference >= 3)
                    {
                        deltaBox.Node.Position = new Vector3(deltaBox.Node.Position.X, deltaBox.Node.Position.Y - (3 - deltaBox.valueDifference) * (-0.5f), deltaBox.Node.Position.Z);
                    }
                    if (deltaBox.valueDifference >= 4)
                    {
                        deltaBox.Node.Position = new Vector3(deltaBox.Node.Position.X, deltaBox.Node.Position.Y - (3 - deltaBox.valueDifference) * (-0.5f), deltaBox.Node.Position.Z);
                    }

                    valueBox.SetValueWithAnimation(deltaNode.Position.Y + deltaNode.Scale.Y / 3 * 2 + 0.2f);
                }
            }
            if (Math.Round(deltaBox.valueDifference) == 1)
            {
                var height = (1 - deltaBox.deltaNode.Scale.Y) / 3 * 2;
                deltaNode.Position = new Vector3(deltaNode.Position.X, deltaNode.Position.Y + height, deltaNode.Position.Z);
                valueBox.SetValueWithAnimation(deltaNode.Position.Y + 0.2f);
                valueBox.Node.Position = new Vector3(valueBox.Node.Position.X, valueBox.Node.Position.Y + 0.1f, valueBox.Node.Position.Z);
            }
        }

        public static void ChangeDelta(DeltaBox deltaBox, DeltaBar valueBox)
        {
            var deltaNode = deltaBox.Node;
            var valueNode = valueBox.Node;
            valueBox.Node.Position = new Vector3(valueBox.Node.Position.X, 0, valueBox.Node.Position.Z);
            if (deltaBox.leftValue > deltaBox.rightValue)
            {
                deltaNode.Position = new Vector3(valueNode.Position.X, deltaBox.rightValue - deltaNode.Scale.Y, valueNode.Position.Z);
                valueBox.SetValueWithAnimation(deltaBox.rightValue - deltaNode.Scale.Y / 4);
            }
            else
            {
                deltaNode.Position = new Vector3(valueNode.Position.X, deltaBox.leftValue - deltaNode.Scale.Y, valueNode.Position.Z);
                valueBox.SetValueWithAnimation(deltaBox.leftValue - deltaNode.Scale.Y / 4);
            }

            if (deltaBox.valueDifference < 1.0f)
            {
                var height = (1 - deltaBox.deltaNode.Scale.Y) / 3 * 2;

                if (deltaBox.valueDifference < 1 && deltaBox.valueDifference > 0.2f)
                    valueBox.SetValueWithAnimation(deltaBox.Node.Position.Y + 0.15f);
                if (deltaBox.valueDifference <= 0.5f && deltaBox.valueDifference >= 0.2f)
                {
                    deltaNode.Position = new Vector3(deltaNode.Position.X, deltaNode.Position.Y + height, deltaNode.Position.Z);
                    valueBox.SetValueWithAnimation(deltaBox.Node.Position.Y + 0.02f);
                }
                else if (deltaBox.valueDifference < 0.2f)
                {
                    deltaNode.Position = new Vector3(deltaNode.Position.X, deltaNode.Position.Y + height - 0.05f, deltaNode.Position.Z);
                    valueBox.SetValueWithAnimation(deltaBox.Node.Position.Y + 0.02f);
                }
                if (deltaBox.valueDifference < 0.7f)
                {
                    valueBox.SetValueWithAnimation(deltaBox.Node.Position.Y - 0.04f);
                }
                valueBox.Node.Position = new Vector3(valueBox.Node.Position.X, valueBox.Node.Position.Y + 0.1f, valueBox.Node.Position.Z);
            }
            if (deltaBox.valueDifference > 1.0f)
            {
                var height = (deltaBox.deltaNode.Scale.Y - 1) / (-1);

                if (deltaBox.valueDifference <= 2f)
                {
                    height = (deltaBox.deltaNode.Scale.Y / 2);

                    valueBox.SetValueWithAnimation(deltaNode.Position.Y + height + 0.15f);
                    if (deltaBox.valueDifference == 1.7f)
                    {
                        valueBox.SetValueWithAnimation(deltaNode.Position.Y + 0.15f);
                    }
                }
                else
                {
                    if (deltaBox.valueDifference >= 3)
                    {
                        deltaBox.Node.Position = new Vector3(deltaBox.Node.Position.X, deltaBox.Node.Position.Y - (3 - deltaBox.valueDifference) * (-0.5f), deltaBox.Node.Position.Z);
                    }

                    valueBox.SetValueWithAnimation(deltaNode.Position.Y + deltaNode.Scale.Y / 3 * 2 + 0.2f);

                }
            }
            if (Math.Round(deltaBox.valueDifference) == 1)
            {
                var height = (1 - deltaBox.deltaNode.Scale.Y) / 3 * 2;
                deltaNode.Position = new Vector3(deltaNode.Position.X, deltaNode.Position.Y + height, deltaNode.Position.Z);
                valueBox.SetValueWithAnimation(deltaNode.Position.Y + 0.2f);
                valueBox.Node.Position = new Vector3(valueBox.Node.Position.X, valueBox.Node.Position.Y + 0.1f, valueBox.Node.Position.Z);
            }
        }
    }
}


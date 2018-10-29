using UnityEngine;

public static class LayerList
{
    public class Layer
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public int LayerMask { get; private set; }

        public Layer(int id, string name)
        {
            ID = id;
            Name = name;
            LayerMask = CreateLayerMask(id);
        }
    }

    public static readonly Layer Default = new Layer(0, "Default");
    public static readonly Layer TransparentFX = new Layer(1, "TransparentFX");
    public static readonly Layer IgnoreRaycast = new Layer(2, "Ignore Raycast");
    public static readonly Layer Water = new Layer(4, "Water");
    public static readonly Layer UI = new Layer(5, "UI");

    public static readonly Layer FallCheck = new Layer(31, "FallCheck");

    public static int CreateLayerMask(int layer)
    {
        int layermask = 0;
        for (int i = 0; i < 32; i++)
        {
            if (!Physics2D.GetIgnoreLayerCollision(layer, i))
            {
                layermask = layermask | 1 << i;
            }
        }
        return layermask;
    }
}
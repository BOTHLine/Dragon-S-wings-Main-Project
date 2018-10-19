using UnityEngine;

public static class LayerList
{

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
using UnityEngine;

public class PhysicsIgnoreByLayers : MonoBehaviour
{
    [System.Serializable]
    public struct LayerPair
    {
        public string layer1;
        public string layer2;
    }
    public LayerPair[] layerPairs;

    void Awake()
    {
        for (int i = 0; i < layerPairs.Length; ++i)
        {
            LayerPair layerPair = layerPairs[i];
            int layer1 = LayerMask.NameToLayer(layerPair.layer1);
            int layer2 = LayerMask.NameToLayer(layerPair.layer2);
            if (layer1 >= 0 && layer1 < 32 && layer2 >= 0 && layer2 < 32)
                Physics.IgnoreLayerCollision(layer1, layer2, true);
        }
    }
}

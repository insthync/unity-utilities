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
            Physics.IgnoreLayerCollision(LayerMask.NameToLayer(layerPair.layer1), LayerMask.NameToLayer(layerPair.layer2), true);
        }
    }
}

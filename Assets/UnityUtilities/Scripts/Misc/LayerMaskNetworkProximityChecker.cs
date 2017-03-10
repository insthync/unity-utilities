using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

public class LayerMaskNetworkProximityChecker : NetworkProximityChecker
{
    public string[] maskingLayers;

    private int GetMask()
    {
        if (maskingLayers.Length == 0)
            return Physics.AllLayers;
        return LayerMask.GetMask(maskingLayers);
    }

    // function from bitbucket
    public override bool OnRebuildObservers(HashSet<NetworkConnection> observers, bool initial)
    {
        if (forceHidden)
        {
            // ensure player can still see themself
            var uv = GetComponent<NetworkIdentity>();
            if (uv.connectionToClient != null)
            {
                observers.Add(uv.connectionToClient);
            }
            return true;
        }

        // find players within range
        switch (checkMethod)
        {
            case CheckMethod.Physics3D:
                {
                    var hits = Physics.OverlapSphere(transform.position, visRange, GetMask());
                    for (int i = 0; i < hits.Length; i++)
                    {
                        var hit = hits[i];
                        // (if an object has a connectionToClient, it is a player)
                        var uv = hit.GetComponent<NetworkIdentity>();
                        if (uv != null && uv.connectionToClient != null)
                        {
                            observers.Add(uv.connectionToClient);
                        }
                    }
                    return true;
                }

            case CheckMethod.Physics2D:
                {
                    var hits = Physics2D.OverlapCircleAll(transform.position, visRange, GetMask());
                    for (int i = 0; i < hits.Length; i++)
                    {
                        var hit = hits[i];
                        // (if an object has a connectionToClient, it is a player)
                        var uv = hit.GetComponent<NetworkIdentity>();
                        if (uv != null && uv.connectionToClient != null)
                        {
                            observers.Add(uv.connectionToClient);
                        }
                    }
                    return true;
                }
        }
        return false;
    }
}

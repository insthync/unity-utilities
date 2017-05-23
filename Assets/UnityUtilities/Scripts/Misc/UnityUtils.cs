using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Networking;
public static class UnityUtils
{
    public static bool IsAnyKeyUp(KeyCode[] keys)
    {
        foreach (KeyCode key in keys)
        {
            if (Input.GetKeyUp(key))
                return true;
        }
        return false;
    }
    
    public static bool IsAnyKeyDown(KeyCode[] keys)
    {
        foreach (KeyCode key in keys)
        {
            if (Input.GetKeyDown(key))
                return true;
        }
        return false;
    }

    public static bool IsAnyKey(KeyCode[] keys)
    {
        foreach (KeyCode key in keys)
        {
            if (Input.GetKey(key))
                return true;
        }
        return false;
    }

    public static bool IsHeadless()
    {
        return SystemInfo.graphicsDeviceType == GraphicsDeviceType.Null;
    }

    public static bool TryGetGameObjectByNetId(NetworkInstanceId targetNetId, out GameObject output)
    {
        output = null;
        if (NetworkServer.active)
            output = NetworkServer.FindLocalObject(targetNetId);
        else
            output = ClientScene.FindLocalObject(targetNetId);

        if (output == null)
            return false;

        return true;
    }

    public static bool TryGetComponentByNetId<T>(NetworkInstanceId targetNetId, out T output) where T : Component
    {
        output = null;

        GameObject foundObject = null;
        if (TryGetGameObjectByNetId(targetNetId, out foundObject))
        {
            output = foundObject.GetComponent<T>();
            if (output == null)
                return false;

            return true;
        }
        return false;
    }
}

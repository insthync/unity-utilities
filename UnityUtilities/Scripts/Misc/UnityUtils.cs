using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Networking;
public static class UnityUtils
{
    /// <summary>
    /// Is any of the keys UP?
    /// </summary>
    /// <param name="keys"></param>
    /// <returns></returns>
    public static bool IsAnyKeyUp(KeyCode[] keys)
    {
        foreach (KeyCode key in keys)
        {
            if (Input.GetKeyUp(key))
                return true;
        }
        return false;
    }

    /// <summary>
    /// Is any of the keys DOWN?
    /// </summary>
    /// <param name="keys"></param>
    /// <returns></returns>
    public static bool IsAnyKeyDown(KeyCode[] keys)
    {
        foreach (KeyCode key in keys)
        {
            if (Input.GetKeyDown(key))
                return true;
        }
        return false;
    }

    /// <summary>
    /// Detect headless mode (which has graphicsDeviceType Null)
    /// </summary>
    /// <returns></returns>
    public static bool IsHeadless()
    {
        return SystemInfo.graphicsDeviceType == GraphicsDeviceType.Null;
    }

    public static bool TryGetByNetId<T>(NetworkInstanceId targetNetId, out T output) where T : Component
    {
        output = null;
        GameObject foundObject = ClientScene.FindLocalObject(targetNetId);
        if (foundObject == null)
            return false;

        output = foundObject.GetComponent<T>();
        if (output == null)
            return false;

        return true;
    }
}

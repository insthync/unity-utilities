using UnityEngine;
using UnityEngine.Events;
public static class UnityExtension
{
    /// <summary>
    /// Clone and play new particle system
    /// </summary>
    public static ParticleSystem PlayNewInstance(this ParticleSystem particleSystem)
    {
        if (particleSystem == null)
            return null;

        ParticleSystem newParticle = Object.Instantiate(particleSystem);
        newParticle.Play();
        return newParticle;
    }

    /// <summary>
    /// Call to set the particle system destroying after clip died
    /// </summary>
    public static ParticleSystem DestoryAutomatically(this ParticleSystem particleSystem)
    {
        if (particleSystem == null)
            return null;

        Object.Destroy(particleSystem.gameObject, particleSystem.main.duration);
        return particleSystem;
    }

    /// <summary>
    /// Clone and play new audio
    /// </summary>
    public static AudioSource PlayNewInstance(this AudioClip clip)
    {
        if (clip == null)
            return null;

        AudioSource newSource = new GameObject("_audio_" + clip.name).AddComponent<AudioSource>();
        newSource.clip = clip;
        newSource.Play();
        return newSource;
    }

    /// <summary>
    /// Call to set the audio source destroying after clip played
    /// </summary>
    public static AudioSource DestoryAutomatically(this AudioSource audioSource)
    {
        if (audioSource == null)
            return null;

        if (audioSource.clip == null)
        {
            Object.Destroy(audioSource.gameObject);
            return null;
        }

        Object.Destroy(audioSource.gameObject, audioSource.clip.length);
        return audioSource;
    }

    /// <summary>
    /// Find closest distance between 2 colliders like this ->
    /// |_a_|---|_b_| 
    /// Unlike Vector3.Distance(a, b) ->
    /// |_a-------b_|
    /// </summary>
    public static float ClosestDistanceBetweenColliders(this Collider a, Collider b)
    {
        if (a == null || b == null)
            return float.MaxValue;
        var posA = a.transform.position;
        var posB = b.transform.position;
        return Vector3.Distance(a.ClosestPointOnBounds(posB), b.ClosestPointOnBounds(posA));
    }

    /// <summary>
    /// Find closest distance between 2 colliders like this ->
    /// |_a-----|_b_| 
    /// Unlike Vector3.Distance(a, b) ->
    /// |_a-------b_|
    /// </summary>
    public static float ClosestDistanceToBounds(this Transform a, Collider b)
    {
        if (a == null || b == null)
            return float.MaxValue;
        var posA = a.position;
        return Vector3.Distance(b.ClosestPointOnBounds(posA), posA);
    }

    /// <summary>
    /// Turn transform to target
    /// </summary>
    public static Quaternion GetLookAtRotation(this Transform transform, Vector3 target, bool isIgnoreX = false, bool isIgnoreY = false, bool isIgnoreZ = false)
    {
        Vector3 dir = (target - transform.position).normalized;
        if (isIgnoreX)
            dir.x = 0;
        if (isIgnoreY)
            dir.y = 0;
        if (isIgnoreZ)
            dir.z = 0;
        Quaternion rotation = Quaternion.LookRotation(dir);
        return rotation;
    }

    public static void DisableUIBlockRaycasts(this GameObject gameObject)
    {
        // Canvas group allows object to ignore raycasts.
        var group = gameObject.GetComponent<CanvasGroup>();
        if (group == null)
            group = gameObject.AddComponent<CanvasGroup>();

        group.blocksRaycasts = false; // Allows rays to go through so we can hover over the empty slots.
        group.interactable = false;
    }

    public static Vector2 GetXY(this Vector3 vector)
    {
        return new Vector2(vector.x, vector.y);
    }

    public static Vector2 GetXZ(this Vector3 vector)
    {
        return new Vector2(vector.x, vector.z);
    }

    public static Vector2 GetYZ(this Vector3 vector)
    {
        return new Vector2(vector.y, vector.z);
    }

    public static bool TryGetComponent<T>(this GameObject gameObject, out T component)
    {
        component = gameObject.GetComponent<T>();
        return component != null;
    }

    public static bool TryGetComponents<T>(this GameObject gameObject, out T[] component)
    {
        component = gameObject.GetComponents<T>();
        return component != null;
    }

    public static bool TryGetComponentsInChildren<T>(this GameObject gameObject, out T[] component)
    {
        component = gameObject.GetComponentsInChildren<T>();
        return component != null;
    }

    public static bool GetComponentsInParent<T>(this GameObject gameObject, out T[] component)
    {
        component = gameObject.GetComponentsInParent<T>();
        return component != null;
    }

    /// <summary>
    /// Removes previous listeners and then adds new listener
    /// </summary>
    /// <param name="uEvent"></param>
    /// <param name="call"></param>
    public static void SetListener(this UnityEvent uEvent, UnityAction call)
    {
        uEvent.RemoveAllListeners();
        uEvent.AddListener(call);
    }

    /// <summary>
    /// Removes previous listeners and then adds new listener
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="uEvent"></param>
    /// <param name="call"></param>
    public static void SetListener<T>(this UnityEvent<T> uEvent, UnityAction<T> call)
    {
        uEvent.RemoveAllListeners();
        uEvent.AddListener(call);
    }
}

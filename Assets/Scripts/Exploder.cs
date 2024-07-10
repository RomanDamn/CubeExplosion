using UnityEngine;

public class Exploder : MonoBehaviour
{
    private int _explosionForce = 100;
    private int _explosionRadius = 20;

    public void Explode(GameObject gameObject)
    {
        if (gameObject.TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.AddExplosionForce(_explosionForce, gameObject.transform.position, _explosionRadius);
        }
    }
}

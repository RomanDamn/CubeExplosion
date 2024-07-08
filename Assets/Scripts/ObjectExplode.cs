using UnityEngine;

public class ObjectExplode : MonoBehaviour
{
    [SerializeField] private RayCast _rayCast;

    public float ExplosionSplitChance = 100f;

    private int _minCubeNumber = 2;
    private int _maxCubeNumber = 6;

    private int _explosionForce = 100;
    private int _explosionRadius = 20;

    private void OnEnable()
    {
        _rayCast.ObjectClicked += Explode;
    }

    private void OnDisable()
    {
        _rayCast.ObjectClicked -= Explode;
    }

    private void Explode(RaycastHit hit)
    {
        MeshRenderer hitMesh = hit.collider.gameObject.GetComponent<MeshRenderer>();
        Rigidbody hitRigidBody = hit.collider.gameObject.GetComponent<Rigidbody>();
        int cubeNumber = Random.Range(_minCubeNumber, _maxCubeNumber);

        if (hitMesh.gameObject == gameObject)
        {
            float splitChance = Random.Range(1f, 100f);

            if (splitChance <= ExplosionSplitChance)
            {
                GenerateCubes(hit, hitMesh, cubeNumber);
            }

            Destroy(hitMesh);
            hitRigidBody.AddExplosionForce(_explosionForce, hit.transform.position, _explosionRadius);
        }
    }

    private void GenerateCubes(RaycastHit originHit, MeshRenderer originHitMesh, int cubeNumber)
    {
        for (int i = 0; i <= cubeNumber; i++)
        {
            GameObject cube = Instantiate(originHit.collider.gameObject);
            cube.transform.position = originHitMesh.transform.position;
            cube.transform.localScale = cube.transform.localScale / 2;
            cube.GetComponent<Renderer>().material.color = Random.ColorHSV();
            cube.GetComponent<ObjectExplode>().ExplosionSplitChance = ExplosionSplitChance / 2;
        }
    }
}

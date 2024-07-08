using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 100f;
    [SerializeField] private float _explosionRadius = 5f;

    private float _cubeScale = 0.7f;
    private int _maxSpawnValue = 3;
    private float _spawnChance = 0.4f;
    private int _currentSpawnValue = 0;
    private int _maxSpawnCubes = 6;
    private int _minSpawnCubes = 2;

    private void OnMouseDown()
    {
        Explode();
    }

    private void SetDepth(int depth)
    {
        _currentSpawnValue = depth;
    }

    private void Explode()
    {
        int randomPieces = Random.Range(_minSpawnCubes, _maxSpawnCubes);

        if (_currentSpawnValue >= _maxSpawnValue)
        {
            return;
        }

        Destroy(gameObject);

        if (Random.value >= _spawnChance)
        {
            for (int i = 0; i < randomPieces; i++)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = transform.position;
                cube.transform.localScale = Vector3.one * _cubeScale;
                cube.GetComponent<Renderer>().material.color = Random.ColorHSV();

                Rigidbody rigidBody = cube.AddComponent<Rigidbody>();
                rigidBody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);

                Explosion smallSpawnCube = cube.AddComponent<Explosion>();
                smallSpawnCube._maxSpawnCubes = _maxSpawnCubes;
                smallSpawnCube._explosionForce = _explosionForce;
                smallSpawnCube._explosionRadius = _explosionRadius;
                smallSpawnCube._cubeScale = _cubeScale * 0.5f;
                smallSpawnCube.SetDepth(_currentSpawnValue + 1);
                smallSpawnCube._maxSpawnValue = _maxSpawnValue;
                smallSpawnCube._spawnChance = _spawnChance;
            }
        }

        _spawnChance += 0.2f;
    }
}

using UnityEngine;

public class SpawnSmallCubes : MonoBehaviour
{
    [SerializeField] private GameObject _PrefabCube;

    private GameObject _cube;

    private int _minSpawnCubes = 2;
    private int _maxSpawnCubes = 7;

    private Color[] colors = new Color[]
    {
        Color.red,
        Color.green,
        Color.blue,
        Color.yellow,
        Color.black
    };

    private void OnDestroy()
    {
        int smallCubesCount = Random.Range(_minSpawnCubes, _maxSpawnCubes);

        for (int i = 0; i < smallCubesCount; i++)
        {
            Vector3 spawnPosition = transform.position + Random.insideUnitSphere;

            _cube = Instantiate(_PrefabCube, spawnPosition, transform.rotation);
            _cube.GetComponent<Renderer>().material.color = colors[Random.Range(0, colors.Length)];
        }
    }
}

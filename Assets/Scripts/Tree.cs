using System.Collections;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public float Speed = 2f;
    public float Amplitude = 3f;

    public float AppleSpawnTime = 1f;

    public GameObject ApplePrefab;
    private Vector3 _treePosition;

    private void Start()
    {
        _treePosition = transform.position;
        StartCoroutine(Moving());
        StartCoroutine(AppleSpawn());
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _treePosition, Time.deltaTime * Speed);
    }

    private IEnumerator Moving()
    {
        yield return new WaitForSeconds(Random.Range(1, 3));
        _treePosition += Vector3.right * Random.Range(-Amplitude, Amplitude);
        _treePosition = new Vector3(Mathf.Clamp(_treePosition.x, -6, 6), _treePosition.y, _treePosition.z);
        StartCoroutine(Moving());
    }

    private IEnumerator AppleSpawn()
    {
        yield return new WaitForSeconds(AppleSpawnTime);
        Instantiate(ApplePrefab, transform.position + Vector3.right * Random.Range(-1.0f, 1.0f), Quaternion.identity);
        StartCoroutine(AppleSpawn());
    }
}

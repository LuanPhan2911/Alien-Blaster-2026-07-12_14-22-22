using System.Collections.Generic;
using UnityEngine;


public class BuildBrickPlatform : BaseBuild
{
    [SerializeField, Range(1, 10)] private int count = 1;
    [SerializeField] private GameObject _brickPrefab;
    [SerializeField] private List<GameObject> _brickList = new List<GameObject>();

    public override void UpdateLayout()
    {
        ClearBrick();
        CreatePlatform();

    }
    private void ClearBrick()
    {
        _brickList.Clear();
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            GameObject child = transform.GetChild(i).gameObject;
            if (child.GetComponent<Brick>() != null)
            {
                DestroyImmediate(child); // Required for Editor mode
            }
        }
    }
    private void CreatePlatform()
    {
        Vector3 spawnPos = transform.position;

        for (int i = 0; i < count; i++)
        {
            Vector3 brickPosition = spawnPos + new Vector3(i, 0, 0);
            GameObject brick = Instantiate(_brickPrefab, brickPosition, Quaternion.identity, transform);
            _brickList.Add(brick);
        }
    }
}

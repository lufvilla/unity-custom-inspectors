using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GridCube : MonoBehaviour
{
	private static List<GridCube> _gridCubes = new List<GridCube>();
	
    public Vector3 Size = Vector3.one;

	private Vector3 _lastPosition;

	private void OnEnable()
	{
		if (!_gridCubes.Contains(this))
		{
			_gridCubes.Add(this);
		}

		_lastPosition = transform.position;
	}

	private void OnDisable()
	{
		if (_gridCubes.Contains(this))
		{
			_gridCubes.Remove(this);
		}
	}

	private void Update ()
	{
		if (!Application.isEditor) return;

        var currentPosition = transform.position;
        currentPosition.x = Mathf.Round(currentPosition.x / Size.x) * Size.x;
        currentPosition.y = Mathf.Round(currentPosition.y / Size.y) * Size.y;
        currentPosition.z = Mathf.Round(currentPosition.z / Size.z) * Size.z;
		
		if (_lastPosition != currentPosition)
		{
			foreach (var gridCube in _gridCubes)
			{
				if (gridCube.transform.position == currentPosition)
				{
					currentPosition = _lastPosition;
				}
			}
			
			_lastPosition = currentPosition;
		}
		
		transform.position = currentPosition;
    }
}

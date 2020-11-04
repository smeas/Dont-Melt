using System;
using System.Linq;
using UnityEngine;
using UnityEngine.U2D;

[ExecuteInEditMode]
public class SunShadow : MonoBehaviour
{
	[SerializeField] private ChasingSun sun;
	[SerializeField] private float shadowLength;

	private new Renderer renderer;
	private MeshFilter meshFilter;
	private Mesh mesh;
	private Vector3 offset;

	private Vector3[] vertices =
	{
		new Vector2(0, 0), // top left
		new Vector2(1, 0), // top right
		new Vector2(1, -1), // bottom right
		new Vector2(0, -1), // bottom left
	};

	private int[] indices =
	{
		0, 1, 2,
		0, 2, 3,
	};

	private void Start()
	{
		if (sun == null)
		{
			GameObject sunObject = GameObject.FindGameObjectWithTag("Sun");
			sun = sunObject.GetComponent<ChasingSun>();
		}

		renderer = GetComponent<Renderer>();
		meshFilter = GetComponent<MeshFilter>();
		if (mesh == null)
		{
			mesh = new Mesh();
			meshFilter.mesh = mesh;
		}

		UpdateMesh();
	}

	private void Update()
	{
	#if UNITY_EDITOR
		if (!Application.isPlaying)
		{
			offset = new Vector2(0.7071f, -0.7071f) * shadowLength;
			UpdateMesh();
			return;
		}
	#endif

		if (sun != null && sun.isActiveAndEnabled && sun.transform.position.y > transform.position.y)
		{
			offset = sun.Direction * shadowLength;
			UpdateMesh();

			renderer.enabled = true;
		}
		else
		{
			renderer.enabled = false;
		}
	}

	private void OnValidate()
	{
		if (Math.Abs(transform.localScale.x - transform.localScale.y) > 0.001f)
		{
			Debug.LogWarning("NON UNIFORM SCALE DETECTED. EXPECT FUCKED ANGLES!");
		}
	}

	private void UpdateMesh()
	{
		vertices[2] = vertices[1] + offset;
		vertices[3] = vertices[0] + offset;

		mesh.vertices = vertices;
		mesh.triangles = indices;
		mesh.RecalculateBounds();
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{

    Mesh mesh;

    Vector3[] vertices;
    Vector2[] uvs;
    int[] triangles;


    public int xSize = 20;
    public int zSize = 20;
    public float perlinStrength = 0.1f;
    
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();

    }

    private void Update()
    {
        //UpdateMesh();  
    }

    //Originally a coroutine, used to generate the mesh over time instead of instantly
    void CreateShape()
    {
        //Creating the vertices for quads here, using the ints xSize & zSize to adjust in the inspector
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        
        for(int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++){

                float y = Mathf.PerlinNoise(x * perlinStrength, z * perlinStrength) * 2f;
                vertices[i] = new Vector3(x, y, z);
                i++;
            }

        }
        //For loop filling in the rest of the triangles for each quad, each time around vert increases by 1.
        //Filling in the rest of the triangles
        triangles = new int[xSize * zSize * 6];

        int vert = 0;
        int tris = 0;

        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {

                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;

                

            }

            vert++;
        }

        uvs = new Vector2[vertices.Length];

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {

                uvs[i] = new Vector2((float)x / xSize, (float)z / zSize);
                i++;
            }

        }
    }

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;

        mesh.triangles = triangles;

        mesh.uv = uvs;

        mesh.RecalculateNormals();

        mesh.RecalculateBounds();

        MeshCollider meshCollider = gameObject.GetComponent<MeshCollider>();

        meshCollider.sharedMesh = mesh;

        

    }

  /*  private void OnDrawGizmos()
    {
        if (vertices == null)
            return;

        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], .1f);

        }

    } */

} 

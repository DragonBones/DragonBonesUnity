// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using DragonBones.Textures;
using UnityEngine;

namespace DragonBones.Display
{
	public class UnityArmatureDisplay 
	{
		private Mesh mesh;
		private MeshFilter filter;
		private Vector3[] vertices;
		private Vector2[] uvs;
		private int[] triangles;
		private GameObject _display;
		private Color32[] colors;
	
		public GameObject Display {
		
						get { return _display;}
						set { _display = value;}
				}

		public UnityArmatureDisplay (TextureAtlas atlas)
		{
			_display = new GameObject ();
			filter = _display.AddComponent("MeshFilter") as MeshFilter;
			_display.AddComponent("MeshRenderer");
			mesh = new Mesh();
			filter.sharedMesh = mesh;
			_display.renderer.sharedMaterial = atlas.Material;

		}


		public void UpdateDisplay(List<Slot> slotList)
		{
			//TODO:submeshes clear then update

			mesh.Clear();

			int vertexIndex = 0;
			int triangleIndex = 0;
			int triangleCount = slotList.Count*6;
			vertices = new Vector3[slotList.Count*4];
			uvs = new Vector2[slotList.Count*4];
			triangles = new int[triangleCount];

			for (int i = 0; i < slotList.Count; i++) {

				Slot slot = slotList[i];
				if(!slot._isDisplayOnStage)
					continue;
				float[] slotVertices = (slot.Display as UnityBoneDisplay).Vetices;
				float[] slotUVs = (slot.Display as UnityBoneDisplay).UVs;

				vertexIndex = i * 4;
				triangleIndex  = -(i +1) * 6;

                vertices[vertexIndex] = new Vector3(slotVertices[0] / 100, slotVertices[1] / 100, -slot.ZOrder * 0.001f);  // 2d mode, z more bigger more bottom
                vertices[vertexIndex + 1] = new Vector3(slotVertices[2] / 100, slotVertices[3] / 100, -slot.ZOrder * 0.001f);
                vertices[vertexIndex + 2] = new Vector3(slotVertices[4] / 100, slotVertices[5] / 100, -slot.ZOrder * 0.001f);
                vertices[vertexIndex + 3] = new Vector3(slotVertices[6] / 100, slotVertices[7] / 100, -slot.ZOrder * 0.001f);
					
				uvs[vertexIndex] = new Vector2(slotUVs[0], slotUVs[1]);
				uvs[vertexIndex + 1] = new Vector2(slotUVs[2], slotUVs[3]);
				uvs[vertexIndex + 2] = new Vector2(slotUVs[4], slotUVs[5]);
				uvs[vertexIndex + 3] = new Vector2(slotUVs[6], slotUVs[7]);

				triangles[triangleCount  + triangleIndex] = vertexIndex;
				triangles[triangleCount  + triangleIndex + 1] = vertexIndex + 1;
				triangles[triangleCount + triangleIndex + 2] = vertexIndex + 2;
				triangles[triangleCount  + triangleIndex + 3] = vertexIndex  +2;
				triangles[triangleCount + triangleIndex + 4] = vertexIndex + 3;
				triangles[triangleCount + triangleIndex + 5] = vertexIndex + 0;

			}
			/*
			Vector3[] normals = new Vector3[slotList.Count*4];
			Vector3 normal = new Vector3(0, 0, -1);
			for (int i = 0; i < slotList.Count*4; i++)
				normals[i] = normal;
            */
			if(colors == null)
			{
			 colors = new Color32[slotList.Count*4];
			 Color32 color = new Color32();
			 color.a = 255;
			 color.r = 255;
			 color.g = 255;
			 color.b = 255;
			 for (int i = 0; i < slotList.Count*4; i++)
				colors[i] = color;
			}
			/*
			Vector4[] tangents = new Vector4[slotList.Count*4];
			Vector3 tangent = new Vector3(0, 0, 1);
			for (int i = 0; i < slotList.Count*4; i++)
				tangents[i] = tangent;
            */

			mesh.vertices = vertices;
			mesh.uv = uvs;
			mesh.triangles = triangles;
			//mesh.normals = normals;
			//mesh.tangents = tangents;
			mesh.colors32 = colors;

		}
	}
}


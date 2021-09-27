using System;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ImageWithRoundedCorners : MonoBehaviour {
	private static readonly int Props = Shader.PropertyToID("_WidthHeightRadius");

	public Material material;
	[SerializeField]
	private float radius = 150;
	[Range(0,50)]
	public float coeff = 10;

	void OnRectTransformDimensionsChange(){
		Refresh();
	}
	
	private void OnValidate(){
		Refresh();
	}

	[ContextMenu("Refresh")]
    private void Refresh(){
        radius = Screen.width / coeff - 10;
        var rect = ((RectTransform) transform).rect;
		material.SetVector(Props, new Vector4(rect.width, rect.height, radius, 0));
	}
}

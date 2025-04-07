using System.Collections.Generic;
using UnityEngine;

public class GalaxyGenerator : MonoBehaviour
{
    [SerializeField] private RectTransform canvasParent; 
    [SerializeField] private GameObject nodePrefab;      
    [SerializeField] private int nodeCount = 20;         
    [SerializeField] private int rows = 5;              
    [SerializeField] private int columns = 5;           
    [SerializeField] private Vector2 canvasSize; 
    [SerializeField] private Material _lineRendererMat;
    [SerializeField] private float _lineRendererSize;

    private List<RectTransform> nodes = new List<RectTransform>();

    private void Start()
    {
        GenerateRandomNodes();
    }

    public void GenerateRandomNodes()
    {
        float cellWidth = canvasSize.x / columns;
        float cellHeight = canvasSize.y / rows;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                if (nodes.Count >= nodeCount)
                    break;

                float x = Random.Range(col * cellWidth, (col + 1) * cellWidth) - canvasSize.x / 2;
                float y = Random.Range(row * cellHeight, (row + 1) * cellHeight) - canvasSize.y / 2;

                GameObject node = Instantiate(nodePrefab, canvasParent);
                RectTransform rect = node.GetComponent<RectTransform>();
                rect.anchoredPosition = new Vector2(x, y);

                nodes.Add(rect);
            }

            if (nodes.Count >= nodeCount)
                break;
        }

        ConnectNodes();
    }

    private void ConnectNodes()
    {
        for (int i = 0; i < nodes.Count - 1; i++)
        {
            int j = Random.Range(i + 1, nodes.Count); 
            DrawLine(nodes[i], nodes[j]);
        }
    }

    private void DrawLine(RectTransform startNode, RectTransform endNode)
    {
        GameObject line = new GameObject("Line", typeof(LineRenderer));
        LineRenderer lr = line.GetComponent<LineRenderer>();

        Vector3 startWorld = RectTransformUtility.WorldToScreenPoint(null, startNode.position);
        Vector3 endWorld = RectTransformUtility.WorldToScreenPoint(null, endNode.position);

        lr.positionCount = 2;
        lr.SetPosition(0, Camera.main.ScreenToWorldPoint(new Vector3(startWorld.x, startWorld.y, Camera.main.nearClipPlane + 0.01f)));
        lr.SetPosition(1, Camera.main.ScreenToWorldPoint(new Vector3(endWorld.x, endWorld.y, Camera.main.nearClipPlane + 0.01f)));
        lr.startWidth = _lineRendererSize;
        lr.endWidth = _lineRendererSize;
        lr.material = new Material(_lineRendererMat);
        lr.startColor = Color.white;
        lr.endColor = Color.white;
    }
}

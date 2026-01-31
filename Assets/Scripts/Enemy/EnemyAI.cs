using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //public List<NodeEditor.NodeData> pathNodes = new List<NodeEditor.NodeData>();
    //public NodeEditor.NodeData currentNode;

    //public float moveSpeed = 2f;

    //[Header("Opciones de Path")]
    //public string pathFileName = "EnemyPath.json";

    //private void Update()
    //{
    //    if (currentNode == null || pathNodes.Count == 0) return;

    //    Vector3 targetPos = new Vector3(currentNode.x, currentNode.y, 0);
    //    transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

    //    if (Vector3.Distance(transform.position, targetPos) < 0.1f)
    //    {
    //        pathNodes.RemoveAt(0);
    //        if (pathNodes.Count > 0)
    //            currentNode = pathNodes[0];
    //    }
    //}

    //// Asignar path desde NodeEditor
    //public void AssignPath(NodeEditor editor, int maxNodes = 10)
    //{
    //    if (editor.nodes.Count == 0) return;

    //    pathNodes.Clear();
    //    foreach (var node in editor.nodes)
    //    {
    //        if (node.walkable)
    //            pathNodes.Add(node);
    //        if (pathNodes.Count >= maxNodes)
    //            break;
    //    }

    //    if (pathNodes.Count > 0)
    //        currentNode = pathNodes[0];
    //}

    //// Guardar path a JSON
    //public void SavePath()
    //{
    //    List<PathNodeData> pathData = new List<PathNodeData>();
    //    foreach (var n in pathNodes)
    //        pathData.Add(new PathNodeData { x = n.x, y = n.y });

    //    string path = Path.Combine(Application.dataPath, pathFileName);
    //    string json = JsonUtility.ToJson(new PathNodeList { nodes = pathData }, true);
    //    File.WriteAllText(path, json);

    //    Debug.Log("Path guardado en: " + path);
    //}

    //// Leer path desde JSON
    //public void LoadPath()
    //{
    //    string path = Path.Combine(Application.dataPath, pathFileName);
    //    if (!File.Exists(path))
    //    {
    //        Debug.LogWarning("No se encontró path: " + path);
    //        return;
    //    }

    //    string json = File.ReadAllText(path);
    //    PathNodeList pathData = JsonUtility.FromJson<PathNodeList>(json);

    //    pathNodes.Clear();
    //    foreach (var n in pathData.nodes)
    //    {
    //        NodeEditor.NodeData node = new NodeEditor.NodeData { x = n.x, y = n.y, walkable = true };
    //        pathNodes.Add(node);
    //    }

    //    if (pathNodes.Count > 0)
    //        currentNode = pathNodes[0];

    //    Debug.Log("Path cargado desde: " + path);
    //}

    //[System.Serializable]
    //public class PathNodeData
    //{
    //    public float x, y;
    //}

    //[System.Serializable]
    //public class PathNodeList
    //{
    //    public List<PathNodeData> nodes;
    //}
}

using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEditor.Experimental.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

[EditorTool(displayName: "Custom snap move", typeof(CustomSnap))]
public class CustomSnappingTool : EditorTool
{
    public Texture2D ToolIcon;

    private Transform oldTarger;
    private CustomSnapPoint[] allPoints;
    private CustomSnapPoint[] targetPoints;

    public override GUIContent toolbarIcon
    {
        get
        {
            return new GUIContent
            {
                image = ToolIcon,
                text = "Custom snap move",
                tooltip = "Custom snap move tool"
            };
        }
    }

    public override void OnToolGUI(EditorWindow window)
    {
        Transform targetTransform = ((CustomSnap)target).transform;

        if (targetTransform != oldTarger)
        {
            PrefabStage prefabStage = PrefabStageUtility.GetPrefabStage(targetTransform.gameObject);

            if (prefabStage != null)
                allPoints = prefabStage.prefabContentsRoot.GetComponentsInChildren<CustomSnapPoint>();
            else
                allPoints = FindObjectsOfType<CustomSnapPoint>();

            targetPoints = targetTransform.GetComponentsInChildren<CustomSnapPoint>();
            oldTarger = targetTransform;
        }

        EditorGUI.BeginChangeCheck();
        Vector3 newPosition = Handles.PositionHandle(targetTransform.position, Quaternion.identity);

        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(targetTransform, name: "Move with snap tool");
            MoveWithSnapping(targetTransform, newPosition);
        }
    }

    private void MoveWithSnapping(Transform targetTransform, Vector3 newPosition)
    {
        Vector3 bestPosition = newPosition;
        float closesDistance = float.PositiveInfinity;

        foreach (CustomSnapPoint point in allPoints)
        {
            if (point.transform.parent == targetTransform) continue;

            foreach (CustomSnapPoint ownPoint in targetPoints)
            {
                Vector3 targetPosition = point.transform.position - (ownPoint.transform.position - targetTransform.position);
                float distance = Vector3.Distance(targetPosition, newPosition);

                if (distance < closesDistance)
                {
                    closesDistance = distance;
                    bestPosition = targetPosition;
                }
            }
        }

        if (closesDistance < 0.5f)
        {
            targetTransform.position = bestPosition;
        }
        else
        {
            targetTransform.position = newPosition;
        }
    }
}

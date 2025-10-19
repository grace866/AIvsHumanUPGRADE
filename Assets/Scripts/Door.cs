using UnityEngine;
using UnityEngine.AI;
using NavMeshPlus.Components;

public class Door : MonoBehaviour
{
    public SpriteRenderer doorSprite;
    public NavMeshSurface Surface2D;
    private NavMeshModifier navModifier;
    private bool isWalkable = true;
    
    private void Start()
    {
        navModifier = GetComponent<NavMeshModifier>();
        if (navModifier == null)
        {
            navModifier = gameObject.AddComponent<NavMeshModifier>();
        }
        
        // Initially set as walkable
        navModifier.overrideArea = true;
        navModifier.area = isWalkable ? 0 : 1; // 0 = walkable, 1 = not walkable
    }
    
    private void OnMouseDown()
    {
        ToggleWalkability();
    }

    public void ToggleWalkability()
    {
        isWalkable = !isWalkable;
        navModifier.overrideArea = true;
        navModifier.area = isWalkable ? 0 : 1; // 0 = walkable, 1 = not walkable
        doorSprite.color = Color.white;
        Surface2D.UpdateNavMesh(Surface2D.navMeshData);
        // Optional: Add visual feedback
        Debug.Log($"Door is now {(isWalkable ? "walkable" : "not walkable")}");
    }

    public void SetWalkable(bool walkable)
    {
        isWalkable = walkable;
        navModifier.overrideArea = true;
        navModifier.area = isWalkable ? 0 : 1; // 0 = walkable, 1 = not walkable
    }
}

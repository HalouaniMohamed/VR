using UnityEngine;

public class AutoAssignSnowballs : MonoBehaviour
{
    public GameController gameController;
    public Transform snowballsParent;

    void Start()
    {
        if (gameController != null && snowballsParent != null)
        {
            gameController.snowballStartPositions.Clear();

            foreach (Transform child in snowballsParent)
            {
                gameController.snowballStartPositions.Add(child);
            }

            Debug.Log("snowballs assigned");
        }
        else
        {
            Debug.LogWarning("snowball assign error");
        }
    }
}

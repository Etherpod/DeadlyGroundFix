using UnityEngine;

namespace DeadlyGroundFix;

public class DeadlyGroundCollision : MonoBehaviour
{
    private void OnCollisionExit2D(Collision2D other)
    {
        GetComponent<DeathZone>().OnTriggerExit2D(other.collider);
    }
}

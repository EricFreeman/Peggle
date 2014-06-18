using UnityEngine;

namespace Assets.Scripts
{
    public class TurnTowardsMouse : MonoBehaviour
    {
        void FixedUpdate()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                var hitPoint = hit.point;
                var targetDir = hitPoint - transform.position;
                float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.Rotate(0, 0, 90);
            }
        }
    }
}
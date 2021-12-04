using UnityEngine;

namespace _Camera
{
    public class FollowPlayer : MonoBehaviour
    {
        public Transform player;
        public Vector3 offset;

        // Update is called once per frame
        void Update()
        {
            Vector3 position = transform.position;
            if (player.position.x > (position.x + 18))
            {
                transform.position = new Vector3(position.x+36, position.y, position.z);
            }
            else if (player.position.x < (position.x) - 18)
            {
                transform.position = new Vector3(position.x-36, position.y, position.z);
            }
            else if (player.position.y < (position.y) - 10)
            {
                transform.position = new Vector3(position.x, position.y - 20, position.z);
            }
            else if (player.position.y > (position.y) + 10)
            {
                transform.position = new Vector3(position.x, position.y + 20, position.z);
            }
        }
    }
}

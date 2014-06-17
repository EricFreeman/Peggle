using UnityEngine;

namespace Assets.Scripts
{
    public class Board : MonoBehaviour
    {
        public int BoardSize = 10;

        void Start()
        {
            for (var x = 0; x < BoardSize; x++)
            {
                for (var y = 0; y < BoardSize; y++)
                {
                    var obj = (GameObject)Instantiate(Resources.Load("prefabs/peg"));
                    obj.transform.position = new Vector3(x, y, 0);
                }
            }
        }
    }
}
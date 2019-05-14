using UnityEngine;

namespace ScoreObjects
{
    public class Cristal : ScoreObjectBase
    {
        private void Update()
        {
            transform.eulerAngles += new Vector3(0, 2, 0);
        }

    }
}
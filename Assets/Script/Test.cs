using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pff.Homestead
{
    public class Test : MonoBehaviour
    {
        public LineRenderer line;
        public Transform point1;
        public Transform point2;

        // Start is called before the first frame update
        void Start()
        {
            line.positionCount = 3;
            Debug.LogError(line.transform.position);
            line.SetPosition(0, line.transform.position);
            line.SetPosition(1, point1.position);
            line.SetPosition(2, point2.position);
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}

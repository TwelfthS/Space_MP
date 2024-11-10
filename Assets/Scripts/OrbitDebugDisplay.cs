using UnityEngine;

// code from SebLague

[ExecuteInEditMode]
public class OrbitDebugDisplay : MonoBehaviour {

    public int numSteps = 1000;
    public float timeStep = 0.1f;
    public bool usePhysicsTimeStep;

    public bool relativeToBody;
    public Planet centralBody;
    public float width = 100;
    public bool useThickLines;

    void Start () {
        // if (Application.isPlaying) {
        //     HideOrbits ();
        // }
    }

    void Update () {

        if (!Application.isPlaying) {
            DrawOrbits ();
        }
    }

    void DrawOrbits () {
        Planet[] bodies = FindObjectsOfType<Planet> ();
        var virtualBodies = new VirtualBody[bodies.Length];
        var drawPoints = new Vector2[bodies.Length][];
        int referenceFrameIndex = 0;
        Vector2 referenceBodyInitialPosition = Vector2.zero;

        // Initialize virtual bodies (don't want to move the actual bodies)
        for (int i = 0; i < virtualBodies.Length; i++) {
            virtualBodies[i] = new VirtualBody (bodies[i]);
            drawPoints[i] = new Vector2[numSteps];

            if (bodies[i] == centralBody && relativeToBody) {
                referenceFrameIndex = i;
                referenceBodyInitialPosition = virtualBodies[i].position;
            }
        }

        // Simulate
        for (int step = 0; step < numSteps; step++) {
            Vector2 referenceBodyPosition = (relativeToBody) ? virtualBodies[referenceFrameIndex].position : Vector2.zero;
            // Update velocities
            for (int i = 0; i < virtualBodies.Length; i++) {
                virtualBodies[i].velocity += CalculateAcceleration (i, virtualBodies) * timeStep;
            }
            // Update positions
            for (int i = 0; i < virtualBodies.Length; i++) {
                Vector2 newPos = virtualBodies[i].position + virtualBodies[i].velocity * timeStep;
                virtualBodies[i].position = newPos;
                if (relativeToBody) {
                    var referenceFrameOffset = referenceBodyPosition - referenceBodyInitialPosition;
                    newPos -= referenceFrameOffset;
                }
                if (relativeToBody && i == referenceFrameIndex) {
                    newPos = referenceBodyInitialPosition;
                }
                if (newPos.y < 0.01 && newPos.y > -0.01 && newPos.x < 0) {
                    // Debug.Log("Aphelion is " + newPos.x);
                }

                drawPoints[i][step] = newPos;
            }
        }

        // Draw paths
        for (int bodyIndex = 0; bodyIndex < virtualBodies.Length; bodyIndex++) {
            var pathColour = /* bodies[bodyIndex].gameObject.GetComponentInChildren<MeshRenderer> ().sharedMaterial.color; // */ Color.white;

            // if (useThickLines) {
            //     var lineRenderer = bodies[bodyIndex].gameObject.GetComponentInChildren<LineRenderer> ();
            //     lineRenderer.enabled = true;
            //     lineRenderer.positionCount = drawPoints[bodyIndex].Length;
            //     lineRenderer.SetPositions (drawPoints[bodyIndex]);
            //     lineRenderer.startColor = pathColour;
            //     lineRenderer.endColor = pathColour;
            //     lineRenderer.widthMultiplier = width;
            // } else {
            // bool stop = false;
                for (int i = 0; i < drawPoints[bodyIndex].Length - 1 /*&& !stop */; i++) {
                    // if (i == 0) Debug.Log("Start point: " + drawPoints[bodyIndex][i]);
                    Debug.DrawLine (drawPoints[bodyIndex][i], drawPoints[bodyIndex][i + 1], pathColour);
                    // if (Mathf.Abs(drawPoints[bodyIndex][i + 1].x) - 0.5 <= 0 && Mathf.Abs(drawPoints[bodyIndex][i + 1].y) <= 0) {
                    //     stop = true;
                    // }
                }

                // Hide renderer
                // var lineRenderer = bodies[bodyIndex].gameObject.GetComponentInChildren<LineRenderer> ();
                // if (lineRenderer) {
                //     lineRenderer.enabled = false;
                // }
            // }

        }
    }

    Vector2 CalculateAcceleration (int i, VirtualBody[] virtualBodies) {
        Vector2 acceleration = Vector2.zero;
        for (int j = 0; j < virtualBodies.Length; j++) {
            if (i == j) {
                continue;
            }
            Vector2 forceDir = (virtualBodies[j].position - virtualBodies[i].position).normalized;
            float sqrDst = (virtualBodies[j].position - virtualBodies[i].position).sqrMagnitude;
            acceleration += forceDir * Globals.G * virtualBodies[j].mass / sqrDst;
        }
        return acceleration;
    }

    void HideOrbits () {
        Planet[] bodies = FindObjectsOfType<Planet> ();

        // Draw paths
        for (int bodyIndex = 0; bodyIndex < bodies.Length; bodyIndex++) {
            var lineRenderer = bodies[bodyIndex].gameObject.GetComponentInChildren<LineRenderer> ();
            lineRenderer.positionCount = 0;
        }
    }

    // void OnValidate () {
    //     if (usePhysicsTimeStep) {
    //         timeStep = Universe.physicsTimeStep;
    //     }
    // }

    class VirtualBody {
        public Vector2 position;
        public Vector2 velocity;
        public float mass;

        public VirtualBody (Planet body) {
            position = body.transform.position;
            velocity = body.initialVelocity;
            mass = body.mass;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public struct Gesture 
{
    public string name;
    public List<Vector3> fingerDatas;
    public UnityEvent onRecognized; 

}

public class GestureDetector : MonoBehaviour
{
    public float threshold = 0.1f;
    public OVRSkeleton skeleton;
    public List<Gesture> gestures;
    private List<OVRBone> fingerBones; 
    public bool debugMode = true;
    private Gesture previousGesture;

    // Start is called before the first frame update
    void Start()
    {
        fingerBones = new List<OVRBone>(skeleton.Bones);
        previousGesture = new Gesture();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && debugMode) 
        {
            Save();  
        }

        Gesture currentGesture = Recognize();
        bool hasRecognized = !currentGesture.Equals(new Gesture());

        // Check if new gesture 
        if (hasRecognized && currentGesture.Equals(previousGesture)) 
        {
            // New Gesture 
            Debug.Log("New Gesture Found : " + currentGesture.name);
            previousGesture = currentGesture;
            currentGesture.onRecognized.Invoke();
        }

    }

    void Save() 
    {
        Gesture g = new Gesture();
        g.name = "New Gesture";
        List<Vector3> data = new List<Vector3>();
        
        foreach (var bone in fingerBones) 
        {
            // finger position relative to the root
            data.Add(skeleton.transform.InverseTransformPoint(bone.Transform.position));
        }

        g.fingerDatas = data;
        gestures.Add(g);
    }

    Gesture Recognize() 
    {
        Gesture currentGesture = new Gesture();
        float currentMin = Mathf.Infinity;

        foreach (var gesture in gestures) 
        {
            float sumDistance = 0;
            bool isDiscarded = false;

            for (int i = 0; i < fingerBones.Count; i++) 
            {
                Vector3 currentData = skeleton.transform.InverseTransformPoint(fingerBones[]);
                float distance = Vector3.Distance(currentData, gesture.fingerDatas[i]);

                if (distance > threshold) 
                {
                    isDiscarded = true;
                        break;
                }

                sumDistance += distance;
            } 

            if (!isDiscarded && sumDistance < currentMin) 
            {
                currentMin = sumDistance;
                currentGesture = gesture;
            }
        }

        return currentGesture;
    }
}

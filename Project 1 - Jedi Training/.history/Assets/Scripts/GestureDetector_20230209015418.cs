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
    public OVRSkeleton skeleton;
    public List<Gesture> gestures;
    private List<OVRBone> fingerBones; 
    public bool debugMode = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetFingerBones());
        //previousGesture = new Gesture();    
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && debugMode) 
        {
            Debug.Log("Space key was pressed!")
            Save();  
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

    IEnumerator GetFingerBones()
    {
        do
        {
            fingerBones = new List<OVRBone>(skeleton.Bones);
            yield return null;

        } while (fingerBones.Count <= 0);
    }
}
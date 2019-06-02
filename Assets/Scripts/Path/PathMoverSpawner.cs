using UnityEngine;

public class PathMoverSpawner: MonoBehaviour 
{
    public GameObject Template;
    public Path FollowedPath;
    public float Speed;
    public float MaxSpeed = -1f;
    public int InstanceCount;
    public int MaxCount = -1;

    void Start() {
        int instances = MaxCount == -1 ? InstanceCount : Random.Range(InstanceCount, MaxCount); 
        float speed = MaxSpeed == -1 ? Speed : Random.Range(Speed, MaxSpeed);
        for (int i = 0; i < instances; i++) {
            GameObject obj = Instantiate(Template) as GameObject;

            obj.GetComponent<PathFollower>().MainPath = FollowedPath;
            obj.GetComponent<PathFollower>().Speed = speed;
            obj.GetComponent<PathFollower>().SetPathPosition(1f / (float)instances * (float)i);
        }
    }
}

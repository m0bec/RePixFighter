using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoolingBullet : MonoBehaviour
{
    private static PoolingBullet mInstance;
    public static PoolingBullet Instance {
        get {
            return mInstance;
        }
    }

	void Awake(){
		 if (mInstance == null) {
            mInstance = FindObjectOfType<PoolingBullet> ();
            if (mInstance == null) {
            	mInstance = new GameObject ("PoolingBullet").AddComponent<PoolingBullet> ();
            }
        }
	}

    private Dictionary<int, List<GameObject>> pooled_game_objects = new Dictionary<int, List<GameObject>> ();

    public GameObject GetGameObject (Vector3 pos_, GameObject bullet_, int bullet_color_)
    {
        int key = bullet_color_;

        if (pooled_game_objects.ContainsKey(key) == false) {
            pooled_game_objects.Add (key, new List<GameObject> ());
        }

        List<GameObject> game_objects_ = pooled_game_objects [key];

        GameObject target_object_ = null;

        for (int i = 0; i < game_objects_.Count; i++) {

            target_object_ = game_objects_ [i];

            if (target_object_.activeInHierarchy == false) {
                target_object_.SetActive (true);
				target_object_.transform.position = pos_;
				target_object_.transform.rotation = Quaternion.identity;
                return target_object_;
            }
        }

        target_object_ = Instantiate (bullet_, pos_, Quaternion.identity);

        game_objects_.Add (target_object_);

        return target_object_;
    }

    public void ReleaseGameObject (GameObject target_object_)
    {
        target_object_.SetActive (false);
    }
}
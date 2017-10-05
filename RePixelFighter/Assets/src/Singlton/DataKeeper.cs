using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataKeeper {

    private static DataKeeper mInstance;

	private DataKeeper(){}

    public static DataKeeper Instance {
        get {
            if( mInstance == null ) mInstance = new DataKeeper();

            return mInstance;
        }
    }

    void SetStartState(){
        score = 0;
        zanki = ZANKI_DEF_NUM;
    }

	int difficulty;
	public int Difficulty{
		get{  return difficulty;  }
		set{  difficulty = value;  }
	}

    bool scroll_plane_create_fin = false;
    public bool ScrollPlaneCreateFin{
        get{  return scroll_plane_create_fin;  }
        set{  scroll_plane_create_fin = value;  }
    }

    int stage_num = (int)Stage.One;
    public int StageNum{
        get{  return stage_num;  }
        set{  stage_num = value;  }
    }

    int score = 0;
    public int Score{
        get{  return score;  }
        set{  score = value;  }
    }

    const int ZANKI_DEF_NUM = 2;
    int zanki = ZANKI_DEF_NUM;
    public int Zanki{
        get{  return zanki;  }
        set{  zanki = value;  }
    }
}

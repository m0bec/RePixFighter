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

	int difficulty;
	public int Difficulty{
		get{  return difficulty;  }
		set{  difficulty = value;  }
	}
}

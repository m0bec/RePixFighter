using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVReader{
	public CreatePatternArray[] enemy_data;
	public List<CreatePatternArray> csvDatas = new List<CreatePatternArray>();
	public void CsvRead (string FileName, GameObject move_controller_, GameObject shot_controller_) {
		// csvをロード
		TextAsset csv = Resources.Load (FileName) as TextAsset;
		StringReader reader = new StringReader (csv.text);
		while (reader.Peek () > -1) {
				// ','ごとに区切って配列へ格納
				string line = reader.ReadLine ();
				string[] str_data = line.Split(',');
				CreatePatternArray pattern_array = new CreatePatternArray();
				pattern_array.type_ = int.Parse(str_data[0]);
				pattern_array.time_ = int.Parse(str_data[1]);
				pattern_array.create_pos_ = new Vector3(float.Parse(str_data[2]), float.Parse(str_data[3]), float.Parse(str_data[4]));
				pattern_array.hp_ = float.Parse(str_data[5]);
				pattern_array.score_ = int.Parse(str_data[6]);
				pattern_array.move_type_ = int.Parse(str_data[7]);
				pattern_array.shot_type_ = int.Parse(str_data[8]);
				pattern_array.bullet_type_ = int.Parse(str_data[9]);
				pattern_array.bullet_color_ = int.Parse(str_data[10]);
				pattern_array.bullet_speed_ = float.Parse(str_data[11]);
				pattern_array.move_speed_ = float.Parse(str_data[12]);
				pattern_array.enemy_move_controller_ = move_controller_;
				pattern_array.enemy_shot_controller_ = shot_controller_;
				csvDatas.Add(pattern_array);
		}	
		enemy_data = csvDatas.ToArray();
	}
}
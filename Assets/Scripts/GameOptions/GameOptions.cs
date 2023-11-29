using UnityEngine;

public class GameOptions
{
	public static int Level;
	public static int Gold;
	public static int SingleColorCount;
	public static int Gravity;
	public static int FirstRun;
	public static float BackgroundSoundsVolume;
	public static float SfxVolume;
	public static int BackgroundSoundsEnabled;
    public static int SFXEnabled;
	
	
	public static void Save()
	{
		PlayerPrefs.SetInt("Level", Level);
		PlayerPrefs.SetInt("Gold", Gold);
		PlayerPrefs.SetInt("SingleColorCount", SingleColorCount);
		PlayerPrefs.SetInt("Gravity", Gravity);
		PlayerPrefs.SetInt("BackgroundSoundsEnabled", BackgroundSoundsEnabled);
		PlayerPrefs.SetInt("SFXEnabled", SFXEnabled);
		PlayerPrefs.SetFloat("BackgroundSoundsVolume", BackgroundSoundsVolume);
		PlayerPrefs.SetFloat("SfxVolume", SfxVolume);
		PlayerPrefs.SetInt("FirstRun", FirstRun);
		
		PlayerPrefs.Save();
	}
	
	public static void Load()
	{
		Gold = PlayerPrefs.GetInt("Gold", 100);
		Level = PlayerPrefs.GetInt("Level", 1);
		SingleColorCount = PlayerPrefs.GetInt("SingleColorCount", 1);
		Gravity = PlayerPrefs.GetInt("Gravity", 0);
		BackgroundSoundsEnabled = PlayerPrefs.GetInt("BackgroundSoundsEnabled", 1);
		SFXEnabled = PlayerPrefs.GetInt("SFXEnabled", 1);
		BackgroundSoundsVolume = PlayerPrefs.GetFloat("BackgroundSoundsVolume", 1f);
		SfxVolume = PlayerPrefs.GetFloat("SfxVolume", 1f);
		FirstRun = PlayerPrefs.GetInt("FirstRun", 1);
	}

	public static void ClearData()
	{
		Level = 1;
		Gold = 100;
		SingleColorCount = 1;
		Gravity = 0;
		BackgroundSoundsEnabled = 1;
		SFXEnabled = 1;
		BackgroundSoundsVolume = 1f;
		SfxVolume = 1f;
		FirstRun = 1;
		Save();
	}
}

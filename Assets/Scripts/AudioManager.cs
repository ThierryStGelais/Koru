using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
    [Header("Jump")]
    public AudioClip Jump1;
    public AudioClip Jump2;
    public AudioClip Jump3;
    public AudioClip Jump4;
    public AudioClip Jump5;
    public AudioClip Jump6;

	[Header("Player Death")]
	public AudioClip Death1;
	public AudioClip Death2;
	public AudioClip Death3;
	public AudioClip Death4;

    [Header("Head Jump")]
    public AudioClip HeadJump1;
    public AudioClip HeadJump2;

    [Header("Throw Harpoon")]
    public AudioClip Harpoon1;
    public AudioClip Harpoon2;

    [Header("Fish Death")]
    public AudioClip FishDeath;

    [Header("Goal sound")]
    public AudioClip Goal;

    [Header("Level Lift")]
    public AudioClip Level;

    [Header("Checkpoint flame")]
    public AudioClip Checkpoint;

    [Header("Select menu")]
    public AudioClip Select;

	[Header("Win")]
	public AudioClip Win;

	[Header("GameOver")]
	public AudioClip Gameover;


    private AudioSource source;
    private int randomMusic = 0;
    private bool gameOverSoundPlay = false;

    public bool GetgameOverSoundPlay()
    {

        return gameOverSoundPlay;

    }

    public void SetgameOverSoundPlay(bool boule)
    {

        gameOverSoundPlay = boule;

    }

    // Use this for initialization
    void Start ()
    {
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void JumpSound()
    {
        randomMusic = Random.Range(0, 5);
        switch (randomMusic)
        {
            case 0:
                source.PlayOneShot(Jump1);
                break;
            case 1:
                source.PlayOneShot(Jump2);
                break;
            case 2:
                source.PlayOneShot(Jump3);
                break;
            case 3:
                source.PlayOneShot(Jump4);
                break;
            case 4:
                source.PlayOneShot(Jump5);
                break;
            case 5:
                source.PlayOneShot(Jump6);
                break;
        }
    }

	public void DeathSound()
	{
		randomMusic = Random.Range(0, 4);
		switch (randomMusic) 
		{
			case 0:
				source.PlayOneShot(Death1, 0.5F);
				break;
			case 1:
				source.PlayOneShot(Death2, 0.5F);
				break;
			case 2:
				source.PlayOneShot(Death3, 0.5F);
				break;
			case 3:
				source.PlayOneShot(Death4, 0.5F);
				break;
		}
	}

    public void FishSound()
    {
        randomMusic = Random.Range(0, 1);
        switch (randomMusic)
        {
            case 0:
                source.PlayOneShot(Harpoon1, 0.3F);
                break;
            case 1:
                source.PlayOneShot(Harpoon2, 0.3F);
                break;
        }
    }

    public void FishDeathSound()
    {
        source.PlayOneShot(FishDeath, 0.3F);
    }

    public void GoalSound()
    {
        source.PlayOneShot(Goal, 0.7F);
    }

    public void LevelLiftSound()
    {
        source.clip = Level;
        source.loop = true;
        source.Play();
    }

    public void LevelStopSound()
    {
        source.Stop();
    }

    public void CheckPointSound()
    {
        source.PlayOneShot(Checkpoint, 0.4F);
    }

    public void SelectMenuSound()
    {
        source.PlayOneShot(Select, 0.8F);
    }

	public void WinSound()
	{
		source.PlayOneShot(Win, 0.6F);
	}

	public void GameOverSound()
	{
		source.PlayOneShot(Gameover, 0.7F);
	}
}

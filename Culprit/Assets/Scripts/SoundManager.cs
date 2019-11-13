using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private const string BIG_CRASH = "big_crash";
    private const string BOTTLE_CRASH = "bottle_crash";
    private const string BOTTLE_DROP = "bottle_drop";
    private const string BOTTLE_DROP_1 = "bottle_drop1";
    private const string BOTTLE_FALL = "bottle_fall";
    private const string BOTTLE_FLY = "bottle_fly";
    private const string BOTTLE_HIT = "bottle_hit";
    private const string BOTTLE_POP = "bottle_pop";
    private const string BOTTLE_TING = "bottle_ting";
    private const string BOTTLE_TING_1 = "bottle_ting1";
    private const string CRASH = "crash";
    private const string CRASH_1 = "crash1";
    private const string FALL = "fall";
    private const string FEMALE_ANGRY = "female_angry";
    private const string FIDGE_OPEN = "fidge_open";
    private const string FIGHT_HURT = "fight_hurt";
    private const string FIGHT_HURT_2 = "fight_hurt2";
    private const string FIGHTING = "fighting";
    private const string FIGHTING_1 = "fighting1";
    private const string FIST_PUNCH = "fist_punch";
    private const string FOOTSTEP1_ROOM = "footstep1_room";
    private const string FOOTSTEP_ROOM = "footstep_room";
    private const string FOOTSTEP_STONE = "footstep_stone";
    private const string FOOTSTEPS_ROAD = "footsteps_road";
    private const string GASP = "gasp";
    private const string GLASS_BOTTLES = "glass_bottles";
    private const string HIT = "hit";
    private const string HIYA = "hiya";
    private const string KICK = "kick";
    private const string KICK_1 = "kick1";
    private const string KICK_2 = "kick2";
    private const string LAUGH = "laugh";
    private const string LAUGH_1 = "laugh1";
    private const string MALE_ANGRY = "male_angry";
    private const string MALE_ANGRY_1 = "male_angry1";
    private const string MALE_FIGHT = "male_fight";
    private const string MALE_SCREAM = "male_scream";
    private const string MALE_SCREAM_1 = "male_scream1";
    private const string MEOW = "meow";
    private const string OUGH = "Ough";
    private const string SWOOSH_SLASH = "swoosh_slash";
    private const string WHOOSCH = "whoosch";


    public AudioSource audioFX;

    public Dictionary<string, AudioClip> audioClips = new Dictionary<string, AudioClip>();

    public bool mute;
    public static SoundManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        LoadData();
    }
    public void LoadData()
    {
        AudioClip[] _audioClips = Resources.LoadAll<AudioClip>("AudioMode1");
        foreach (AudioClip clip in _audioClips)
        {
            audioClips.Add(clip.name, clip);
            Debug.Log("clip.name: " + clip.name);
        }
    }
    public void BigCrash()
    {
        audioFX.PlayOneShot(audioClips[BIG_CRASH], 1f);
    }
    public void BottleCrash()
    {
        audioFX.PlayOneShot(audioClips[BOTTLE_CRASH], 1f);
    }

    public void BottleDrop()
    {
        audioFX.PlayOneShot(audioClips[BOTTLE_DROP], 1f);
    }
    public void BottleDrop1()
    {
        audioFX.PlayOneShot(audioClips[BOTTLE_DROP_1], 1f);
    }
    public void BottleFall()
    {
        audioFX.PlayOneShot(audioClips[BOTTLE_FALL], 1f);
    }
    public void BottleFly()
    {
        audioFX.PlayOneShot(audioClips[BOTTLE_FLY], 1f);
    }
    public void BottleHit()
    {
        audioFX.PlayOneShot(audioClips[BOTTLE_HIT], 1f);
    }
    public void BottlePop()
    {
        audioFX.PlayOneShot(audioClips[BOTTLE_POP], 1f);
    }
    public void BottleTing()
    {
        audioFX.PlayOneShot(audioClips[BOTTLE_TING], 1f);
    }
    public void BottleTing1()
    {
        audioFX.PlayOneShot(audioClips[BOTTLE_TING_1], 1f);
    }
    public void Crash()
    {
        audioFX.PlayOneShot(audioClips[CRASH], 1f);
    }
    public void Crash1()
    {
        audioFX.PlayOneShot(audioClips[CRASH_1], 1f);
    }
    public void Fall()
    {
        audioFX.PlayOneShot(audioClips[FALL], 1f);
    }
    public void Female_Angry()
    {
        audioFX.PlayOneShot(audioClips[FEMALE_ANGRY], 1f);
    }
    public void Fidge_Open()
    {
        audioFX.PlayOneShot(audioClips[FIDGE_OPEN], 1f);
    }
    public void Fight_Hurt()
    {
        audioFX.PlayOneShot(audioClips[FIGHT_HURT], 1f);
    }
    public void Fight_Hurt2()
    {
        audioFX.PlayOneShot(audioClips[FIGHT_HURT_2], 1f);
    }
    public void Fighting()
    {
        audioFX.PlayOneShot(audioClips[FIGHTING], 1f);
    }
    public void Fighting1()
    {
        audioFX.PlayOneShot(audioClips[FIGHTING_1], 1f);
    }
    public void Fist_Punch()
    {
        audioFX.PlayOneShot(audioClips[FIST_PUNCH], 1f);
    }
    public void Footstep1_room()
    {
        audioFX.PlayOneShot(audioClips[FOOTSTEP1_ROOM], 1f);
    }
    public void Footstep_room()
    {
        audioFX.PlayOneShot(audioClips[FOOTSTEP_ROOM], 1f);
    }
    public void Footstep_stone()
    {
        audioFX.PlayOneShot(audioClips[FOOTSTEP_STONE], 1f);
    }
    public void Footstep_Road()
    {
        audioFX.PlayOneShot(audioClips[FOOTSTEPS_ROAD], 1f);
    }
    public void Gasp()
    {
        audioFX.PlayOneShot(audioClips[GASP], 1f);
    }
    public void Glass_bottle()
    {
        audioFX.PlayOneShot(audioClips[GLASS_BOTTLES], 1f);
    }
    public void Hit()
    {
        audioFX.PlayOneShot(audioClips[HIT], 1f);
    }
    public void Hiya()
    {
        audioFX.PlayOneShot(audioClips[HIYA], 1f);
    }
    public void Kick()
    {
        audioFX.PlayOneShot(audioClips[KICK], 1f);
    }
    public void Kick1()
    {
        audioFX.PlayOneShot(audioClips[KICK_1], 1f);
    }
    public void Kick2()
    {
        audioFX.PlayOneShot(audioClips[KICK_2], 1f);
    }
    public void Laugh()
    {
        audioFX.PlayOneShot(audioClips[LAUGH], 1f);
    }
    public void Laugh1()
    {
        audioFX.PlayOneShot(audioClips[LAUGH_1], 1f);
    }
    public void MaleAngry()
    {
        audioFX.PlayOneShot(audioClips[MALE_ANGRY], 1f);
    }
    public void MaleAngry_1()
    {
        audioFX.PlayOneShot(audioClips[MALE_ANGRY_1], 1f);
    }
    public void MaleFight()
    {
        audioFX.PlayOneShot(audioClips[MALE_FIGHT], 1f);
    }
    public void MaleScream()
    {
        audioFX.PlayOneShot(audioClips[MALE_SCREAM], 1f);
    }
    public void MaleScream1()
    {
        audioFX.PlayOneShot(audioClips[MALE_SCREAM_1], 1f);
    }
    public void Meow()
    {
        audioFX.PlayOneShot(audioClips[MEOW], 1f);
    }
    public void Ough()
    {
        audioFX.PlayOneShot(audioClips[OUGH], 1f);
    }
    public void Swoosh_slash()
    {
        audioFX.PlayOneShot(audioClips[SWOOSH_SLASH], 1f);
    }
    public void Whoosch()
    {
        audioFX.PlayOneShot(audioClips[WHOOSCH], 1f);
    }
    //--------------------------------------------



    //-------------------------------------------------------------------
    public void StopAllSound()
    {

        audioFX.Stop();
    }

    public void MuteAllSound()
    {

        audioFX.mute = true;
    }

    public void UnMuteAllSound()
    {

        audioFX.mute = false;
    }
}

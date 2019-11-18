using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource audioFX;

    public Dictionary<string, AudioClip> AudioMode1 = new Dictionary<string, AudioClip>();
    public Dictionary<string, AudioClip> AudioMode2 = new Dictionary<string, AudioClip>();

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
        AudioClip[] _AudioMode1 = Resources.LoadAll<AudioClip>("AudioMode1");     

        foreach (AudioClip clip in _AudioMode1)
        {
            AudioMode1.Add(clip.name, clip);
        }

    }
    // Audio Mode 1
    #region

    public void BigCrash()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.BIG_CRASH], 1f);
    }
    public void BottleCrash()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.BOTTLE_CRASH], 1f);
    }

    public void BottleDrop()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.BOTTLE_DROP], 1f);
    }
    public void BottleDrop1()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.BOTTLE_DROP_1], 1f);
    }
    public void BottleFall()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.BOTTLE_FALL], 1f);
    }
    public void BottleFly()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.BOTTLE_FLY], 1f);
    }
    public void BottleHit()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.BOTTLE_HIT], 1f);
    }
    public void BottlePop()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.BOTTLE_POP], 1f);
    }
    public void BottleTing()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.BOTTLE_TING], 1f);
    }
    public void BottleTing1()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.BOTTLE_TING_1], 1f);
    }
    public void Crash()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.CRASH], 1f);
    }
    public void Crash1()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.CRASH_1], 1f);
    }
    public void Fall()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.FALL], 1f);
    }
    public void Female_Angry()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.FEMALE_ANGRY], 1f);
    }
    public void Fidge_Open()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.FIDGE_OPEN], 1f);
    }
    public void Fight_Hurt()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.FIGHT_HURT], 1f);
    }
    public void Fight_Hurt2()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.FIGHT_HURT_2], 1f);
    }
    public void Fighting()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.FIGHTING], 1f);
    }
    public void Fighting1()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.FIGHTING_1], 1f);
    }
    public void Fist_Punch()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.FIST_PUNCH], 1f);
    }
    public void Footstep1_room()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.FOOTSTEP1_ROOM], 1f);
    }
    public void Footstep_room()
    {
        Debug.Log(AudioMode1[SoundKey.FOOTSTEP_ROOM]);
        audioFX.PlayOneShot(AudioMode1[SoundKey.FOOTSTEP_ROOM], 1f);
    }
    public void Footstep_stone()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.FOOTSTEP_STONE], 1f);
    }
    public void Footstep_Road()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.FOOTSTEPS_ROAD], 1f);
    }
    public void Gasp()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.GASP], 1f);
    }
    public void Glass_bottle()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.GLASS_BOTTLES], 1f);
    }
    public void Hit()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.HIT], 1f);
    }
    public void Hiya()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.HIYA], 1f);
    }
    public void Kick()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.KICK], 1f);
    }
    public void Kick1()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.KICK_1], 1f);
    }
    public void Kick2()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.KICK_2], 1f);
    }
    public void Laugh()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.LAUGH], 1f);
    }
    public void Laugh1()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.LAUGH_1], 1f);
    }
    public void MaleAngry()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.MALE_ANGRY], 1f);
    }
    public void MaleAngry_1()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.MALE_ANGRY_1], 1f);
    }
    public void MaleFight()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.MALE_FIGHT], 1f);
    }
    public void MaleScream()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.MALE_SCREAM], 1f);
    }
    public void MaleScream1()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.MALE_SCREAM_1], 1f);
    }
    public void Meow()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.MEOW], 1f);
    }
    public void Ough()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.OUGH], 1f);
    }
    public void Swoosh_slash()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.SWOOSH_SLASH], 1f);
    }
    public void Whoosch()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.WHOOSCH], 1f);
    }
    public void Rain()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.RAIN], 1f);
    }
    public void Water_Splash()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.WATER_SPLASH], 1f);
    }
    public void DogGoes()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.DOG_GOES], 1f);
    }
    public void DogJump()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.DOG_JUMP], 1f);
    }
    public void DogAngry()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.DOG_ANGRY], 1f);
    }
    public void H_A_a()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_A_A], 1f);
    }
    public void H_A_Nu()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_A_NU], 1f);
    }
    public void H_Body_Drop()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_BODY_DROP], 1f);
    }
    public void H_Chi_Tay()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_CHI_TAY], 1f);
    }
    public void H_CHUP()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_CHUP], 1f);
    }
    public void H_CRASH()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_CRASH], 1f);
    }
    public void H_CRY()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_CRY], 1f);
    }
    public void H_CUOI_GIAN()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_CUOI_GIAN], 1f);
    }
    public void H_DAM_1()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_DAM_1], 1f);
    }
    public void H_DAM_2()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_DAM_2], 1f);
    }
    public void H_DING()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_DING], 1f);
    }
    public void H_DONG()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_DONG], 1f);
    }
    public void H_DROP_1()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_DROP_1], 1f);
    }
    public void H_GAM()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_GAM], 1f);
    }
    public void H_GIAM()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_GIAM], 1f);
    }
    public void H_HA()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_HA], 1f);
    }
    public void H_HA_2()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_HA_2], 1f);
    }
    public void H_HET_3()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_HET_3], 1f);
    }
    public void H_HIT()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_HIT], 1f);
    }
    public void H_HM()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_HM], 1f);
    }
    public void H_HO()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_HO], 1f);
    }
    public void H_HU_HA()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_HU_HA], 1f);
    }
    public void H_HU_NAM()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_HU_NAM], 1f);
    }
    public void H_KISS_1()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_KISS_1], 1f);
    }
    public void H_KISS_2()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_KISS_2], 1f);
    }
    public void H_LAP_1()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_LAP_1], 1f);
    }
    public void H_LIGHT()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_LIGHT], 1f);
    }
    public void H_LIGHT_2()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_LIGHT_2], 1f);
    }
    public void H_MAN_HET()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_MAN_HET], 1f);
    }
    public void H_MAN_HET_2()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_MAN_HET_2], 1f);
    }
    public void H_MAN_THO()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_MAN_THO], 1f);
    }
    public void H_MEO_2()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_MEO_2], 1f);
    }
    public void H_MEO_3()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_MEO_3], 1f);
    }
    public void H_MUSIC_1()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_MUSIC_1], 1f);
    }
    public void H_MUSIC_2()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_MUSIC_2], 1f);
    }
    public void H_NEM()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_NEM], 1f);
    }
    public void H_NHON_CHAN()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_NHON_CHAN], 1f);
    }
    public void H_NU_GIAN()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_NU_GIAN], 1f);
    }
    public void H_NU_GIAN_2()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_NU_GIAN_2], 1f);
    }
    public void H_NU_HET()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_NU_HET], 1f);
    }
    public void H_OH_NU()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_OH_NU], 1f);
    }
    public void H_ON()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_ON], 1f);
    }
    public void H_OPEN()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_OPEN], 1f);
    }
    public void H_SCREAM()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_SCREAM], 1f);
    }
    public void H_SMILE_1()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_SMILE_1], 1f);
    }
    public void H_SWIRL()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_SWIRL], 1f);
    }
    public void H_TAT()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_TAT], 1f);
    }
    public void H_THANKS()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_THANKS], 1f);
    }
    public void H_TROLL()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_TROLL], 1f);
    }
    public void H_TRONG()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_TRONG], 1f);
    }
    public void H_UHU()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_UHU], 1f);
    }
    public void H_VEO()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_VEO], 1f);
    }
    public void H_VO()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_VO], 1f);
    }
    public void H_VO_1()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_VO_1], 1f);
    }
    public void H_VO_2()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_VO_2], 1f);
    }
    public void H_WALK_1()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_WALK_1], 1f);
    }
    public void H_WALK_2()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_WALK_2], 1f);
    }
    public void H_WATER()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_WATER], 1f);
    }
    public void H_WHOOSCH()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_WHOOSCH], 1f);
    }
    public void H_BAT_NGO()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_BAT_NGO], 1f);
    }
    public void H_NU_CUOI()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_NU_CUOI], 1f);
    }
    #endregion
    //--------------------------------------------
    public void Sound_Level(string Level)
    {
        audioFX.PlayOneShot(AudioMode1[Level], 1f);
    }
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

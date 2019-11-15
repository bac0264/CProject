using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

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
        }
    }
    // Audio Mode 1
    #region

    public void BigCrash()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.BIG_CRASH], 1f);
    }
    public void BottleCrash()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.BOTTLE_CRASH], 1f);
    }

    public void BottleDrop()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.BOTTLE_DROP], 1f);
    }
    public void BottleDrop1()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.BOTTLE_DROP_1], 1f);
    }
    public void BottleFall()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.BOTTLE_FALL], 1f);
    }
    public void BottleFly()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.BOTTLE_FLY], 1f);
    }
    public void BottleHit()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.BOTTLE_HIT], 1f);
    }
    public void BottlePop()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.BOTTLE_POP], 1f);
    }
    public void BottleTing()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.BOTTLE_TING], 1f);
    }
    public void BottleTing1()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.BOTTLE_TING_1], 1f);
    }
    public void Crash()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.CRASH], 1f);
    }
    public void Crash1()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.CRASH_1], 1f);
    }
    public void Fall()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.FALL], 1f);
    }
    public void Female_Angry()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.FEMALE_ANGRY], 1f);
    }
    public void Fidge_Open()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.FIDGE_OPEN], 1f);
    }
    public void Fight_Hurt()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.FIGHT_HURT], 1f);
    }
    public void Fight_Hurt2()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.FIGHT_HURT_2], 1f);
    }
    public void Fighting()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.FIGHTING], 1f);
    }
    public void Fighting1()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.FIGHTING_1], 1f);
    }
    public void Fist_Punch()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.FIST_PUNCH], 1f);
    }
    public void Footstep1_room()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.FOOTSTEP1_ROOM], 1f);
    }
    public void Footstep_room()
    {
        Debug.Log(audioClips[SoundKey.FOOTSTEP_ROOM]);
        audioFX.PlayOneShot(audioClips[SoundKey.FOOTSTEP_ROOM], 1f);
    }
    public void Footstep_stone()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.FOOTSTEP_STONE], 1f);
    }
    public void Footstep_Road()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.FOOTSTEPS_ROAD], 1f);
    }
    public void Gasp()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.GASP], 1f);
    }
    public void Glass_bottle()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.GLASS_BOTTLES], 1f);
    }
    public void Hit()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.HIT], 1f);
    }
    public void Hiya()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.HIYA], 1f);
    }
    public void Kick()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.KICK], 1f);
    }
    public void Kick1()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.KICK_1], 1f);
    }
    public void Kick2()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.KICK_2], 1f);
    }
    public void Laugh()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.LAUGH], 1f);
    }
    public void Laugh1()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.LAUGH_1], 1f);
    }
    public void MaleAngry()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.MALE_ANGRY], 1f);
    }
    public void MaleAngry_1()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.MALE_ANGRY_1], 1f);
    }
    public void MaleFight()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.MALE_FIGHT], 1f);
    }
    public void MaleScream()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.MALE_SCREAM], 1f);
    }
    public void MaleScream1()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.MALE_SCREAM_1], 1f);
    }
    public void Meow()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.MEOW], 1f);
    }
    public void Ough()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.OUGH], 1f);
    }
    public void Swoosh_slash()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.SWOOSH_SLASH], 1f);
    }
    public void Whoosch()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.WHOOSCH], 1f);
    }
    public void Rain()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.RAIN], 1f);
    }
    public void Water_Splash()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.WATER_SPLASH], 1f);
    }
    public void DogGoes()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.DOG_GOES], 1f);
    }
    public void DogJump()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.DOG_JUMP], 1f);
    }
    public void DogAngry()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.DOG_ANGRY], 1f);
    }
    public void H_A_a()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_A_A], 1f);
    }
    public void H_A_Nu()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_A_NU], 1f);
    }
    public void H_Body_Drop()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_BODY_DROP], 1f);
    }
    public void H_Chi_Tay()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_CHI_TAY], 1f);
    }
    public void H_CHUP()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_CHUP], 1f);
    }
    public void H_CRASH()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_CRASH], 1f);
    }
    public void H_CRY()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_CRY], 1f);
    }
    public void H_CUOI_GIAN()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_CUOI_GIAN], 1f);
    }
    public void H_DAM_1()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_DAM_1], 1f);
    }
    public void H_DAM_2()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_DAM_2], 1f);
    }
    public void H_DING()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_DING], 1f);
    }
    public void H_DONG()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_DONG], 1f);
    }
    public void H_DROP_1()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_DROP_1], 1f);
    }
    public void H_GAM()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_GAM], 1f);
    }
    public void H_GIAM()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_GIAM], 1f);
    }
    public void H_HA()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_HA], 1f);
    }
    public void H_HA_2()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_HA_2], 1f);
    }
    public void H_HET_3()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_HET_3], 1f);
    }
    public void H_HIT()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_HIT], 1f);
    }
    public void H_HM()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_HM], 1f);
    }
    public void H_HO()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_HO], 1f);
    }
    public void H_HU_HA()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_HU_HA], 1f);
    }
    public void H_HU_NAM()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_HU_NAM], 1f);
    }
    public void H_KISS_1()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_KISS_1], 1f);
    }
    public void H_KISS_2()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_KISS_2], 1f);
    }
    public void H_LAP_1()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_LAP_1], 1f);
    }
    public void H_LIGHT()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_LIGHT], 1f);
    }
    public void H_LIGHT_2()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_LIGHT_2], 1f);
    }
    public void H_MAN_HET()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_MAN_HET], 1f);
    }
    public void H_MAN_HET_2()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_MAN_HET_2], 1f);
    }
    public void H_MAN_THO()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_MAN_THO], 1f);
    }
    public void H_MEO_2()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_MEO_2], 1f);
    }
    public void H_MEO_3()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_MEO_3], 1f);
    }
    public void H_MUSIC_1()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_MUSIC_1], 1f);
    }
    public void H_MUSIC_2()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_MUSIC_2], 1f);
    }
    public void H_NEM()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_NEM], 1f);
    }
    public void H_NHON_CHAN()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_NHON_CHAN], 1f);
    }
    public void H_NU_GIAN()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_NU_GIAN], 1f);
    }
    public void H_NU_GIAN_2()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_NU_GIAN_2], 1f);
    }
    public void H_NU_HET()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_NU_HET], 1f);
    }
    public void H_OH_NU()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_OH_NU], 1f);
    }
    public void H_ON()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_ON], 1f);
    }
    public void H_OPEN()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_OPEN], 1f);
    }
    public void H_SCREAM()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_SCREAM], 1f);
    }
    public void H_SMILE_1()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_SMILE_1], 1f);
    }
    public void H_SWIRL()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_SWIRL], 1f);
    }
    public void H_TAT()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_TAT], 1f);
    }
    public void H_THANKS()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_THANKS], 1f);
    }
    public void H_TROLL()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_TROLL], 1f);
    }
    public void H_TRONG()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_TRONG], 1f);
    }
    public void H_UHU()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_UHU], 1f);
    }
    public void H_VEO()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_VEO], 1f);
    }
    public void H_VO()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_VO], 1f);
    }
    public void H_VO_1()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_VO_1], 1f);
    }
    public void H_VO_2()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_VO_2], 1f);
    }
    public void H_WALK_1()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_WALK_1], 1f);
    }
    public void H_WALK_2()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_WALK_2], 1f);
    }
    public void H_WATER()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_WATER], 1f);
    }
    public void H_WHOOSCH()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_WHOOSCH], 1f);
    }
    public void H_BAT_NGO()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_BAT_NGO], 1f);
    }
    public void H_NU_CUOI()
    {
        audioFX.PlayOneShot(audioClips[SoundKey.H_NU_CUOI], 1f);
    }
    #endregion
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

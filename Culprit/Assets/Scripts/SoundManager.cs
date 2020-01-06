using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource audioFX;

   // public Dictionary<string, AudioClip> AudioMode1 = new Dictionary<string, AudioClip>();
   // public Dictionary<string, AudioClip> AudioMode2 = new Dictionary<string, AudioClip>();

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
        //LoadData();
    }
    //public void LoadData()
    //{
    //    AudioClip[] _AudioMode1 = Resources.LoadAll<AudioClip>("AudioMode1");

    //    foreach (AudioClip clip in _AudioMode1)
    //    {
    //        AudioMode1.Add(clip.name, clip);
    //    }

    //}
    public AudioClip GetAudioMode1(string name)
    {
        string link = "AudioMode1/" + name;
        AudioClip audio = Resources.Load<AudioClip>(link);
        if (audio != null) return audio;
        return null;
    }
    // Audio Mode 1
    #region

    public void BigCrash()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.BIG_CRASH), 0.5f);
    }
    public void BottleCrash()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.BOTTLE_CRASH), 0.5f);
    }

    public void BottleDrop()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.BOTTLE_DROP), 0.5f);
    }
    public void BottleDrop1()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.BOTTLE_DROP_1), 0.5f);
    }
    public void BottleFall()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.BOTTLE_FALL), 0.5f);
    }
    public void BottleFly()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.BOTTLE_FLY), 0.5f);
    }
    public void BottleHit()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.BOTTLE_HIT), 0.5f);
    }
    public void BottlePop()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.BOTTLE_POP), 0.5f);
    }
    public void BottleTing()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.BOTTLE_TING), 0.5f);
    }
    public void BottleTing1()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.BOTTLE_TING_1), 0.5f);
    }
    public void Crash()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.CRASH), 0.5f);
    }
    public void Crash1()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.CRASH_1), 0.5f);
    }
    public void Fall()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.FALL), 0.5f);
    }
    public void Female_Angry()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.FEMALE_ANGRY), 0.5f);
    }
    public void Fidge_Open()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.FIDGE_OPEN), 0.5f);
    }
    public void Fight_Hurt()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.FIGHT_HURT), 0.5f);
    }
    public void Fight_Hurt2()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.FIGHT_HURT_2), 0.5f);
    }
    public void Fighting()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.FIGHTING), 0.5f);
    }
    public void Fighting1()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.FIGHTING_1), 0.5f);
    }
    public void Fist_Punch()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.FIST_PUNCH), 0.5f);
    }
    public void Footstep1_room()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.FOOTSTEP1_ROOM), 0.5f);
    }
    public void Footstep_room()
    {
        Debug.Log(GetAudioMode1(SoundKey.FOOTSTEP_ROOM));
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.FOOTSTEP_ROOM), 0.5f);
    }
    public void Footstep_stone()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.FOOTSTEP_STONE), 0.5f);
    }
    public void Footstep_Road()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.FOOTSTEPS_ROAD), 0.5f);
    }
    public void Gasp()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.GASP), 0.5f);
    }
    public void Glass_bottle()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.GLASS_BOTTLES), 0.5f);
    }
    public void Hit()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.HIT), 0.5f);
    }
    public void Hiya()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.HIYA), 0.5f);
    }
    public void Kick()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.KICK), 0.5f);
    }
    public void Kick1()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.KICK_1), 0.5f);
    }
    public void Kick2()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.KICK_2), 0.5f);
    }
    public void Laugh()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.LAUGH), 0.5f);
    }
    public void Laugh1()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.LAUGH_1), 0.5f);
    }
    public void MaleAngry()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.MALE_ANGRY), 0.5f);
    }
    public void MaleAngry_1()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.MALE_ANGRY_1), 0.5f);
    }
    public void MaleFight()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.MALE_FIGHT), 0.5f);
    }
    public void MaleScream()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.MALE_SCREAM), 0.5f);
    }
    public void MaleScream1()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.MALE_SCREAM_1), 0.5f);
    }
    public void Meow()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.MEOW), 0.5f);
    }
    public void Ough()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.OUGH), 0.5f);
    }
    public void Swoosh_slash()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.SWOOSH_SLASH), 0.5f);
    }
    public void Whoosch()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.WHOOSCH), 0.5f);
    }
    public void Rain()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.RAIN), 0.5f);
    }
    public void Water_Splash()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.WATER_SPLASH), 0.5f);
    }
    public void DogGoes()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.DOG_GOES), 0.5f);
    }
    public void DogJump()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.DOG_JUMP), 0.5f);
    }
    public void DogAngry()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.DOG_ANGRY), 0.5f);
    }
    public void H_A_a()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_A_A), 0.5f);
    }
    public void H_A_Nu()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_A_NU), 0.5f);
    }
    public void H_Body_Drop()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_BODY_DROP), 0.5f);
    }
    public void H_Chi_Tay()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_CHI_TAY), 0.5f);
    }
    public void H_CHUP()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_CHUP), 0.5f);
    }
    public void H_CRASH()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_CRASH), 0.5f);
    }
    public void H_CRY()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_CRY), 0.5f);
    }
    public void H_CUOI_GIAN()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_CUOI_GIAN), 0.5f);
    }
    public void H_DAM_1()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_DAM_1), 0.5f);
    }
    public void H_DAM_2()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_DAM_2), 0.5f);
    }
    public void H_DING()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_DING), 0.5f);
    }
    public void H_DONG()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_DONG), 0.5f);
    }
    public void H_DROP_1()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_DROP_1), 0.5f);
    }
    public void H_GAM()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_GAM), 0.5f);
    }
    public void H_GIAM()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_GIAM), 0.5f);
    }
    public void H_HA()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_HA), 0.5f);
    }
    public void H_HA_2()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_HA_2), 0.5f);
    }
    public void H_HET_3()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_HET_3), 0.5f);
    }
    public void H_HIT()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_HIT), 0.5f);
    }
    public void H_HM()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_HM), 0.5f);
    }
    public void H_HO()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_HO), 0.5f);
    }
    public void H_HU_HA()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_HU_HA), 0.5f);
    }
    public void H_HU_NAM()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_HU_NAM), 0.5f);
    }
    public void H_KISS_1()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_KISS_1), 0.5f);
    }
    public void H_KISS_2()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_KISS_2), 0.5f);
    }
    public void H_LAP_1()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_LAP_1), 0.5f);
    }
    public void H_LIGHT()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_LIGHT), 0.5f);
    }
    public void H_LIGHT_2()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_LIGHT_2), 0.5f);
    }
    public void H_MAN_HET()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_MAN_HET), 0.5f);
    }
    public void H_MAN_HET_2()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_MAN_HET_2), 0.5f);
    }
    public void H_MAN_THO()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_MAN_THO), 0.5f);
    }
    public void H_MEO_2()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_MEO_2), 0.5f);
    }
    public void H_MEO_3()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_MEO_3), 0.5f);
    }
    public void H_MUSIC_1()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_MUSIC_1), 0.5f);
    }
    public void H_MUSIC_2()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_MUSIC_2), 0.5f);
    }
    public void H_NEM()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_NEM), 0.5f);
    }
    public void H_NHON_CHAN()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_NHON_CHAN), 0.5f);
    }
    public void H_NU_GIAN()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_NU_GIAN), 0.5f);
    }
    public void H_NU_GIAN_2()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_NU_GIAN_2), 0.5f);
    }
    public void H_NU_HET()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_NU_HET), 0.5f);
    }
    public void H_OH_NU()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_OH_NU), 0.5f);
    }
    public void H_ON()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_ON), 0.5f);
    }
    public void H_OPEN()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_OPEN), 0.5f);
    }
    public void H_SCREAM()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_SCREAM), 0.5f);
    }
    public void H_SMILE_1()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_SMILE_1), 0.5f);
    }
    public void H_SWIRL()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_SWIRL), 0.5f);
    }
    public void H_TAT()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_TAT), 0.5f);
    }
    public void H_THANKS()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_THANKS), 0.5f);
    }
    public void H_TROLL()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_TROLL), 0.5f);
    }
    public void H_TRONG()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_TRONG), 0.5f);
    }
    public void H_UHU()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_UHU), 0.5f);
    }
    public void H_VEO()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_VEO), 0.5f);
    }
    public void H_VO()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_VO), 0.5f);
    }
    public void H_VO_1()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_VO_1), 0.5f);
    }
    public void H_VO_2()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_VO_2), 0.5f);
    }
    public void H_WALK_1()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_WALK_1), 0.5f);
    }
    public void H_WALK_2()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_WALK_2), 0.5f);
    }
    public void H_WATER()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_WATER), 0.5f);
    }
    public void H_WHOOSCH()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_WHOOSCH), 0.5f);
    }
    public void H_BAT_NGO()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_BAT_NGO), 0.5f);
    }
    public void H_NU_CUOI()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.H_NU_CUOI), 0.5f);
    }
    #endregion


    // UI Sound

    #region
    public void UI_button_Click()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.UI_button_Click), 0.5f);
    }
    public void UI_effect_Correct()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.UI_effect_Correct), 0.5f);
    }
    public void UI_effect_Pick()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.UI_effect_Pick), 0.5f);
    }
    public void UI_effect_Whoosh()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.UI_effect_Whoosh), 0.5f);
    }
    public void UI_effect_Wrong()
    {
        audioFX.PlayOneShot(GetAudioMode1(SoundKey.UI_effect_Wrong), 0.5f);
    }
    #endregion

    public void Sound_Level(string Level)
    {
        audioFX.PlayOneShot(GetAudioMode1(Level), 0.5f);
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

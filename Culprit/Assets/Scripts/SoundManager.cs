﻿using System.Collections;
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
        audioFX.PlayOneShot(AudioMode1[SoundKey.BIG_CRASH], 0.5f);
    }
    public void BottleCrash()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.BOTTLE_CRASH], 0.5f);
    }

    public void BottleDrop()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.BOTTLE_DROP], 0.5f);
    }
    public void BottleDrop1()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.BOTTLE_DROP_1], 0.5f);
    }
    public void BottleFall()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.BOTTLE_FALL], 0.5f);
    }
    public void BottleFly()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.BOTTLE_FLY], 0.5f);
    }
    public void BottleHit()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.BOTTLE_HIT], 0.5f);
    }
    public void BottlePop()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.BOTTLE_POP], 0.5f);
    }
    public void BottleTing()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.BOTTLE_TING], 0.5f);
    }
    public void BottleTing1()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.BOTTLE_TING_1], 0.5f);
    }
    public void Crash()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.CRASH], 0.5f);
    }
    public void Crash1()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.CRASH_1], 0.5f);
    }
    public void Fall()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.FALL], 0.5f);
    }
    public void Female_Angry()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.FEMALE_ANGRY], 0.5f);
    }
    public void Fidge_Open()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.FIDGE_OPEN], 0.5f);
    }
    public void Fight_Hurt()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.FIGHT_HURT], 0.5f);
    }
    public void Fight_Hurt2()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.FIGHT_HURT_2], 0.5f);
    }
    public void Fighting()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.FIGHTING], 0.5f);
    }
    public void Fighting1()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.FIGHTING_1], 0.5f);
    }
    public void Fist_Punch()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.FIST_PUNCH], 0.5f);
    }
    public void Footstep1_room()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.FOOTSTEP1_ROOM], 0.5f);
    }
    public void Footstep_room()
    {
        Debug.Log(AudioMode1[SoundKey.FOOTSTEP_ROOM]);
        audioFX.PlayOneShot(AudioMode1[SoundKey.FOOTSTEP_ROOM], 0.5f);
    }
    public void Footstep_stone()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.FOOTSTEP_STONE], 0.5f);
    }
    public void Footstep_Road()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.FOOTSTEPS_ROAD], 0.5f);
    }
    public void Gasp()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.GASP], 0.5f);
    }
    public void Glass_bottle()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.GLASS_BOTTLES], 0.5f);
    }
    public void Hit()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.HIT], 0.5f);
    }
    public void Hiya()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.HIYA], 0.5f);
    }
    public void Kick()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.KICK], 0.5f);
    }
    public void Kick1()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.KICK_1], 0.5f);
    }
    public void Kick2()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.KICK_2], 0.5f);
    }
    public void Laugh()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.LAUGH], 0.5f);
    }
    public void Laugh1()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.LAUGH_1], 0.5f);
    }
    public void MaleAngry()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.MALE_ANGRY], 0.5f);
    }
    public void MaleAngry_1()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.MALE_ANGRY_1], 0.5f);
    }
    public void MaleFight()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.MALE_FIGHT], 0.5f);
    }
    public void MaleScream()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.MALE_SCREAM], 0.5f);
    }
    public void MaleScream1()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.MALE_SCREAM_1], 0.5f);
    }
    public void Meow()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.MEOW], 0.5f);
    }
    public void Ough()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.OUGH], 0.5f);
    }
    public void Swoosh_slash()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.SWOOSH_SLASH], 0.5f);
    }
    public void Whoosch()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.WHOOSCH], 0.5f);
    }
    public void Rain()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.RAIN], 0.5f);
    }
    public void Water_Splash()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.WATER_SPLASH], 0.5f);
    }
    public void DogGoes()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.DOG_GOES], 0.5f);
    }
    public void DogJump()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.DOG_JUMP], 0.5f);
    }
    public void DogAngry()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.DOG_ANGRY], 0.5f);
    }
    public void H_A_a()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_A_A], 0.5f);
    }
    public void H_A_Nu()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_A_NU], 0.5f);
    }
    public void H_Body_Drop()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_BODY_DROP], 0.5f);
    }
    public void H_Chi_Tay()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_CHI_TAY], 0.5f);
    }
    public void H_CHUP()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_CHUP], 0.5f);
    }
    public void H_CRASH()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_CRASH], 0.5f);
    }
    public void H_CRY()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_CRY], 0.5f);
    }
    public void H_CUOI_GIAN()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_CUOI_GIAN], 0.5f);
    }
    public void H_DAM_1()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_DAM_1], 0.5f);
    }
    public void H_DAM_2()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_DAM_2], 0.5f);
    }
    public void H_DING()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_DING], 0.5f);
    }
    public void H_DONG()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_DONG], 0.5f);
    }
    public void H_DROP_1()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_DROP_1], 0.5f);
    }
    public void H_GAM()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_GAM], 0.5f);
    }
    public void H_GIAM()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_GIAM], 0.5f);
    }
    public void H_HA()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_HA], 0.5f);
    }
    public void H_HA_2()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_HA_2], 0.5f);
    }
    public void H_HET_3()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_HET_3], 0.5f);
    }
    public void H_HIT()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_HIT], 0.5f);
    }
    public void H_HM()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_HM], 0.5f);
    }
    public void H_HO()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_HO], 0.5f);
    }
    public void H_HU_HA()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_HU_HA], 0.5f);
    }
    public void H_HU_NAM()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_HU_NAM], 0.5f);
    }
    public void H_KISS_1()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_KISS_1], 0.5f);
    }
    public void H_KISS_2()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_KISS_2], 0.5f);
    }
    public void H_LAP_1()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_LAP_1], 0.5f);
    }
    public void H_LIGHT()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_LIGHT], 0.5f);
    }
    public void H_LIGHT_2()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_LIGHT_2], 0.5f);
    }
    public void H_MAN_HET()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_MAN_HET], 0.5f);
    }
    public void H_MAN_HET_2()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_MAN_HET_2], 0.5f);
    }
    public void H_MAN_THO()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_MAN_THO], 0.5f);
    }
    public void H_MEO_2()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_MEO_2], 0.5f);
    }
    public void H_MEO_3()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_MEO_3], 0.5f);
    }
    public void H_MUSIC_1()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_MUSIC_1], 0.5f);
    }
    public void H_MUSIC_2()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_MUSIC_2], 0.5f);
    }
    public void H_NEM()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_NEM], 0.5f);
    }
    public void H_NHON_CHAN()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_NHON_CHAN], 0.5f);
    }
    public void H_NU_GIAN()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_NU_GIAN], 0.5f);
    }
    public void H_NU_GIAN_2()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_NU_GIAN_2], 0.5f);
    }
    public void H_NU_HET()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_NU_HET], 0.5f);
    }
    public void H_OH_NU()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_OH_NU], 0.5f);
    }
    public void H_ON()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_ON], 0.5f);
    }
    public void H_OPEN()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_OPEN], 0.5f);
    }
    public void H_SCREAM()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_SCREAM], 0.5f);
    }
    public void H_SMILE_1()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_SMILE_1], 0.5f);
    }
    public void H_SWIRL()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_SWIRL], 0.5f);
    }
    public void H_TAT()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_TAT], 0.5f);
    }
    public void H_THANKS()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_THANKS], 0.5f);
    }
    public void H_TROLL()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_TROLL], 0.5f);
    }
    public void H_TRONG()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_TRONG], 0.5f);
    }
    public void H_UHU()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_UHU], 0.5f);
    }
    public void H_VEO()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_VEO], 0.5f);
    }
    public void H_VO()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_VO], 0.5f);
    }
    public void H_VO_1()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_VO_1], 0.5f);
    }
    public void H_VO_2()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_VO_2], 0.5f);
    }
    public void H_WALK_1()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_WALK_1], 0.5f);
    }
    public void H_WALK_2()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_WALK_2], 0.5f);
    }
    public void H_WATER()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_WATER], 0.5f);
    }
    public void H_WHOOSCH()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_WHOOSCH], 0.5f);
    }
    public void H_BAT_NGO()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_BAT_NGO], 0.5f);
    }
    public void H_NU_CUOI()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.H_NU_CUOI], 0.5f);
    }
    #endregion


    // UI Sound

    #region
    public void UI_button_Click()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.UI_button_Click], 0.5f);
    }
    public void UI_effect_Correct()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.UI_effect_Correct], 0.5f);
    }
    public void UI_effect_Pick()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.UI_effect_Pick], 0.5f);
    }
    public void UI_effect_Whoosh()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.UI_effect_Whoosh], 0.5f);
    }
    public void UI_effect_Wrong()
    {
        audioFX.PlayOneShot(AudioMode1[SoundKey.UI_effect_Wrong], 0.5f);
    }
    #endregion

    public void Sound_Level(string Level)
    {
        audioFX.PlayOneShot(AudioMode1[Level], 0.5f);
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

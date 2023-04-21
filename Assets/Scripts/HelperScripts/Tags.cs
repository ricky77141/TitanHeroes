using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagManager
{
    public const string PLAYER_TAG = "Player";
    public const string ENEMY_TAG = "Enemy";
    public const string BOSS_TAG = "Boss";
    public const string MAIN_CAMERA = "MainCamera";
}

public class AnimationTags
{
    public const string WALK_PARAMETER = "Walk";
    public const string NORMAL_ATTACK_TRIGGER = "NormalAttack";
    public const string NORMAL_ATTACK2_TRIGGER = "NormalAttack2";
    public const string SPECIAL_ATTACK1_TRIGGER = "SpecialAttack1";
    public const string SPECIAL_ATTACK2_TRIGGER = "SpecialAttack2";
    public const string SPECIAL_ATTACK3_TRIGGER = "SpecialAttack3";
    public const string DEAD_PARAMETER = "Dead";
    public const string RUN_PARAMETER = "Run";
    public const string HIT = "Hit";
    public const string IDLE_TAG = "Idle";
    public const string SLIDE_IN_ANIM = "SlideIn";
    public const string CAMERA_2_ANIM = "Camera2";
    public const string COUNT_2_ANIM = "CountDown2";
    public const string COUNT_1_ANIM = "CountDown1";
}

public class AxisManager
{
    public const string HORIZONTAL_AXIS = "Horizontal";
    public const string VERTICAL_AXIS = "Vertical";
}

public class SceneNames
{
    public const string MAIN_MENU = "MainMenu";
    public const string GAMEPLAY = "Gameplay";
}

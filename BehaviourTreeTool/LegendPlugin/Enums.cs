////////////////////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2009, Daniel Kollmann
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, are permitted
// provided that the following conditions are met:
//
// - Redistributions of source code must retain the above copyright notice, this list of conditions
//   and the following disclaimer.
//
// - Redistributions in binary form must reproduce the above copyright notice, this list of
//   conditions and the following disclaimer in the documentation and/or other materials provided
//   with the distribution.
//
// - Neither the name of Daniel Kollmann nor the names of its contributors may be used to endorse
//   or promote products derived from this software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR
// IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,
// WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY
// WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
////////////////////////////////////////////////////////////////////////////////////////////////////

/*
 * 
 * LegendPlugin was created by Matt Filer
 * www.mattfiler.co.uk
 * 
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace LegendPlugin
{
    // NOTE:
    //   These indexes are WRONG, but we don't need to worry about them - all enums are matched as string.
    //   Worth noting that not all enum values here may be supported in the shipped game, hence the incorrect indexes.

    public enum BEHAVIOR_TREE_BRANCH_TYPE
    {
        NONE,
        CINEMATIC_BRANCH,
        ATTACK_BRANCH,
        AIM_BRANCH,
        DESPAWN_BRANCH,
        FOLLOW_BRANCH,
        STANDARD_BRANCH,
        SEARCH_BRANCH,
        AREA_SWEEP_BRANCH,
        BACKSTAGE_AREA_SWEEP_BRANCH,
        SHOT_BRANCH,
        SUSPECT_TARGET_RESPONSE_BRANCH,
        THREAT_AWARE_BRANCH,
        BACKSTAGE_AMBUSH_BRANCH,
        IDLE_JOB_BRANCH,
        USE_COVER_BRANCH,
        ASSAULT_BRANCH,
        MELEE_BRANCH,
        RETREAT_BRANCH,
        CLOSE_ON_TARGET_BRANCH,
        MUTUAL_MELEE_ONLY_BRANCH,
        VENT_MELEE_BRANCH,
        ASSAULT_NOT_ALLOWED_BRANCH,
        IN_VENT_BRANCH,
        CLOSE_COMBAT_BRANCH,
        DRAW_WEAPON_BRANCH,
        PURSUE_TARGET_BRANCH,
        RANGED_ATTACK_BRANCH,
        RANGED_COMBAT_BRANCH,
        PRIMARY_CONTROL_RESPONSE_BRANCH,
        DEAD_BRANCH,
        SCRIPT_BRANCH,
        IDLE_BRANCH,
        DOWN_BUT_NOT_OUT_BRANCH,
        MELEE_BLOCK_BRANCH,
        AGRESSIVE_BRANCH,
        ALERT_BRANCH,
        SHOOTING_BRANCH,
        GRAPPLE_BREAK_BRANCH,
        REACT_TO_WEAPON_FIRE_BRANCH,
        IN_COVER_BRANCH,
        SUSPICIOUS_ITEM_BRANCH_HIGH,
        SUSPICIOUS_ITEM_BRANCH_MEDIUM,
        SUSPICIOUS_ITEM_BRANCH_LOW,
        AGGRESSION_ESCALATION_BRANCH,
        STUN_DAMAGE_BRANCH,
        BREAKOUT_BRANCH,
        SUSPEND_BRANCH,
        TARGET_IS_NPC_BRANCH,
        PLAYER_HIDING_BRANCH,
        ATTACK_CORE_BRANCH,
        CORPSE_TRAP_BRANCH,
        OBSERVE_TARGET_BRANCH,
        TARGET_IN_CRAWLSPACE_BRANCH,
        MB_SUSPICIOUS_ITEM_ATLEAST_MOVE_CLOSE_TO,
        MB_THREAT_AWARE_ATTACK_TARGET_WITHIN_CLOSE_RANGE,
        MB_THREAT_AWARE_ATTACK_TARGET_WITHIN_VERY_CLOSE_RANGE,
        MB_THREAT_AWARE_ATTACK_TARGET_FLAMED_ME,
        MB_THREAT_AWARE_ATTACK_WEAPON_NOT_AIMED,
        MB_THREAT_AWARE_MOVE_TO_LOST_VISUAL,
        MB_THREAT_AWARE_MOVE_TO_BEFORE_ANIM,
        MB_THREAT_AWARE_MOVE_TO_AFTER_ANIM,
        MB_THREAT_AWARE_MOVE_TO_FLANKED_VENT,
        KILLTRAP_BRANCH,
        PANIC_BRANCH,
        BACKSTAGE_ALIEN_RESPONSE_BRANCH,
        NPC_VS_ALIEN_BRANCH,
        USE_COVER_VS_ALIEN_BRANCH,
        IN_COVER_VS_ALIEN_BRANCH,
        REPEATED_PATHFIND_FAILS_BRANCH,
        ALL_SEARCH_VARIANTS_BRANCH
    }

    public enum ALERTNESS_STATE
    {
        IGNORE_PLAYER,
        ALERT,
        AGGRESSIVE
    }

    public enum LOGIC_CHARACTER_TIMER_TYPE
    {
        SUSPECT_TARGET_RESPONSE_DELAY_TIMER,
        FIRST_LOGIC_CHARACTER_TIMER,
        THREAT_AWARE_TIMEOUT_TIMER,
        THREAT_AWARE_DURATION_TIMER,
        SEARCH_TIMEOUT_TIMER,
        BACKSTAGE_STALK_TIMEOUT_TIMER,
        AMBUSH_TIMEOUT_TIMER,
        ATTACK_BAN_TIMER,
        MELEE_ATTACK_BAN_TIMER,
        VENT_BAN_TIMER,
        NPC_STAY_IN_COVER_SHOOT_TIMER,
        NPC_JUST_LEFT_COMBAT_TIMER,
        ATTACK_KEEP_CHASING_TIMER,
        DELAY_RETURN_TO_SPAWN_POINT_TIMER,
        TARGET_IN_CRAWLSPACE_TIMER,
        DURATION_SINCE_SEARCH_TIMER,
        HEIGHTENED_SENSES_TIMER,
        BACKSTAGE_STALK_PICK_KILLTRAP_TIMER,
        FLANKED_VENT_ATTACK_TIMER,
        THREAT_AWARE_VISUAL_RETENTION_TIMER,
        RESPONSE_TO_BACKSTAGE_ALIEN_TIMEOUT_TIMER,
        VENT_ATTRACT_TIMER,
        SEEN_PLAYER_AIM_WEAPON_TIMER,
        SEARCH_BAN_TIMER,
        OBSERVE_TARGET_TIMER,
        REPEATED_PATHFIND_FAILUREST_TIMER
    }

    public enum LOGIC_CHARACTER_FLAGS
    {
        DONE_BREAKOUT,
        SHOULD_RESET,
        DO_ASSAULT_ATTACK_CHECKS,
        IS_IN_VENT,
        BANNED_FROM_VENT,
        HAS_DONE_GRAPPLE_BREAK,
        HAS_RECEIVED_DOT,
        IS_SITTING,
        DONE_ESCALATION_JOB,
        SHOULD_BREAKOUT,
        SHOULD_ATTACK,
        SHOULD_HIT_AND_RUN,
        DONE_HIT_AND_RUN,
        PLAYER_HIDING,
        ATTACK_HIDING_PLAYER,
        ALIEN_ALWAYS_KNOWS_WHEN_IN_VENT,
        IS_CORPSE_TRAP_ON_START,
        SHOULD_DESPAWN,
        ATTACK_HAS_GOT_WITHIN_ROUTING_THRESHOLD,
        LOCK_BACKSTAGE_STALK,
        TOTALLY_BLIND_IN_DARK,
        PLAYER_WON_HIDING_QTE,
        ANDROID_IS_INERT,
        ANDROID_IS_SHOWROOM_DUMMY,
        SHOULD_AMBUSH,
        NEVER_AGGRESSIVE,
        MUTE_DYNAMIC_DIALOGUE,
        DOING_THREAT_AWARE_ANIM,
        DONE_THREAT_AWARE,
        BLOCK_AMBUSH_AND_KILLTRAPS,
        PREVENT_GRAPPLES,
        PREVENT_ALL_ATTACKS,
        ALLOW_FLANKED_VENT_ATTACK,
        IGNORE_PLAYER_IN_VENT_BEHAVIOUR,
        USE_AIMED_STANCE_FOR_IDLE_JOBS,
        USE_AIMED_LOW_STANCE_FOR_IDLE_JOBS,
        CLOSE_TO_BACKSTAGE_ALIEN,
        IS_IN_EXPLOITABLE_AREA,
        IS_ON_LADDER,
        HAS_REPEATED_PATHFIND_FAILURES
    }

    public enum LOCOMOTION_TARGET_SPEED
    {
        SLOWEST,
        SLOW,
        FAST,
        FASTEST
    }

    public enum FRAME_FLAGS
    {
        SUSPICIOUS_ITEM_LOW_PRIORITY,
        SUSPICIOUS_ITEM_MEDIUM_PRIORITY,
        SUSPICIOUS_ITEM_HIGH_PRIORITY,
        COULD_SEARCH,
        COULD_RESPOND_TO_HIDING_PLAYER,
        COULD_DO_SUSPICIOUS_ITEM_HIGH_PRIORITY,
        COULD_DO_SUSPECT_TARGET_RESPONSE_MOVE_TO
    }

    public enum EVENT_OCCURED_TYPE
    {
        SENSED_TARGET,
        SENSED_SUSPICIOUS_ITEM,
        TARGET_HIDEING,
        SUSPECT_TARGET_RESPONSE
    }

    public enum SUSPICIOUS_ITEM_BEHAVIOUR_TREE_PRIORITY
    {
        LOW,
        MEDIUM,
        HIGH
    }

    public enum ALIEN_DEVELOPMENT_MANAGER_ABILITIES
    {
        NONE,
        THREAT_AWARE,
        LIKES_TO_CLOSE_VIA_BACKSTAGE,
        WILL_KILLTRAP,
        WILL_FLANK,
        WILL_FLANK_FROM_THREAT_AWARE,
        WILL_AMBUSH,
        SEARCH_LOCKERS,
        SEARCH_UNDER_STUFF
    }

    public enum VENT_LOCK_REASON
    {
        FLANKED_VENT_ATTACK_FROM_ATTACK,
        FLANKED_VENT_ATTACK_FROM_THREAT_AWARE
    }

    public enum LOGIC_CHARACTER_GAUGE_TYPE
    {
        RETREAT_GAUGE,
        STUN_DAMAGE_GAUGE
    }

    public enum ANIM_CALLBACK_ENUM
    {
        NONE,
        STUN_DAMAGE_CALLBACK
    }

    public enum ANIM_TREE_ENUM
    {
        NONE,
        STUN_DAMAGE_TREE
    }

    public enum WEAPON_PROPERTY
    {
        ALIEN_THREAT_AWARE_OF
    }

    public enum SUSPICIOUS_ITEM_STAGE
    {
        NONE,
        FIRST_SENSED,
        INITIAL_REACTION,
        WAIT_FOR_TEAM_MEMBERS_ROUTING,
        MOVE_CLOSE_TO,
        CLOSE_TO_REACTION,
        CLOSE_TO_WAIT_FOR_GROUP_MEMBERS,
        SEARCH_AREA
    }

    public enum SUSPICIOUS_ITEM_REACTION
    {
        INITIAL_REACTION,
        CLOSE_TO_FIRST_GROUP_MEMBER_REACTION,
        CLOSE_TO_SUBSEQUENT_GROUP_MEMBER_REACTION
    }

    public enum NPC_COMBAT_STATE
    {
        NONE,
        WARNING,
        ATTACKING,
        REACHED_OBJECTIVE,
        ENTERED_COVER,
        LEAVE_COVER,
        START_RETREATING,
        REACHED_RETREAT,
        LOST_SENSE,
        SUSPICIOUS_WARNING,
        SUSPICIOUS_WARNING_FAILED,
        START_ADVANCE,
        DONE_ADVANCE,
        BLOCKING,
        HEARD_BS_ALIEN,
        ALIEN_SIGHTED
    }

    public enum CHARACTER_CLASS
    {
        PLAYER,
        ALIEN,
        ANDROID,
        CIVILIAN,
        SECURITY,
        FACEHUGGER,
        INNOCENT,
        ANDROID_HEAVY,
        MOTION_TRACKER,
        MELEE_HUMAN
    }

    public enum BEHAVIOUR_MOOD_SET
    {
        NEUTRAL,
        THREAT_ESCALATION_AGGRESSIVE,
        THREAT_ESCALATION_PANICKED,
        AGGRESSIVE,
        PANICKED,
        SUSPICIOUS
    }

    public enum NPC_COVER_REQUEST_TYPE
    {
        DEFAULT,
        RETREAT,
        AGGRESSIVE,
        DEFENSIVE,
        ALIEN,
        PLAYER_IN_VENT
    }


    ////////////////////////////////////////////////////////////////////////////////
    //    Any below here are non-CATHODE enums which are only for behaviours.     //
    ////////////////////////////////////////////////////////////////////////////////

    public enum AwarenessState
    {
        DEAD,
        STUNNED,
        UNAWARE,
        SUSPICIOUS,
        SEARCHING_AREA,
        SEARCHING_LAST_SENSED,
        AWARE
    }

    public enum WithdrawState
    {
        NOT_WITHDRAWING,
        NEEDS_TO_WITHDRAW,
        WITHDRAWING
    }

    public enum ChildStateType
    {
        CHILD_DEFAULT,
        IGNORE_CHILD_FAIL,
    }

    public enum RequestShutDownSpeed
    {
        SST_GRACEFULL,
        SST_EXPEDIENT,
        SST_CRITICAL,
    }

    public enum ThresholdQualifier
    {
        TRACE_THRESHOLD,
        LOWER_THRESHOLD,
        ACTIVATED_THRESHOLD,
        UPPER_THRESHOLD,
    }

    public enum BackstageBehaviour
    {
        BACKSTAGE_ONLY,
        ALLOW_KILLTRAP,
    }

    public enum SenseSet
    {
        SET_1,
        SET_2,
        SET_3 
    }

    public enum Step_Type
    {
        FORWARD,
        BACK
    }

    public enum RoleType
    {
        IDLE,
        DESPAWN,
        SYSTEMATIC_SEARCH,
        SYSTEMATIC_SEARCH_SUSPICIOUS_ITEM,
        STALK,
        BACKSTAGE_AMBUSH,
        HIDING_PLAYER,
        FOLLOW,
        SUSPECT_RESPONSE_MOVE_TO,
        PANIC
    }

    public enum SenseType
    {
        VISUAL,
        HEARD_COMBAT,
        HEARD_MOVEMENT,
        DAMAGED,
        TOUCHED,
        AFFECTED_BY_FLAME_THROWER,
        SEE_FLASH_LIGHT,
        COMBINED
    }

    public enum MotivationType
    {
        CINEMATIC_MOTIVATION,
        ATTACK_MOTIVATION,
        AIM_MOTIVATION,
        DESPAWN_MOTIVATION,
        FOLLOW_MOTIVATION,
        STANDARD_MOTIVATION,
        SEARCH_SYSTEMATIC_MOTIVATION,
        STALK_MOTIVATION,
        BACKSTAGE_STALK_MOTIVATION,
        SHOT_MOTIVATION,
        SUSPECT_TARGET_RESPONSE_MOTIVATION,
        THREAT_AWARE_MOTIVATION,
        BACKSTAGE_AMBUSH_MOTIVATION,
        IDLE_JOB_MOTIVATION,
        USE_COVER_MOTIVATION,
        ASSAULT_MOTIVATION,
        MELEE_MOTIVATION,
        RETREAT_MOTIVATION,
        CLOSE_ON_TARGET_MOTIVATION,
        MUTUAL_MELEE_ONLY_MOTIVATION,
        VENT_MELEE_MOTIVATION,
        MULTIPLAYER_MOTIVATION,
        REACT_TO_WEAPON_MOTIVATION,
        SUSPICIOUS_ITEM_MOTIVATION,
        AGGRESSION_ESCALATION_MOTIVATION,
        STUN_DAMAGE_MOTIVATION,
        BREAKOUT_MOTIVATION,
        PLAYER_HIDE_MOTIVATION,
        OBSERVE_TARGET_MOTIVATION,
        ADVANCING_MOTIVATION,
        AMBUSH_MOTIVATION,
        PANIC_MOTIVATION,
        DEBUG_FORCE_CHARACTER_IDLE_MOTIVATION,
        BACKSTAGE_ALIEN_RESPONSE_MOTIVATION,
        ESCALATION_PREVENTS_SEARCH_MOTIVATION,
        ALIEN_ATTACK_MOTIVATION,
        ANDROID_ATTACK_MOTIVATION
    }

    public enum CharacterType
    {
        OWNER,
        TARGET,
        OWNER_AND_TARGET
    }

    public enum SoundType
    {
        ALIEN_AFFECTED_BY_FLAME_THROWER, 
        ALIEN_ATTACK, 
        ALIEN_BREATH_SLOW_LOOP, 
        ALIEN_CHARGE_TO_ATTACK, 
        ALIEN_DAMAGED_BY_FLAME_THROWER, 
        ALIEN_DAMAGED_BY_ORDNANCE, 
        ALIEN_SEARCHING, 
        ALIEN_SEARCHING_FAIL, 
        ALIEN_STALKING, 
        ALIEN_STARTS_SEARCHING, 
        ALIEN_SUSPECTS_TARGET
    }

    public enum AttackType
    {
        ANY,
        MELEE,
        VENT,
        GRAB,
        TRAP
    }

    public enum TimeThreshold
    {
        TM_0, 
        TM_1, 
        TM_2,
        TM_3, 
        TM_4, 
        TM_5, 
        TM_10,
        TM_15,
        TM_20,
        TM_25, 
        TM_30,
        TM_35, 
        TM_40, 
        TM_45, 
        TM_50, 
        TM_55, 
        TM_60, 
        TM_70, 
        TM_80, 
        TM_90, 
        TM_100,
        TM_110,
        TM_120
    }

    public enum DistanceThreshold
    {
        DT_0,
        DT_1, 
        DT_2,
        DT_3, 
        DT_4,
        DT_5, 
        DT_6, 
        DT_7, 
        DT_8, 
        DT_9, 
        DT_10,
        DT_12,
        DT_14,
        DT_16,
        DT_18,
        DT_20,
        DT_25,
        DT_30,
        DT_35,
        DT_40,
        DT_45,
        DT_50 
    }

    public enum GaugeAmountType
    {
        GAUGE_NONE,
        GAUGE_TRACE,
        GAUGE_LOWER,
        GAUGE_ACTIVATED,
        GAUGE_UPPER,
        GAUGE_FULL,
    }

    public enum CombatAreaType
    {
        COMBAT_AREA_DEFEND,
        COMBAT_AREA_PURSUIT,
    }

    public enum ObjectiveType
    {
        OBJECTIVE_TYPE_MOVE,
        OBJECTIVE_TYPE_START_POS,
        OBJECTIVE_TYPE_COVER,
        OBJECTIVE_TYPE_SAFE_POINT
    }

    public enum Npc_Weapon_Type
    {
        WEAPON_TYPE_ANY,
        WEAPON_TYPE_PROJECTILE,
        WEAPON_TYPE_MELEE
    }

    public enum ShouldWeaponEquip
    {
        SHOULD_EQUIP,
        SHOULD_UNEQUIP
    }

    public enum ShouldRaiseGun
    {
        GUN_RAISED,
        GUN_LOWERED
    }

    public enum WeaponRange
    {
        WRT_TOO_CLOSE,
        WRT_EFFECTIVE_RANGE,
        WRT_MAX_RANGE,
        WRT_TOO_FAR, 
        WRT_PREFERRED_RANGE
    }

    public enum TerminationCondition
    {
        Continuous,
        Shot_1,
        Shot_2,
        Shot_3,
        Shot_4,
        Random_between_1_and_4,
        Random_between_1_and_ClipCount
    }

    public enum Direction
    {
        Forward,
        Back,
        Right,
        Left
    }
}

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
    public enum BEHAVIOR_TREE_BRANCH_TYPE
    {
        NONE, //Unknown 0
        CINEMATIC_BRANCH = 1,
        ATTACK_BRANCH = 2,
        AIM_BRANCH = 3,
        DESPAWN_BRANCH = 4,
        FOLLOW_BRANCH = 5,
        STANDARD_BRANCH = 6,
        SEARCH_BRANCH = 7,
        AREA_SWEEP_BRANCH = 8,
        BACKSTAGE_AREA_SWEEP_BRANCH = 9,
        SHOT_BRANCH = 10,
        SUSPECT_TARGET_RESPONSE_BRANCH = 11,
        THREAT_AWARE_BRANCH = 12,
        BACKSTAGE_AMBUSH_BRANCH = 13,
        IDLE_JOB_BRANCH = 14,
        USE_COVER_BRANCH = 15,
        ASSAULT_BRANCH, //Unknown 16
        MELEE_BRANCH = 17,
        RETREAT_BRANCH = 18,
        CLOSE_ON_TARGET_BRANCH = 19,
        MUTUAL_MELEE_ONLY_BRANCH, //Unknown 20
        VENT_MELEE_BRANCH = 21,
        ASSAULT_NOT_ALLOWED_BRANCH, //Unknown 22
        IN_VENT_BRANCH = 23,
        CLOSE_COMBAT_BRANCH = 24,
        DRAW_WEAPON_BRANCH = 25,
        PURSUE_TARGET_BRANCH = 26,
        RANGED_ATTACK_BRANCH, //Unknown 27
        RANGED_COMBAT_BRANCH, //Unknown 28
        PRIMARY_CONTROL_RESPONSE_BRANCH = 29,
        DEAD_BRANCH = 30,
        SCRIPT_BRANCH = 31,
        IDLE_BRANCH = 32,
        DOWN_BUT_NOT_OUT_BRANCH, //Unknown 33
        MELEE_BLOCK_BRANCH, //Unknown 34
        AGRESSIVE_BRANCH = 35,
        ALERT_BRANCH = 36,
        SHOOTING_BRANCH = 37,
        REACT_TO_WEAPON_FIRE_BRANCH = 38,
        IN_COVER_BRANCH = 39,
        SUSPICIOUS_ITEM_BRANCH_HIGH = 40,
        SUSPICIOUS_ITEM_BRANCH_MEDIUM = 41,
        SUSPICIOUS_ITEM_BRANCH_LOW = 42,
        AGGRESSION_ESCALATION_BRANCH = 43,
        STUN_DAMAGE_BRANCH = 44,
        BREAKOUT_BRANCH = 45,
        SUSPEND_BRANCH = 46,
        TARGET_IS_NPC_BRANCH = 47,
        PLAYER_HIDING_BRANCH = 48,
        ATTACK_CORE_BRANCH = 49,
        CORPSE_TRAP_BRANCH = 50,
        OBSERVE_TARGET_BRANCH = 51,
        PANIC_BRANCH = 52,
        TARGET_IN_CRAWLSPACE_BRANCH = 53,
        KILLTRAP_BRANCH = 54,
        MB_SUSPICIOUS_ITEM_ATLEAST_MOVE_CLOSE_TO = 55,
        MB_THREAT_AWARE_ATTACK_TARGET_WITHIN_CLOSE_RANGE = 56,
        MB_THREAT_AWARE_ATTACK_TARGET_WITHIN_VERY_CLOSE_RANGE = 57,
        MB_THREAT_AWARE_ATTACK_TARGET_FLAMED_ME = 58,
        MB_THREAT_AWARE_ATTACK_WEAPON_NOT_AIMED = 59,
        MB_THREAT_AWARE_MOVE_TO_LOST_VISUAL = 60,
        MB_THREAT_AWARE_MOVE_TO_BEFORE_ANIM = 61,
        MB_THREAT_AWARE_MOVE_TO_AFTER_ANIM = 62,
        MB_THREAT_AWARE_MOVE_TO_FLANKED_VENT = 63,
        BACKSTAGE_ALIEN_RESPONSE_BRANCH = 64,
        NPC_VS_ALIEN_BRANCH, //Unknown 65
        USE_COVER_VS_ALIEN_BRANCH = 66,
        IN_COVER_VS_ALIEN_BRANCH = 67,
        REPEATED_PATHFIND_FAILS_BRANCH = 68,
        ALL_SEARCH_VARIANTS_BRANCH, //Unknown 69
    }

    public enum LOGIC_CHARACTER_TIMER_TYPE
    {
        SUSPECT_TARGET_RESPONSE_DELAY_TIMER = 0,
        //FIRST_LOGIC_CHARACTER_TIMER
        THREAT_AWARE_TIMEOUT_TIMER = 1,
        THREAT_AWARE_DURATION_TIMER, //Unknown 2
        SEARCH_TIMEOUT_TIMER, //Unknown 3
        BACKSTAGE_STALK_TIMEOUT_TIMER = 4,
        AMBUSH_TIMEOUT_TIMER = 5,
        ATTACK_BAN_TIMER = 6,
        MELEE_ATTACK_BAN_TIMER, //Unknown 7
        VENT_BAN_TIMER = 8,
        NPC_JUST_LEFT_COMBAT_TIMER = 9,
        //Unknown 10
        //Unknown 11
        ATTACK_KEEP_CHASING_TIMER = 12,
        DELAY_RETURN_TO_SPAWN_POINT_TIMER = 13,
        TARGET_IN_CRAWLSPACE_TIMER = 14,
        HEIGHTENED_SENSES_TIMER = 15,
        BACKSTAGE_STALK_PICK_KILLTRAP_TIMER = 16,
        FLANKED_VENT_ATTACK_TIMER = 17,
        THREAT_AWARE_VISUAL_RETENTION_TIMER = 18,
        RESPONSE_TO_BACKSTAGE_ALIEN_TIMEOUT_TIMER = 19,
        VENT_ATTRACT_TIMER = 20,
        SEEN_PLAYER_AIM_WEAPON_TIMER = 21,
        SEARCH_BAN_TIMER = 22,
        OBSERVE_TARGET_TIMER = 23,
        REPEATED_PATHFIND_FAILUREST_TIMER = 24,
    }

    public enum LOGIC_CHARACTER_FLAGS
    {
        DONE_BREAKOUT = 0,
        SHOULD_RESET = 1,

        /*
        DO_ASSAULT_ATTACK_CHECKS
        IS_IN_VENT
        BANNED_FROM_VENT
        HAS_DONE_GRAPPLE_BREAK
        HAS_RECEIVED_DOT
        IS_SITTING
        DONE_ESCALATION_JOB
        */

        //Unknown 2
        //Unknown 3
        SHOULD_BREAKOUT = 4,
        SHOULD_ATTACK = 5,
        SHOULD_HIT_AND_RUN = 6,
        DONE_HIT_AND_RUN = 7,
        PLAYER_HIDING = 8,
        ATTACK_HIDING_PLAYER = 9,
        ALIEN_ALWAYS_KNOWS_WHEN_IN_VENT = 10,
        SHOULD_DESPAWN = 11,
        ATTACK_HAS_GOT_WITHIN_ROUTING_THRESHOLD = 12,
        LOCK_BACKSTAGE_STALK = 13,
        DOING_THREAT_AWARE_ANIM = 14,
        DONE_THREAT_AWARE = 15,
        SHOULD_AMBUSH = 16,
        PREVENT_GRAPPLES = 17,
        PREVENT_ALL_ATTACKS, //Unknown 18
        ALLOW_FLANKED_VENT_ATTACK = 19,
        CLOSE_TO_BACKSTAGE_ALIEN = 20,
        IS_IN_EXPLOITABLE_AREA = 21,
        HAS_REPEATED_PATHFIND_FAILURES = 22,
    }

    public enum LOCOMOTION_TARGET_SPEED
    {
        Slowest = 0,
        Slow = 1,
        Fast = 2,
        Fastest = 3,
    }

    public enum FRAME_FLAGS
    {
        SUSPICIOUS_ITEM_LOW_PRIORITY = 0,
        SUSPICIOUS_ITEM_MEDIUM_PRIORITY = 1,
        SUSPICIOUS_ITEM_HIGH_PRIORITY = 2,
        COULD_SEARCH = 3,
        COULD_RESPOND_TO_HIDING_PLAYER = 4,
        COULD_DO_SUSPICIOUS_ITEM_HIGH_PRIORITY = 5,
        COULD_DO_SUSPECT_TARGET_RESPONSE_MOVE_TO = 6,
    }

    public enum EVENT_OCCURED_TYPE
    {
        SENSED_TARGET = 0,
        SENSED_SUSPICIOUS_ITEM = 1,
        TARGET_HIDEING = 2,
        SUSPECT_TARGET_RESPONSE = 3,
    }

    public enum SUSPICIOUS_ITEM_BEHAVIOUR_TREE_PRIORITY
    {
        LOW = 0,
        MEDIUM = 1,
        HIGH = 2,
    }

    public enum ALIEN_DEVELOPMENT_MANAGER_ABILITIES
    {
        NONE, //Unknown 0
        THREAT_AWARE = 1,
        LIKES_TO_CLOSE_VIA_BACKSTAGE, //Unknown 2
        WILL_KILLTRAP = 3,
        WILL_FLANK = 4,
        WILL_FLANK_FROM_THREAT_AWARE = 5,
        WILL_AMBUSH = 6,
        SEARCH_LOCKERS, //Unknown 7
        SEARCH_UNDER_STUFF, //Unknown 8
    }

    public enum VENT_LOCK_REASON
    {
        FLANKED_VENT_ATTACK_FROM_ATTACK = 0,
        FLANKED_VENT_ATTACK_FROM_THREAT_AWARE = 1,
    }

    public enum LOGIC_CHARACTER_GAUGE_TYPE
    {
        RETREAT_GAUGE = 0,
        //Unknown 1   -- NOTE: I think this value was removed.
        STUN_DAMAGE_GAUGE = 2,
    }

    public enum ANIM_CALLBACK_ENUM
    {
        //NOTE: NONE is a value in code (-1?)
        STUN_DAMAGE_CALLBACK = 0,
    }

    public enum ANIM_TREE_ENUM
    {
        //NOTE: NONE is a value in code (-1?)
        STUN_DAMAGE_TREE = 0,
    }

    public enum WEAPON_PROPERTY
    {
        ALIEN_THREAT_AWARE_OF = 0,
    }

    public enum SUSPICIOUS_ITEM_STAGE
    {
        //NOTE: NONE is a value in code (-2?)
        //NOTE: FIRST_SENSED is a value in code (-1?)
        INITIAL_REACTION = 0,
        WAIT_FOR_TEAM_MEMBERS_ROUTING = 1,
        MOVE_CLOSE_TO = 2,
        CLOSE_TO_REACTION = 3,
        CLOSE_TO_WAIT_FOR_GROUP_MEMBERS = 4,
        SEARCH_AREA = 5,
    }

    public enum SUSPICIOUS_ITEM_REACTION
    {
        INITIAL_REACTION = 0,
        CLOSE_TO_FIRST_GROUP_MEMBER_REACTION = 1,
        CLOSE_TO_SUBSEQUENT_GROUP_MEMBER_REACTION = 2,
    }

    public enum NPC_COMBAT_STATE
    {
        NONE, //Unknown 0
        WARNING = 1,
        ATTACKING = 2,
        REACHED_OBJECTIVE, //Unknown 3
        ENTERED_COVER = 4,
        LEAVE_COVER, //Unknown 5
        START_RETREATING = 6,
        REACHED_RETREAT, //Unknown 7
        LOST_SENSE = 8,
        SUSPICIOUS_WARNING = 9,
        SUSPICIOUS_WARNING_FAILED = 10,
        START_ADVANCE = 11,
        DONE_ADVANCE, //Unknown 12
        BLOCKING, //Unknown 13
        HEARD_BS_ALIEN = 14,
        ALIEN_SIGHTED = 15,
    }

    public enum CHARACTER_CLASS
    {
        PLAYER = 0,
        ALIEN = 1,
        ANDROID = 2,
        CIVILIAN = 3,
        SECURITY = 4,
        FACEHUGGER, //Unknown 5
        INNOCENT = 6,
        ANDROID_HEAVY = 7,
        MOTION_TRACKER, //Unknown 8
        MELEE_HUMAN, //Unknown 9
    }

    public enum ALERTNESS_STATE
    {
        IGNORE_PLAYER = 0,
        ALERT = 1,
        AGGRESSIVE = 2,
    }

    public enum BEHAVIOUR_MOOD_SET
    {
        NEUTRAL = 0,
        THREAT_ESCALATION_AGGRESSIVE = 1,
        THREAT_ESCALATION_PANICKED, //Unknown 2
        AGGRESSIVE = 3,
        PANICKED = 4,
        SUSPICIOUS = 5,
    }

    public enum NPC_COVER_REQUEST_TYPE
    {
        DEFAULT = 0,
        RETREAT = 1,
        AGGRESSIVE = 2,
        DEFENSIVE, //Unknown 3
        ALIEN = 4,
        PLAYER_IN_VENT = 5,
    }


    ///////////////////////////////////////////////////////////////
    // Any below here I could not find the in-engine name for... //
    ///////////////////////////////////////////////////////////////

    public enum AwarenessState
    {
        DEAD = 0,
        STUNNED, //Unknown 1
        UNAWARE = 2,
        SUSPICIOUS = 3,
        SEARCHING_AREA = 4,
        SEARCHING_LAST_SENSED, //Unknown 5
        AWARE = 6,
    }

    public enum WithdrawState
    {
        NOT_WITHDRAWING = 0,
        NEEDS_TO_WITHDRAW = 1,
        WITHDRAWING = 2,
    }

    public enum ChildStateType
    {
        CHILD_DEFAULT = 0,
        IGNORE_CHILD_FAIL = 1,
    }

    public enum RoleType
    {
        IDLE = 0,
        DESPAWN, //Unknown 1
        SYSTEMATIC_SEARCH = 2,
        SYSTEMATIC_SEARCH_SUSPICIOUS_ITEM = 3,
        STALK = 4,
        //Unknown 5
        //Unknown 6
        //Unknown 7
        //Unknown 8
        BACKSTAGE_AMBUSH = 9,
        //Unknown 10
        HIDING_PLAYER = 11,
        FOLLOW = 12,
        SUSPECT_RESPONSE_MOVE_TO = 13,
        PANIC = 14,
    }

    public enum RequestShutDownSpeed
    {
        SST_GRACEFULL = 0,
        SST_EXPEDIENT = 1,
        SST_CRITICAL = 2,
    }

    public enum SenseSet //TODO - i think this might be 0,2,3 - not 0,1,2
    { 
        SET_1, 
        SET_2, 
        SET_3
    }

    public enum Step_Type //TODO: ??
    { 
        FORWARD, 
        BACK
    }

    public enum SenseType //SENSORY_TYPE?
    {
        VISUAL = 0,
        HEARD_COMBAT = 1,
        //Unknown 2
        HEARD_MOVEMENT = 3,
        DAMAGED = 4,
        TOUCHED = 5,
        AFFECTED_BY_FLAME_THROWER = 6,
        SEE_FLASH_LIGHT = 7,
        COMBINED = 8,
    }

    public enum ThresholdQualifier
    {
        TRACE_THRESHOLD = 0,
        LOWER_THRESHOLD = 1,
        ACTIVATED_THRESHOLD = 2,
        UPPER_THRESHOLD = 3,
    }

    public enum BackstageBehaviour
    {
        BACKSTAGE_ONLY = 0,
        ALLOW_KILLTRAP = 1,
    }

    public enum MotivationType
    {
        CINEMATIC_MOTIVATION = 0,
        ATTACK_MOTIVATION = 1,
        DESPAWN_MOTIVATION = 2,
        //Unknown 3
        //Unknown 4
        SEARCH_SYSTEMATIC_MOTIVATION = 5,
        STALK_MOTIVATION = 6,
        BACKSTAGE_STALK_MOTIVATION = 7,
        SHOT_MOTIVATION = 8,
        SUSPECT_TARGET_RESPONSE_MOTIVATION = 9,
        THREAT_AWARE_MOTIVATION = 10,
        //Unknown 11
        AIM_MOTIVATION = 12,
        IDLE_JOB_MOTIVATION = 13,
        USE_COVER_MOTIVATION = 14,
        //Unknown 15
        MELEE_MOTIVATION = 16,
        RETREAT_MOTIVATION = 17,
        //Unknown 18
        MUTUAL_MELEE_ONLY_MOTIVATION = 19,
        //Unknown 20
        REACT_TO_WEAPON_MOTIVATION = 21,
        SUSPICIOUS_ITEM_MOTIVATION = 22,
        AGGRESSION_ESCALATION_MOTIVATION = 23,
        STUN_DAMAGE_MOTIVATION = 24,
        BREAKOUT_MOTIVATION = 25,
        PLAYER_HIDE_MOTIVATION = 26,
        OBSERVE_TARGET_MOTIVATION = 27,
        //Unknown 28
        AMBUSH_MOTIVATION = 29,
        DEBUG_FORCE_CHARACTER_IDLE_MOTIVATION = 30,
        PANIC_MOTIVATION = 31,
        BACKSTAGE_ALIEN_RESPONSE_MOTIVATION = 32,
    }

    public enum CharacterType
    {
        OWNER = 0,
        TARGET = 1,
        OWNER_AND_TARGET = 2,
    }

    public enum SoundType //TODO: there are more here in code.
    {
        //Unknown 0
        //Unknown 1
        //Unknown 2
        ALIEN_CHARGE_TO_ATTACK = 3,
        //Unknown 4
        //Unknown 5
        //Unknown 6
        //Unknown 7
        //Unknown 8
        ALIEN_STARTS_SEARCHING = 9,
    }

    public enum AttackType
    {
        ANY = 0,
        //Unknown 1
        //Unknown 2
        VENT = 3,
        TRAP = 4,
    }

    public enum TimeThreshold
    {
        //Unknown 0
        TM_1 = 1,
        TM_2 = 2,
        TM_3 = 3,
        //Unknown 4
        TM_5 = 5,
        TM_10 = 6,
        //Unknown 7
        TM_20 = 8,
        //Unknown 9
        TM_30 = 10,
        //Unknown 11
        TM_40 = 12,
    }

    public enum DistanceThreshold
    {
        //Unknown 0
        //Unknown 1
        DT_2 = 2,
        //Unknown 3
        DT_4 = 4,
        DT_5 = 5,
    }

    public enum GaugeAmountType
    {
        GAUGE_NONE = 0,
        GAUGE_TRACE = 1,
        GAUGE_LOWER = 2,
        GAUGE_ACTIVATED = 3,
        GAUGE_UPPER = 4,
    }

    public enum CombatAreaType
    {
        //Unknown 0
        COMBAT_AREA_PURSUIT = 1,
    }

    public enum ObjectiveType
    {
        OBJECTIVE_TYPE_MOVE = 0,
        OBJECTIVE_TYPE_START_POS = 1,
        //Unknown 2
        OBJECTIVE_TYPE_SAFE_POINT = 3,
    }

    public enum Npc_Weapon_Type
    {
        WEAPON_TYPE_ANY = 0,
        WEAPON_TYPE_PROJECTILE = 1,
        WEAPON_TYPE_MELEE = 2,
    }

    public enum ShouldWeaponEquip
    {
        SHOULD_EQUIP = 0,
        SHOULD_UNEQUIP = 1,
    }

    public enum ShouldRaiseGun
    {
        GUN_RAISED = 0,
        GUN_LOWERED = 1,
    }

    public enum WeaponRange
    {
        //Unknown 0
        //Unknown 1
        WRT_MAX_RANGE = 2,
    }

    public enum TerminationCondition
    {
        Continuous = 0,
        //Unknown 1
        Shot_1 = 2,
        //Unknown 3
        //Unknown 4
        //Unknown 5
        Random_between_1_and_4 = 6,
    }

    public enum Direction
    {
        //Unknown 0
        //Unknown 1
        Right = 2,
    }
}

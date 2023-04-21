using UnityEngine;

namespace HeroScripts
{
    public class CharacterAnimation : MonoBehaviour
    {
        private Animator anim;

        // Start is called before the first frame update
        void Awake()
        {
            anim = GetComponent<Animator>();
        }

        public void Walk(bool walk)
        {
            anim.SetBool(AnimationTags.WALK_PARAMETER, walk);
        }

        public void Run(bool run)
        {
            anim.SetBool(AnimationTags.RUN_PARAMETER, run);
        }

        public void NormalAttack()
        {
            anim.SetTrigger(AnimationTags.NORMAL_ATTACK_TRIGGER);
        }
    
        public void NormalAttack2()
        {
            anim.SetTrigger(AnimationTags.NORMAL_ATTACK2_TRIGGER);
        }

        public void SpecialAttack1()
        {
            anim.SetTrigger(AnimationTags.SPECIAL_ATTACK1_TRIGGER);
        }
    
        public void SpecialAttack2()
        {
            anim.SetTrigger(AnimationTags.SPECIAL_ATTACK2_TRIGGER);
        }
    
        public void SpecialAttack3()
        {
            anim.SetTrigger(AnimationTags.SPECIAL_ATTACK3_TRIGGER);
        }

        public void Hit()
        {
            anim.SetTrigger(AnimationTags.HIT);
        }
    
        public void Dead()
        {
            anim.SetTrigger(AnimationTags.DEAD_PARAMETER);
        }

        public void StopAnimation()
        {
            anim.StopPlayback();
        }

        void BackToIdle()
        {
            anim.Play(AnimationTags.IDLE_TAG);
        }
    
    }
}

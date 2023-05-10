
using UnityEngine;

namespace ddr.MemoryGame.SoundClip{
 [CreateAssetMenu(fileName= "New Sound",menuName = "Memory Game/SoundClip")]

public class SoundClip : ScriptableObject
{
    public new string name;
    public AudioClip clip;

}

}


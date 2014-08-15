public class CharaAIManager : UnityEngine.MonoBehaviour {

	public float AggresivenessState = 0; /* Militaristic Modifier */
	public float ClevernessState    = 0; /* Detect Weakness */
	public float DiversityState     = 0; /* Unit Diversity */
	public float EliteState         = 0; /* Quality vs Quantity */
	public float ExplorationState   = 0; /* Patrol vs Campaign */
	public float HarassmentState    = 0; /* Interval Between Campaign | loot */
	public float InnovationState    = 0; /* Special Unit Size */
	public float MotivationState    = 0; /* Act vs Idle */
	public float MemoryState        = 0; /* Remember Opponent Unit */

	public void Start() {
		PreStart();
		SetDefaultValue();
		PostStart();
	}

	 /*
	██▒▒▒▒██▒██▒██████▒▒████████▒██▒▒▒▒██▒▒█████▒▒██▒▒▒▒▒
	██▒▒▒▒██▒██▒██▒▒▒██▒▒▒▒██▒▒▒▒██▒▒▒▒██▒██▒▒▒██▒██▒▒▒▒▒
	██▒▒▒▒██▒██▒██████▒▒▒▒▒██▒▒▒▒██▒▒▒▒██▒███████▒██▒▒▒▒▒
	▒██▒▒██▒▒██▒██▒▒▒██▒▒▒▒██▒▒▒▒██▒▒▒▒██▒██▒▒▒██▒██▒▒▒▒▒
	▒▒████▒▒▒██▒██▒▒▒▒██▒▒▒██▒▒▒▒▒██████▒▒██▒▒▒██▒███████
	*/

	public virtual void PreStart() {}
	public virtual void PostStart() {}

	/*
	 ▒███████▒████████▒▒████████
	 ██▒▒▒▒▒▒▒██▒▒▒▒▒▒▒▒▒▒▒██▒▒▒
	 ██▒▒▒██▒▒████████▒▒▒▒▒██▒▒▒
	 ▒██▒▒▒██▒██▒▒▒▒▒▒▒▒▒▒▒██▒▒▒
	 ▒▒█████▒▒████████▒▒▒▒▒██▒▒▒
	*/

	public System.Object GetCommand(string subject) {
		return 0;
	}

	/*
	 ▒██████▒▒████████▒████████
	 ██▒▒▒▒▒▒▒██▒▒▒▒▒▒▒▒▒▒██▒▒▒
	 ▒██████▒▒████████▒▒▒▒██▒▒▒
	 ▒▒▒▒▒▒██▒██▒▒▒▒▒▒▒▒▒▒██▒▒▒
	 ▒██████▒▒████████▒▒▒▒██▒▒▒
	*/

	public void SetDefaultValue() {}

}

/****************************************************************************
 * In-depth Explanation                                                     *
 *                                                                          *
 * States Determine Characters' Action                                      *
 * Scale is between 0 to 100 (percent)                                      *
 *                                                                          *
 * #AggresivenessState                                                      *
 *   This state affects how militaristic a faction/character would be.      *
 *   This state also affect how trusting a faction/character would be.      *
 *     Raise: Resources are more likely spent on increasing combat value    *
 *            Harder to persuade                                            *
 *     Drop:  Resouces are more likely spent on increasing non-combat value *
 *            Easier to persuade                                            *
 *   Ex:                                                                    *
 *     Faction:                                                             *
 *       The Youkai Mountain doesn't welcome outsiders thus having a higher *
 *       AggresivenessState than average.                                   *
 *       On the other hand, the Moriya Shrine accepts visitors thus having  *
 *       a lower AggressivenessState than average.                          *
 *       Note: In case of shared territories between multiple Factions,     *
 *             consult with local authority.                                *
 *     Character:                                                           *
 *       Combative Character, such as Yamame, would spend her time on       *
 *       honing her combative ability.                                      *
 *       Non-combative Character, such as Akyuu, would spend her time on    *
 *       honing her non-combative ability.                                  *
 *                                                                          *
 *  #ClevernessState                                                        *
 *    This state affects how well the subject detects opportunities.        *
 *    Higher value on this state would lead the faction / character to      *
 *    prioritize the development on its strongest points.                   *
 *      Raise: More likely to take advantage on bonuses.                    *
 *      Drop: Less likely to take advantage on bonuses.                     *
 *    Ex:                                                                   *
 *      Faction:                                                            *
 *        An aggressive faction would shift more resources to non-combat    *
 *        value when there is a higher bonus for resources spent on         *
 *        non-combat value than combat value.                               *
 *      Character:                                                          *
 *        A character would stockpile more food before the winter comes     *
 *        and sell it on a much higher price to others during the winter.   *
 *                                                                          *
 *  #DiversityState                                                         *
 *    This state affects appreciation on diversity.                         *
 *      Raise: More likely to invest on minor stuffs.                       *
 *      Drop: More likely to neglect minor stuffs.                          *
 *    Note: For Beginner: Keep a balance value for this state.              *
 *          Max on this state would create a melting pot faction,           *
 *          or jack of all trade character.                                 *
 *          Min on this state would create a homogeneous & racist faction,  *
 *          or restrictively-skilled character.                             *
 *    Ex:                                                                   *
 *      Faction:                                                            *
 *        Eintei accepts anyone who doesn't do harm, thus having higher     *
 *        value on this state than average.                                 *
 *        Higan doesn't welcome the living. Anyone would be converted       *
 *        into dead souls, thus having lower value on this state than       *
 *        average.                                                          *
 *        Note: Temples have their own doctrine and accept anyone that      *
 *        practice it and hostile to those who oppose it.                   *
 *        Check InnovationState instead.                                    *
 *      Character:                                                          *
 *        Reimu, contrary to human perception on her occupation, Reimu      *
 *        is quite tolerant toward other races, thus having a higher        *
 *        rate on this state than average.                                  *
 *        Sanae, devoted toward youkai extermination as she is enjoying,    *
 *        doing so, has lower rate on this state than average.              *
 *                                                                          *
 *  #EliteState                                                             *
 *    This state affects the balance between quality and quantity.          *
 *      Raise: More focus on quality.                                       *
 *      Drop: More focus on quantity.                                       *
 *    Ex:                                                                   *
 *      Faction:                                                            *
 *        The Fairy Bands are more likely to focus on gathering more        *
 *        fairies, thus having lower state than average.                    *
 *        The Oni Bands are more likely to focus on training their          *
 *        personnel, thus having higher state than average.                 *
 *      Character:                                                          *
 *        Being carefree, Tenshi spends her time doing various              *
 *        oddities to kill her boredom rather than honing particular        *
 *        skill, thus having lower rate on this state than average.         *
 *        Patchouli spends her time studying spell-casting in her           *
 *        library, thus having higher rate on this state than average.      *
 *                                                                          *
 *  #ExplorationState                                                       *
 *    This state affects on how often a faction / character would explore.  *
 *    Raise: Decrease interval between exploration.                         *
 *    Drop: Increase interval between exploration.                          *
 *    Note: Exploring would let a faction to cover more ground as it sends  *
 *    out couple groups to scout around, but it would also reduce the       *
 *    power of the main force as its being chipped part by part to explore, *
 *    exploration group would also require more resources to maintain.      *
 *    Ex:                                                                   *
 *      Faction:                                                            *
 *        Lunarian has a lot of spies everywhere to keep track on Earth,    *
 *        thus having higher rate on this state than average.               *
 *        The Tengu has a reclusive lifestyle, thus having a lower rate     *
 *        on this state than average.                                       *
 *        Note: The Tengu has GPS, which gives them more ground to cover,   *
 *        but unit detection is pretty poor.                                *
 *      Character:                                                          *
 *        Aya, quite opposite to her faction, is quite explorative to       *
 *        gather information for her newspaper, thus having higher rate     *
 *        on this state than average.                                       *
 *        Parsee hardly leaves her brige as she is the bridge princess,     *
 *        thus having a lower rate on this state than average.              *
 *                                                                          *
 *  #HarrassmentState                                                       *
 *    This state affects the interval between looting (faction) and         *
 *    challenge (character)                                                 *
 *      Raise: More often to loot and challenge                             *
 *      Drop: Less often to loot and challenge                              *
 *    Note: Looting delays and weakens the main force of its faction,       *
 *          in similar manner to ExplorationState, in trade of resources.   *
 *          Challenge provide large bonuses to a character status that wins *
 *          the challenge, and small bonuses to the side that loses.        *
 *          There are more bonuses in training oneself rather than losing a *
 *          challenge.                                                      *
 *    Ex:                                                                   *
 *      Faction:                                                            *
 *        Former Hell often has its units popping out in gensokyo,          *
 *        harassing passersby, thus having a higher rate on this state than *
 *        average.                                                          *
 *        The Scarlet Devil Mansion residence hardly venture outside, thus  *
 *        having a lower rate on this state than average.                   *
 *      Character:                                                          *
 *                                                                          *
 *                                                                          *
 *                                                                          *
 *                                                                          *
 ****************************************************************************/
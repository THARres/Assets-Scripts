To Do List:

6/12/2014

Priority
- Conclude desired value of each character


Secondary

- Implement Faction Layering

- Implement Audio Manager
- Implement Basic Movement Audio (Walk, Dash, Idle)
- Implement BG Audio

- Implement Scene Manager

- Implement Basic Stats (STR, AGI, MAG) (CharaController.cs)
- Implement SP Parameter (CharaController.cs)
- Implement Character Level (CharaController.cs)

- Implement Cursor Picture

- Fixed Character Child Y Rotation (CharaAttackController.cs && CharaOptionController.cs)
- Implement Character Focus (CharaController.cs + ScrollCameraScript.cs)


Parameters:
2-tiers

1st tier: 6 (hexagon)

STR - AGI
INT - CHA
LUC - APT

2nd tier:

Battle Parameters
HP
HP-Regen
SP
SP-Regen
Stamina
ATK
DEF
Mov SPD

Crit

Brust Rate
Brust Speed
Brust Size

Hit Box Size

Spell Slot

Morale

Non-Battle Parameters

Recruitment

Party Speed
Party Size

Party Cost

Search
Recruitment
Familiarity

Territory Management:
Leadership
Logistic

Battle Parameter Modifiers

STR - HP, HP-Regen, ATK, DEF, Stamina, Brust Rate (minor), Brust Size (major)
AGI - Move Speed, Hit Box Size, Brust Rate (major), Brust Size (minor)
INT - SP, SP-Regen, Brust Speed, Spell Slot
CHA - Morale
LUC - Crit (major)
APT - A bit of everything

Non-battle Parameter Modifiers

STR - HP-Regen
AGI - Party Speed (minor)
INT - SP-Regen, Party Size (minor), Party Speed (major), Logistic, Recruitment (minor),
      Leadership (minor)
CHA - Party Size (major), Recruitment (major), Leadership (major)
LUC - Search (major)

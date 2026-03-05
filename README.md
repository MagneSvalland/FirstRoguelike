# FirstRoguelike

A 2D top-down roguelike built in Unity 6 (URP), inspired by Brotato and Teamfight Tactics.

## About
FirstRoguelike is an arena survival game with wave-based combat and a deep progression system built around **Blessings** and **Bloodlines**.

Each run the player chooses from randomised Blessings when levelling up. 
Blessings carry a Bloodline tag — collect enough of the same Bloodline to unlock powerful synergy bonuses.

## Core Features (In Development)
- Wave-based arena survival
- Class system (Mage, Warrior, Gunslinger, Rogue)
- Bloodline synergy system (Dragon, Mystic, and more)
- Blessing upgrade system with RNG-driven build variety
- Meta skill tree for permanent progression between runs
- Story-driven stage progression + infinite mode

## Tech Stack
- Unity 6.3 LTS (URP, 2D)
- C# with New Input System
- ScriptableObject-driven data architecture
- Static C# event bus
- Modifier stack pattern for stats

## Architecture
- `StatSheet` — modifier stack (Flat → PercentAdd → PercentMultiply)
- `BlessingSO` — data-driven upgrade definitions
- `BloodlineSO` — synergy tier definitions and thresholds
- `IAttackStrategy` — strategy pattern for class weapons
- `GameEvents` — decoupled event bus

## Project Status
Early development — core systems being built.
<img width="1916" height="1034" alt="image" src="https://github.com/user-attachments/assets/5d778e08-d6d5-4e08-b970-c75f00043fbb" />




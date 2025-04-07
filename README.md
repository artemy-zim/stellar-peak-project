# 🌌 Stellar Peak

**Stellar Peak** is a solo-developed sci-fi exploration game created with Unity. The player controls a team of astronauts exploring procedurally-inspired star systems, landing on planets, collecting resources, fighting enemies, and upgrading crew members — all while managing the ship's fuel supply. The game is built using the **MVP (Passive View)** architectural pattern along with **clean architecture principles**, **UniRx**, **UniTask**.

---

## 🎮 Features

- 🚀 **Explore the Galaxy**  
  A randomly generated star map with interconnecting systems and limited travel range based on fuel.

- 🌍 **Planetary Landing and Exploration**  
  Each planet is randomly generated with resources and enemies, offering a unique experience every time.

- 🧪 **Collectible Resources**  
  - **Mineral**  
  - **Organic**  
  - **Energy**  
  Resources are gathered during expeditions and stored in the inventory system.

- 🤖 **Enemy AI**  
  Enemies detect the player, chase, and attack in melee. Health systems and death handling are implemented.

- 🧠 **Astronaut Upgrades**  
  Each astronaut can be upgraded in various stats, improving performance during planetary missions.

- ✨ **Animated UI**  
  DOTween powers smooth animations for UI elements and transitions.

---

## 🧱 Technical Architecture

- **MVP (Passive View)** – clear separation of presentation, logic, and UI
- **UniRx + UniTask** – reactive programming and asynchronous tasks without coroutines
- **Clean Architecture Principles** – SOLID, DRY, YAGNI, KISS
- **ScriptableObject** – configuration data for resources, generation rules, upgrades
- **JsonUtility** – used for game data serialization

---

## 🛠️ Tech Stack

| Technology       | Purpose                          |
|------------------|----------------------------------|
| Unity            | Game Engine                      |
| C#               | Development Language             |
| UniRx            | Reactive Programming             |
| UniTask          | Async Operations                 |
| JsonUtility      | Save/Load System                 |
| ScriptableObject | Data and Configuration Management|

---

## 📌 Notes

This project was built from scratch as a personal learning experience. It uses **random generation** instead of full procedural generation, keeping development efficient while still offering variation in gameplay. There is no ship upgrade system — only crew improvements and fuel management.

---

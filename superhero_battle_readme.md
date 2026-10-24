# 🦸‍♂️ Superhero Battle Simulator

A terminal-based, object-oriented combat simulator built in C#. 

This console application allows users to dynamically draft a custom roster of superheroes, assign stats and unique backgrounds, and pit them against each other in a turn-based arena. The combat system features a simultaneous clash mechanic where both fighters trade blows instantly, influenced by a dynamic type-advantage multiplier system.

## ✨ Features

* **Dynamic Character Creation:** Build heroes step-by-step with robust exception handling (`try-catch`) to ensure valid stat inputs.
* **Simultaneous Clash Combat:** A custom `Attack()` method calculates and applies damage to both the attacker and target simultaneously in a single turn.
* **Type Advantage System:** Heroes belong to different `PowerCategory` classes (Tech, Magic, Cosmic, Mutation) that actively scale damage by +10% or -10% based on comic-accurate matchups (e.g., Tech neutralizes Mutation, Cosmic overwhelms Magic).
* **Battle History Log:** Utilizes a LIFO `Stack<string>` data structure to track round-by-round combat history and print a reverse-chronological battle log at the end of the match.

## 🛠️ Concepts & Architecture Demonstrated

This project serves as an exercise in connecting isolated programming concepts into a cohesive system design:

* **Object-Oriented Programming (OOP):** Custom `class` blueprints with encapsulated properties and behaviors.
* **Data Structures:** 
  * `List<T>` for dynamic roster storage and polymorphism.
  * `Stack<T>` for chronological battle logging.
* **Custom Types:** Integration of `struct` (Academic Backgrounds) and `enum` (Power Categories) into primary classes.
* **Control Flow & Validation:** Infinite `while(true)` loops paired with exception handling to sanitize console inputs.

## ⚔️ Power Matchups

The arena features conditional logic to alter battle math on the fly:
* **Tech vs. Mutation:** Tech gains a 10% attack buff; Mutation suffers a 10% nerf.
* **Cosmic vs. Magic:** Cosmic gains a 10% attack buff; Magic suffers a 10% nerf.

## 🚀 How to Run

1. Ensure you have the [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine.
2. Clone this repository and navigate to the project folder in your terminal:
   ```bash
   git clone https://github.com/yourusername/SuperheroBattle.git
   cd SuperheroBattle
   ```
3. Run the application via the .NET CLI:
   ```bash
   dotnet run
   ```
4. Follow the on-screen prompts to build at least two heroes and start the arena clash!
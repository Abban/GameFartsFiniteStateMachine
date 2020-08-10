# Game Farts Unity Finite State Machine

This is a small library for handling finite states in Unity.

## How it works

## Installation
You can install this in Unity as a Package by going to `Window > Package Manager` And then hitting the `+` and selecting `Add Package from git URL`. 

## Usage
This package consists of 3 main parts:

* `StateMachine`: This controls swapping states. The State Machine will store a reference to your current state, and provide functionality for swapping between different states. On change state it will check if it's possible for the current state to move to another then swap them. You must write the logic to decide on when to switch yourself, the state machine only cares about if a state _can_ move to another not when.
* `StateFactory`: This is what you use to instantiate your states and you need to write this yourself. These need to implement the `iStateFactory` interface and are injected into the `StateMachine`. The state machine will then request states from this factory when it wishes to change to a new one. You can either have the factory instantiate new states on request or set it up to pool them. You can find an example factory in the Samples folder.
* `State`: This is an abstract class your states can derive from. These control your finite states and they consist of the following:
    * A list of other states this one can transition to.
    * Lifecycle handlers (`Start`, `Update` and `Exit`). `Start` and `Exit` are called automatically, but you call `Update` manually. This allows you to call it from late or fixed update if you need to.

Each part also implements an interface if you need to roll your own.

### Setup
1. Create the states you need. These can be derived from the abstract State class or you can roll your own.
2. Add types to each other state to the list of CanMoveToStates that each state can move to. 
3. Create a factory to instantiate your states. If your states need access to different objects you can inject them here.
4. Instantiate a new state machine and inject the factory into it.
5. Kick off your state machine by calling something like `stateMachine.ChangeState(typeof(MyStateClass))`.
6. If you need to update states every frame call `stateMachine.CurrentState.Update()` in your controlling object.

### Notes
* Your FSM should run inside a controller object that handles the logic of when to move to a new state.
* Don't inject references you don't need into your individual states. If you need them to tell your controllers that it's time to change a state fire an event.

### Examples
You should install the example files contained in the Samples folder to get a better look at how this all works. 

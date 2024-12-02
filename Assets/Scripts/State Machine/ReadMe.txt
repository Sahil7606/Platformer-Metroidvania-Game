This is a very high level description of how the state machine works

-There are 3 main classes, the core, the states, and the state machine
    
    -The core is the brain of the state machine
        -Abstract class             **Video on class abstraction ->https://www.youtube.com/watch?v=qgU2ojOKLP8**
        -Inherits from MonoBehavior (this means its a component you can put on a game object)
        -Holds important components 
        -Holds state machine object
        -Contains Start, Awake, Update, and FixedUpdate
        -Contains all 'global functions' which are functions that run independent of the current state
    
    -The states are the behaviors that the state machine and core cycle through
        -Abstract class
        -Inherits from MonoBehavior
        -Every state has a specific set of functions
            -Enter()
            -Exit()
            -Update()
            -etc
        -The core decides when to run these functions
        -States gain access to components through the core
    
    -The state machine keeps track of the states, and holds the logic for state transitions
        -Does not inherit from MonoBehavior (not a component and is like a regular c# object)
        -Keeps track of previous and current state
        -Communicates to other scripts when a transition is happening
        -Contains the function Set(), that holds transition logic

    
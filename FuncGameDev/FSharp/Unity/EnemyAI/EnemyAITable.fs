module EnemyAITable

let Instance = 
    Map.empty
        .Add(1, StanderAI.ai)
        .Add(2, TrackerAI.ai)
        .Add(3, JumperAI.ai)
        .Add(10, GolemBossAI.ai)
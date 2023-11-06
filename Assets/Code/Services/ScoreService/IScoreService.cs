using System;

namespace Code.Services.ScoreService
{
    public interface IScoreService
    {
        int LastScore { get; }
        event Action<int> ScoreChanged; 

        void Run();
        void Stop();
    }
}
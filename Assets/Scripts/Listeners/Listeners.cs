namespace ShootEmUp.Listeners
{
    public sealed class Listeners
    {
        public interface IGameListener
        {
        }

        public interface IGameStartListener : IGameListener
        {
            void OnGameStarted();
        }

        public interface IGamePauseListener : IGameListener
        {
            void OnGamePaused();
        }

        public interface IGameResumeListener : IGameListener
        {
            void OnGameResumed();
        }
    
        public interface IGameFinishListener : IGameListener
        {
            void OnGameFinished();
        }
    
        public interface IUpdateListener : IGameListener
        {
            void OnUpdate();
        }
    
        public interface IFixedUpdateListener : IGameListener
        {
            void OnFixedUpdate();
        }
    }
}
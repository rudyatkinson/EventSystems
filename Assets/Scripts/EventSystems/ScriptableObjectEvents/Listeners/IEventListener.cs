namespace BilalAydin.ScriptableObject.Listeners
{
    public interface IEventListener<T>
    {
        void OnEventInvoked(T param);
    }
}
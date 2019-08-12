
namespace OOPDesignPatternFinalProject.Taxes.Interfaces
{
    public interface IObservable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="observer"></param>
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }
}

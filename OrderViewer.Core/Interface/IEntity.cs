namespace OrderViewer.Core.Interface
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
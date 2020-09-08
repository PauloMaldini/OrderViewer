namespace OrderViewer.Core.Base
{
    public abstract class EntityCatalogBase<T> : EntityBase<T>
    {
        public string Name { get; set; }

        public string Description { get; set; }
        
        public string Code { get; set; }
    }
}
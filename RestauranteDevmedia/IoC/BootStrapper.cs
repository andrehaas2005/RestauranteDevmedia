using Nancy.Bootstrappers.StructureMap;

namespace RestauranteDevmedia.IoC
{
    public class BootStrapper : StructureMapNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(StructureMap.IContainer existingContainer)
        {
            Container.Configure(existingContainer);
        }
    }
}
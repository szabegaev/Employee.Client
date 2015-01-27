using System.Linq;
using Castle.MicroKernel.Facilities;
using Employee.Core.Views;

namespace Employee.Core.Windsor
{
    public class ViewActivatorFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.ComponentModelCreated += Kernel_ComponentModelCreated;
        }

        void Kernel_ComponentModelCreated(Castle.Core.ComponentModel model)
        {
            var isView = typeof(IView).IsAssignableFrom(model.Services.FirstOrDefault());
            if (!isView) return;

            if (model.CustomComponentActivator == null)
                model.CustomComponentActivator = typeof(WPFWindowActivator);
        }
    }
}

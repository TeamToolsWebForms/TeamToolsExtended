using System;
using WebFormsMvp;
using WebFormsMvp.Binder;
using TeamTools.Web.App_Start.MvpFactoryConfig.Contracts;

namespace TeamTools.Web.App_Start.MvpFactoryConfig
{
    public class CustomPresenterFactory : IPresenterFactory
    {
        private readonly ICustomPresenterFactory presenterFactory;

        public CustomPresenterFactory(ICustomPresenterFactory presenterFactory)
        {
            this.presenterFactory = presenterFactory;
        }

        public IPresenter Create(Type presenterType, Type viewType, IView viewInstance)
        {
            IPresenter presenter = this.presenterFactory.GetPresenter(presenterType, viewType, viewInstance);
            return presenter;
        }

        public void Release(IPresenter presenter)
        {
        }
    }
}
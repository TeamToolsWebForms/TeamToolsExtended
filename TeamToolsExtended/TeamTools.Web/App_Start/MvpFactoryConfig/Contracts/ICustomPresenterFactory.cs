using System;
using WebFormsMvp;

namespace TeamTools.Web.App_Start.MvpFactoryConfig.Contracts
{
    public interface ICustomPresenterFactory
    {
        IPresenter GetPresenter(Type presenterType, Type viewType, IView viewInstance);
    }
}

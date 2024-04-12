using Prism.Mvvm;
using Prism.Navigation;
using System.ComponentModel;
using System;
using System.Windows.Media;
using System.Collections;

namespace Expertsystem.Core.Mvvm
{
    public abstract class ViewModelBase : BindableBase, IDestructible
    {
        protected ViewModelBase()
        {

        }

        public virtual void Destroy()
        {

        }
    }
}

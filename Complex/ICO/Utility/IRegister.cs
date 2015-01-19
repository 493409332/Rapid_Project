using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex.ICO.Utility
{
    //•TransientLifetimeManager - 为每次请求生成新的类型对象实例。 (默认行为)
    #region 建议采用第一个
    public interface ITransientLifetimeManagerRegister{}
    #endregion
    //•ContainerControlledLifetimeManager - 实现Singleton对象实例。 当容器被Disposed后，对象实例也被Disposed。
    public interface IContainerControlledLifetimeManagerRegister{}
    //•HierarchicalLifetimeManager - 实现Singleton对象实例。但子容器并不共享父容器实例，而是创建针对字容器的Singleton对象实例。当容器被Disposed后，对象实例也被Disposed。
    public interface IHierarchicalLifetimeManagerRegister{}
    //•ExternallyControlledLifetimeManager - 实现Singleton对象实例，但容器仅持有该对象的弱引用（WeakReference），所以该对象的生存期由外部引用控制。
    public interface IExternallyControlledLifetimeManagerRegister{}
    //•PerThreadLifetimeManager - 为每个线程生成Singleton的对象实例，通过ThreadStatic实现。
    #region 对于WEB项目不适用
       public interface IPerThreadLifetimeManagerRegister{} 
    #endregion
 
    //•PerResolveLifetimeManager - 实现与TransientLifetimeManager类似的行为，为每次请求生成新的类型对象实例。不同之处在于对象实例在BuildUp过程中是可被重用的。
    public interface IPerResolveLifetimeManagerRegister{}//在本项目当前情况基本效果和第一个一模一样
 
    
}

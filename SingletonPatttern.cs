using System;
using System.Collections.Generic;
using System.Text;

namespace AllDesignMode
{
    /// <summary>
    /// 单例设计模式
    /// </summary>
    class SingletonPatttern
    {
        /*
         *单例设计模式思想：保证该类有且只能创建一个实例对象。 
         *1、通过私有化构造方法，从而不让其他代码实例化该对象
         *2、提供公有的静态方法让别人获得该类的实例
         *   2.1、该方法要保证有且只能获得同一个对象，且线程安全
         *3、代码实现的方法有很种，本代码只是其中一种，也是最常用的。
         */
        /*
         * 应用场景：程序中有且只需要一个实例的，如Windows的任务管理器等
         */


        /// <summary>
        /// 类的单一实例
        /// 私有封装，避免代码Instance=null 后创建新的实例对象 
        /// 静态，静态与非静态思想，非静态要在类被实例化后使用，但构造方法已被私有化，不可能先实例化再使用了，且多线程访问的是同一对象。
        /// </summary>
        private static   SingletonPatttern instance;

        /// <summary>
        /// 锁机制对象
        /// </summary>
        private static readonly Object lockInstance = new object();

        /// <summary>
        /// 私有构造方法：目的，不让别代码随意实例化此类，保证实例单一的前提
        /// </summary>
        private SingletonPatttern()
        {
            
        }

        /// <summary>
        /// 获取单一实例
        /// 公有：该类提供的唯一获取实例方法，保证实例的唯一性
        /// 静态：未实例对象即可用，同时也只有静态方法才可以访问静态变量instance
        /// lock：保证线程安全，由于在多线下同时访问未实例化的单例对象时，可能会同时创建对象，从而不能保证类型只被实例化一次，故增加锁机制保证线程安全
        /// 
        /// </summary>
        /// <returns></returns>
        public static SingletonPatttern GetInstance()
        {
            if (instance == null)             //如果不是从性能方面考虑，这行代码是多余的。
                lock (lockInstance)
                {
                    if (instance == null)
                        instance = new SingletonPatttern();
                }
            return instance;
        }
    }
}

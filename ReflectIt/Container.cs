using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectIt
{
    public class Container
    {
        Dictionary<Type, Type> _map = new Dictionary<Type, Type>();

        public ContainerBuilder For<TSourse>()
        {
            return For(typeof(TSourse));
        }

        public ContainerBuilder For(Type sourceType)
        {
            return new ContainerBuilder(this, sourceType);
        }

       

        public TSource Resolve<TSource>()
        {
            return (TSource)Resolve(typeof(TSource));
        }

        public object Resolve(Type sourceType)
        {
            if (_map.ContainsKey(sourceType))
            {
                var destinationType = _map[sourceType];

                //return Activator.CreateInstance(destinationType);
                return CreateInstance(destinationType);
            }
            else if (sourceType.IsGenericType && 
                _map.ContainsKey(sourceType.GetGenericTypeDefinition()))
            {
                var destination = _map[sourceType.GetGenericTypeDefinition()];
                var closedDestination = destination.MakeGenericType(sourceType.GenericTypeArguments);
                return CreateInstance(closedDestination);
            }
            else if (!sourceType.IsAbstract)
            {
                return CreateInstance(sourceType);
            }
            else
            {
                throw new InvalidOperationException("Could not resolve" + sourceType.Name);
            }
        }

        private object CreateInstance(Type destinationType)
        {
            var paramaters = destinationType.GetConstructors()
                                    .OrderByDescending(c => c.GetParameters().Count())
                                    .First()
                                    .GetParameters()
                                    .Select(p => Resolve(p.ParameterType))
                                    .ToArray();

            return Activator.CreateInstance(destinationType, paramaters);
        }

        public class ContainerBuilder
        {
            public ContainerBuilder(Container container, Type sourceType)
            {
                _container = container;
                _sourceType = sourceType;
            }

            public ContainerBuilder Use<TDestination>()
            {
                return Use(typeof(TDestination));
            }

            public ContainerBuilder Use(Type destinationType)
            {
                _container._map.Add(_sourceType, destinationType);
                return this;
            }

            Container _container;
            Type _sourceType;
        }
    }
}

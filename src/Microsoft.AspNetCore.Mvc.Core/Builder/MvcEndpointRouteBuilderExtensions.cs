// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Builder
{
    public static class MvcEndpointRouteBuilderExtensions
    {
        public static IEndpointConventionBuilder MapMvcControllers(
            this IEndpointRouteBuilder routeBuilder)
        {
            return MapMvcControllers<ControllerBase>(routeBuilder);
        }

        public static IEndpointConventionBuilder MapMvcControllers<TController>(
            this IEndpointRouteBuilder routeBuilder) where TController : ControllerBase
        {
            var dataSource = GetOrCreateDataSource(routeBuilder);

            var conventionBuilder = new DefaultEndpointConventionBuilder();

            dataSource.AttributeRoutingConventionResolvers.Add(actionDescriptor =>
            {
                if (actionDescriptor is ControllerActionDescriptor controllerActionDescriptor &&
                    typeof(TController).IsAssignableFrom(controllerActionDescriptor.ControllerTypeInfo))
                {
                    return conventionBuilder;
                }

                return null;
            });

            return conventionBuilder;
        }

        public static IEndpointConventionBuilder MapMvcRoute(
            this IEndpointRouteBuilder routeBuilder,
            string name,
            string template)
        {
            return MapMvcRoute<ControllerBase>(routeBuilder, name, template, defaults: null);
        }

        public static IEndpointConventionBuilder MapMvcRoute(
            this IEndpointRouteBuilder routeBuilder,
            string name,
            string template,
            object defaults)
        {
            return MapMvcRoute<ControllerBase>(routeBuilder, name, template, defaults, constraints: null);
        }

        public static IEndpointConventionBuilder MapMvcRoute(
            this IEndpointRouteBuilder routeBuilder,
            string name,
            string template,
            object defaults,
            object constraints)
        {
            return MapMvcRoute<ControllerBase>(routeBuilder, name, template, defaults, constraints, dataTokens: null);
        }

        public static IEndpointConventionBuilder MapMvcRoute(
            this IEndpointRouteBuilder routeBuilder,
            string name,
            string template,
            object defaults,
            object constraints,
            object dataTokens)
        {
            return MapMvcRoute<ControllerBase>(routeBuilder, name, template, defaults, constraints, dataTokens);
        }

        public static IEndpointConventionBuilder MapMvcRoute<TController>(
            this IEndpointRouteBuilder routeBuilder,
            string name,
            string template) where TController : ControllerBase
        {
            return MapMvcRoute<TController>(routeBuilder, name, template, defaults: null);
        }

        public static IEndpointConventionBuilder MapMvcRoute<TController>(
            this IEndpointRouteBuilder routeBuilder,
            string name,
            string template,
            object defaults) where TController : ControllerBase
        {
            return MapMvcRoute<TController>(routeBuilder, name, template, defaults, constraints: null);
        }

        public static IEndpointConventionBuilder MapMvcRoute<TController>(
            this IEndpointRouteBuilder routeBuilder,
            string name,
            string template,
            object defaults,
            object constraints) where TController : ControllerBase
        {
            return MapMvcRoute<TController>(routeBuilder, name, template, defaults, constraints, dataTokens: null);
        }

        public static IEndpointConventionBuilder MapMvcRoute<TController>(
            this IEndpointRouteBuilder routeBuilder,
            string name,
            string template,
            object defaults,
            object constraints,
            object dataTokens) where TController : ControllerBase
        {
            var mvcEndpointDataSource = GetOrCreateDataSource(routeBuilder);

            var endpointInfo = new MvcEndpointInfo(
                name,
                template,
                new RouteValueDictionary(defaults),
                new RouteValueDictionary(constraints),
                new RouteValueDictionary(dataTokens),
                routeBuilder.ServiceProvider.GetRequiredService<ParameterPolicyFactory>());

            endpointInfo.ControllerType = typeof(TController);

            mvcEndpointDataSource.ConventionalEndpointInfos.Add(endpointInfo);

            return endpointInfo;
        }

        public static IEndpointConventionBuilder MapApplication(this IEndpointRouteBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            MvcEndpointInfo endpointBuilder = null;
            return endpointBuilder;
        }

        public static IEndpointConventionBuilder MapApplication(
            this IEndpointRouteBuilder builder,
            string name,
            string pattern,
            object defaults = null,
            object constraints = null,
            object dataTokens = null)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            MvcEndpointInfo endpointBuilder = null;
            return endpointBuilder;
        }

        public static IEndpointConventionBuilder MapAssembly(this IEndpointRouteBuilder builder, Assembly assembly)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            MvcEndpointInfo endpointBuilder = null;
            return endpointBuilder;
        }

        public static IEndpointConventionBuilder MapAssembly(
            this IEndpointRouteBuilder builder,
            Assembly assembly,
            string routeName,
            string routeTemplate,
            object defaults = null,
            object constraints = null,
            object dataTokens = null)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            MvcEndpointInfo endpointBuilder = null;
            return endpointBuilder;
        }

        public static IEndpointConventionBuilder MapAssemblyFromType<T>(this IEndpointRouteBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            MvcEndpointInfo endpointBuilder = null;
            return endpointBuilder;
        }

        public static IEndpointConventionBuilder MapAssembly<T>(
            this IEndpointRouteBuilder builder,
            string routeName,
            string routeTemplate,
            object defaults = null,
            object constraints = null,
            object dataTokens = null)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            MvcEndpointInfo endpointBuilder = null;
            return endpointBuilder;
        }

        public static IEndpointConventionBuilder MapController(this IEndpointRouteBuilder builder, Type controllerType)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            MvcEndpointInfo endpointBuilder = null;
            return endpointBuilder;
        }

        public static IEndpointConventionBuilder MapController(
            this IEndpointRouteBuilder builder,
            Type controllerType,
            string routeName,
            string routeTemplate,
            object defaults = null,
            object constraints = null,
            object dataTokens = null)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            MvcEndpointInfo endpointBuilder = null;
            return endpointBuilder;
        }

        public static IEndpointConventionBuilder MapController<T>(this IEndpointRouteBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            MvcEndpointInfo endpointBuilder = null;
            return endpointBuilder;
        }

        public static IEndpointConventionBuilder MapController<T>(
            this IEndpointRouteBuilder builder,
            string routeName,
            string routeTemplate,
            object defaults = null,
            object constraints = null,
            object dataTokens = null)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            MvcEndpointInfo endpointBuilder = null;
            return endpointBuilder;
        }

        private static MvcEndpointDataSource GetOrCreateDataSource(IEndpointRouteBuilder builder)
        {
            var dataSource = builder.DataSources.OfType<MvcEndpointDataSource>().FirstOrDefault();
            if (dataSource == null)
            {
                dataSource = builder.ServiceProvider.GetRequiredService<MvcEndpointDataSource>();
                builder.DataSources.Add(dataSource);
            }

            return dataSource;
        }
    }
}

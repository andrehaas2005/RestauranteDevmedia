﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using StructureMap.Graph;

namespace RestauranteDevmedia.IoC
{
    public class Container
    {
        public static void Configure(IContainer container)
        {
            container.Configure(config => config.Scan(c =>
            {
                c.TheCallingAssembly();
                c.WithDefaultConventions();
            }));
        }
    }
}
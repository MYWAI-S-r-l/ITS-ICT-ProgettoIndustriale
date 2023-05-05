using System;
using Autofac;
using System.Reflection;

namespace ProgettoIndustriale.Service.Api;

internal class MyAutofacModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        Assembly? assembly = Assembly.GetAssembly(typeof(Business.Imp.EntiManager));
        if (assembly == null)
            throw new MissingMethodException("FormatoProtocolloManager not found in DI configuration");

        builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().InstancePerLifetimeScope();

        // assembly = Assembly.GetAssembly(typeof(MywAi.ObjectSerializer.SerializedObjectManagerJson<>));
        // if (assembly == null)
        //     throw new MissingMethodException("SerializedObjectManagerJson not found in DI configuration");

        builder.RegisterAssemblyOpenGenericTypes(assembly).AsImplementedInterfaces().InstancePerLifetimeScope();

        // assembly = Assembly.GetAssembly(typeof(Business.Imp.DmsManager));
        // if (assembly == null)
        //     throw new MissingMemberException("DmsManager not found in DI configuration.");
        //
        // builder.RegisterAssemblyOpenGenericTypes(assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
    }
}

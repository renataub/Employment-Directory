﻿using Bl.BlApi;
using Bl.BlObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Microsoft.Extensions.DependencyInjection;
using Bl.BlImplementation;


namespace Bl;

public class BlManager
{
    public BussinesDetailsRepoForClient BussinesDetailsRepoForClient { get;  }
    public BussinesDetailsRepoForBussinesOwner BussinesDetailsRepoForBussinesOwner { get; }
    public AddressesRepoForClient AddressesRepoForClient { get; }

    public BlManager() {
        ServiceCollection services = new();
        services.AddScoped<DalManager>();
        services.AddScoped<IBussinesDetailsRepoForClient, BussinesDetailsRepoForClient>();
        services.AddScoped<IBussinesDetailsRepoForBusinessOwner, BussinesDetailsRepoForBussinesOwner>();
        services.AddScoped<IAddressesRepoForClient, AddressesRepoForClient>();

        ServiceProvider servicesProvider = services.BuildServiceProvider();

        BussinesDetailsRepoForBussinesOwner = (BussinesDetailsRepoForBussinesOwner)servicesProvider.GetService<IBussinesDetailsRepoForBusinessOwner>();
        BussinesDetailsRepoForClient = (BussinesDetailsRepoForClient)servicesProvider.GetService<IBussinesDetailsRepoForClient>();
        AddressesRepoForClient = (AddressesRepoForClient)servicesProvider.GetService<IAddressesRepoForClient>();
       // AddressesRepoForClient = (AddressesRepoForClient)servicesProvider.GetServices<IAddressesRepoForClient>();



    }

    
}

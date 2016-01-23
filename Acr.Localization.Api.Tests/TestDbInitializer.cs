using System;
using System.Data.Entity;
using Acr.Localization.Api.Core.Ef;


namespace Acr.Localization.Api.Tests {

    public class TestDbInitializer : DropCreateDatabaseAlways<LocalDbContext> {

        protected override void Seed(LocalDbContext db) {}
    }
}

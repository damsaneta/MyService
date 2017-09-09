using System;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Indexes;

namespace MyService.Application.Respositories
{
    public static class RavenDocumentStore
    {
        private static readonly Lazy<IDocumentStore> LazyStore =
        new Lazy<IDocumentStore>(() =>
        {
            var store = new DocumentStore
            {
                ConnectionStringName = "Server"
            };
            store.Initialize();
            IndexCreation.CreateIndexes(typeof(RavenDocumentStore).Assembly, store);
            return store;
        });

        public static IDocumentStore Store => LazyStore.Value;
    }
}

using App.Compoment.Library.ElasticSearch;
using Elastic.Clients.Elasticsearch;
using Microsoft.Extensions.DependencyInjection;

namespace App.Compoment.Extension.ElasticSearchExtension
{
    public static class AddElasticSearchExtension
    {
        public static IServiceCollection AddElasticSearch(this IServiceCollection service, ElasticOptions config)
        {
            var settings = new ElasticsearchClientSettings(new Uri(config.ElasticHost))
                .DisableDirectStreaming()
                .DefaultIndex(config.ElasiticmainIndex)
                //.BasicAuthentication(config.UserName,config.PassWord)
                .DisablePing(true).Proxy(new Uri(config.ElasticHost), config.UserName, config.PassWord);

            var client = new ElasticsearchClient(settings);

            return service.AddSingleton(client);
        }
    }
}

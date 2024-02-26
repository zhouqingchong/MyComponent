using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Runtime;
using App.Compoment.DynamoDB.Repositories;
using App.Compoment.Extension.DynamoDBExtension;
using App.Compoment.Library.DynamoDB;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Compoment.DynamoDB
{
    public static class AddDynamoDBService
    {
        public static void AddDynamoDB(this IServiceCollection service, IConfiguration configuration)
        {
            DynamoDBOption options = configuration.GetSection("DynamoDBOption").Get<DynamoDBOption>() ?? new DynamoDBOption();
            var credentials = new BasicAWSCredentials(options.AWSAccessKey, options.AWSSecretKey);
            RegionEndpoint region = RegionEndpoint.GetBySystemName(options.AWSRegion);

            service.AddTransient(prover => new AmazonDynamoDBClient(credentials, region));
            service.AddSingleton<IDDB_Product, DDB_Product>();
            service.AddSingleton<IDDB_Product_Price, DDB_Product_Price>();
        }
    }
}

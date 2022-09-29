using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfluxDB.Client;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Core;
using InfluxDB.Client.Writes;
using Remotion.Linq.Parsing.Structure.NodeTypeProviders;
using Task = System.Threading.Tasks.Task;

namespace S9000C
{
    public static class InfluxTimeData
    {
        private static readonly char[] token = "hfV3Qu2qKpR6q88lim6eqO2i-mb73hdOuUKjPPcdmqKaSiwnUXjCvYTfosyiN5c_gizr6jI71lejRcj-az2ZPA==".ToCharArray();
        public static async Task Write2InfluxDB()
        {
            var influxDBClient = InfluxDBClientFactory.Create("http://192.168.0.11:11884", token);

            var org = "Emtech";
            var bucket = "NewTest";
            var retention = new BucketRetentionRules(BucketRetentionRules.TypeEnum.Expire, 3600);
            //double cnt = 0;
            Random r = new Random();

            //var bucket = await influxDBClient.GetBucketsApi().CreateBucketAsync("iot_bucket", retention, org);
            for (int i = 0; i < 10; i++)
            {
                double num1 = GetRandomNumberInRange(r, 50, 100);
                double num2 = GetRandomNumberInRange(r, 50, 100);
                double num3 = GetRandomNumberInRange(r, 50, 100);

                using (var writeApi = influxDBClient.GetWriteApi())
                {

                    var point = PointData
                        .Measurement("5LEQ")
                        .Tag("Site_ID", "Mabuk")
                        .Tag("Equipment_ID", "7201")
                        .Field("5LEQ", num1)
                        .Field("10LEQ",num2)
                        .Field("40LEQ",num3)
                        .Timestamp(DateTime.UtcNow, WritePrecision.Ns);
                    /*
                    var point2 = PointData
                       .Measurement("5LEQ")
                       .Tag("Site_ID", "Mabuk")
                       .Tag("Equipment_ID", "7202")
                       .Field("5LEQ", num2)
                       .Timestamp(DateTime.UtcNow, WritePrecision.Ns);

                    var point3 = PointData
                       .Measurement("5LEQ")
                       .Tag("Site_ID", "Mabuk")
                       .Tag("Equipment_ID", "7203")
                       .Field("5LEQ", num3)
                       .Timestamp(DateTime.UtcNow, WritePrecision.Ns);
                    */
                    writeApi.WritePoint(point, bucket, org);
                    //writeApi.WritePoint(point2, bucket, org);
                    //writeApi.WritePoint(point3, bucket, org);
                }
                //cnt++;
            }

            /*
            var flux = "from(bucket:\"Sunho\") |> range(start: 0)";

            var fluxTables = await influxDBClient.GetQueryApi().QueryAsync(flux, org);
            fluxTables.ForEach(fluxTable =>
            {
                var fluxRecords = fluxTable.Records;
                fluxRecords.ForEach(fluxRecord =>
                {
                    //Console.WriteLine($"{fluxRecord.GetTime()} : {fluxRecord.GetValue()}");
                });
            });
            
            influxDBClient.Dispose();
            */
        }

        public static double GetRandomNumberInRange(Random random, double minNumber, double maxNumber)
        {
            return random.NextDouble() * (maxNumber - minNumber) + minNumber;
        }
    }
}

using Breweries.Data;
using System.IO;
using System;
using CsvHelper;
using System.Globalization;
using Breweries.Importer.DTO;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using Breweries.Data.Services;
using Breweries.Data.Models;

namespace Breweries.Importer
{
    class Program
    {
        private static IBreweryService service;

        static async Task Main(string[] args)
        {
            var db = new ApplicationDbContext();
            service = new BreweryService(db);

            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            await ProcessData(@".\Data");
        }

        private static async Task ProcessData(string path)
        {
            var directories = Directory.GetDirectories(path);
            var singleSW = new Stopwatch();
            var mainSW = new Stopwatch();
            var timeTable = new Dictionary<string, long>();

            mainSW.Start();

            var readyModels = new List<RawBreweryDTO>();

            foreach (var item in directories)
            {
                var state = item.Split(@"\").Last();

                singleSW.Start();

                readyModels.AddRange(ProcessCSV($"./Data/{state}/{state}.csv"));

                singleSW.Stop();

                timeTable.Add(state, singleSW.ElapsedMilliseconds);
                singleSW.Reset();
            }

            await service.CreateBulk(readyModels.ToArray());

            mainSW.Stop();

            foreach (var (key, value) in timeTable)
            {
                Console.WriteLine($"State: {key} ({value}ms)");
            }

            Console.WriteLine($"Total time: {mainSW.ElapsedMilliseconds}ms");
        }

        private static IEnumerable<RawBreweryDTO> ProcessCSV(string path)
        {
            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var result = csv.GetRecords<RawBreweryDTO>();

            return result.ToList();
        }
    }
}

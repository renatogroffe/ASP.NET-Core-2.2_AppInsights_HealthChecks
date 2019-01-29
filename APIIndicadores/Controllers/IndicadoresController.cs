using System;
using System.Linq;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using APIIndicadores.Data;
using Microsoft.ApplicationInsights;

namespace APIIndicadores.Controllers
{
    [Route("api/[controller]")]
    public class IndicadoresController : Controller
    {
        private static object syncObject = Guid.NewGuid();

        [HttpGet]
        public ContentResult Get(
            [FromServices]ApplicationDbContext context,
            [FromServices]IDistributedCache cache)
        {
            DateTimeOffset inicio = DateTime.Now;
            Stopwatch watch = new Stopwatch();
            watch.Start();

            string valorJSON = cache.GetString("Indicadores");
            if (valorJSON == null)
            {
                // Exemplo de implementação do pattern Double-checked locking
                // Para mais informações acesse:
                // https://en.wikipedia.org/wiki/Double-checked_locking
                lock (syncObject)
                {
                    valorJSON = cache.GetString("Indicadores");
                    if (valorJSON == null)
                    {
                        var indicadores = (from i in context.Indicadores
                                           select i).AsEnumerable();

                        DistributedCacheEntryOptions opcoesCache =
                            new DistributedCacheEntryOptions();
                        opcoesCache.SetAbsoluteExpiration(
                            TimeSpan.FromSeconds(30));

                        valorJSON = JsonConvert.SerializeObject(indicadores);
                        cache.SetString("Indicadores", valorJSON, opcoesCache);
                    }
                }
            }

            watch.Stop();
            TelemetryClient client = new TelemetryClient();
            client.TrackDependency(
                "Redis", "Get", valorJSON, inicio, watch.Elapsed, true);

            return Content(valorJSON, "application/json");
        }
    }
}